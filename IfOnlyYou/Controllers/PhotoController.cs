using IfOnlyYou.Extensions;
using IfOnlyYou.IServices;
using IfOnlyYouDataAccessLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IfOnlyYou.Controllers
{
    [Authorize]
    public class PhotoController : BasicApiController
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpPost]
        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
        {
            return await _photoService.UpdatePhotoAsync(file, User.GetUsername());
        }

        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult<PhotoDto>> SetMainPhoto(int photoId)
        {
            return await _photoService.SetMainPhoto(photoId, User.GetUsername());
        }

        [HttpDelete("{photoId}")]
        public async Task<MemberDto> DeletePhoto(int photoId)
        {
            return await _photoService.DeletePhoto(photoId, User.GetUsername());
        }
    }
}
