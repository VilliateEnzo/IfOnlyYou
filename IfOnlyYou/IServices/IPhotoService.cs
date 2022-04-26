using CloudinaryDotNet.Actions;
using IfOnlyYouDataAccessLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace IfOnlyYou.IServices
{
    public interface IPhotoService
    {
        Task<PhotoDto> UpdatePhotoAsync(IFormFile file, string username);
        Task<PhotoDto> SetMainPhoto(int photoId, string username);
        Task<MemberDto> DeletePhoto(int photoId, string username);
    }
}
