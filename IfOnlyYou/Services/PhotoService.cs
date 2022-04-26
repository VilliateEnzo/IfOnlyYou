using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using IfOnlyYou.IServices;
using IfOnlyYouDataAccessLibrary.DTOs;
using IfOnlyYouDataAccessLibrary.Helpers;
using IfOnlyYouDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace IfOnlyYou.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public PhotoService(IOptions<CloudinarySettings> config, IUsersService usersService, IMapper mapper)
        {
            var acc = new Account
            (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
            _usersService = usersService;
            _mapper = mapper;
        }

        public async Task<PhotoDto> UpdatePhotoAsync(IFormFile file, string username)
        {
            var user = await _usersService.GetUserByUsernameAsync(username);
            var result = await AddPhotoToCloudinaryAsync(file);

            if(result.Error != null)
            {
                throw new Exception(result.Error.Message);
            }

            var photo = CreatePhotoObject(user, result);
            user.Photos.Add(photo);

            if(await _usersService.SaveAllAsync())
            {
                return _mapper.Map<PhotoDto>(photo);
            }

            throw new Exception("Unable to save");
        }

        private Photo CreatePhotoObject(AppUser user, ImageUploadResult result)
        {
            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,
                AppUserId = user.Id,
            };

            if(user.Photos.Count <= 0)
            {
                photo.IsMain = true;
            }

            return photo;
        }

        private async Task<ImageUploadResult> AddPhotoToCloudinaryAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500)
                        .Crop("fill")
                        .Gravity("face")
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        private async Task<DeletionResult> DeletePhotoFromCloudinaryAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            return await _cloudinary.DestroyAsync(deleteParams);
        }

        public async Task<PhotoDto> SetMainPhoto(int photoId, string username)
        {
            var user = await _usersService.GetUserByUsernameAsync(username);
            var photo = user.Photos.FirstOrDefault(ph => ph.Id == photoId);

            if (photo == null)
            {
                throw new Exception("No photo found with that Id");
            }

            if (photo.IsMain == true)
            {
                throw new Exception("Already main photo");
            }

            var oldMainPhoto = user.Photos.FirstOrDefault(ph => ph.IsMain == true);
            if (oldMainPhoto != null) oldMainPhoto.IsMain = false;

            photo.IsMain = true;

            if (!await _usersService.SaveAllAsync())
            {
                throw new Exception("Unable to save");
            }

            return _mapper.Map<PhotoDto>(photo);
        }

        public async Task<MemberDto> DeletePhoto(int photoId, string username)
        {
            var user = await _usersService.GetUserByUsernameAsync(username);
            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo == null)
            {
                throw new Exception("No photo found with that Id");
            }

            if (photo.IsMain == true)
            {
                throw new Exception("You cannot delete your main photo");
            }

            if (photo.PublicId != null)
            {
                var result = await DeletePhotoFromCloudinaryAsync(photo.PublicId);
                if (result.Error != null)
                {
                    throw new Exception(result.Error.Message);
                }
            }

            user.Photos.Remove(photo);
            if (await _usersService.SaveAllAsync())
            {
                return _mapper.Map<MemberDto>(user);
            }

            throw new Exception("There was an error");
        }
    }
}
