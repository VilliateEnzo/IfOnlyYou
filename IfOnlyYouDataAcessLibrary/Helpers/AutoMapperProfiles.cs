using AutoMapper;
using IfOnlyYouDataAccessLibrary.ClassExtensions;
using IfOnlyYouDataAccessLibrary.DTOs;
using IfOnlyYouDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfOnlyYouDataAccessLibrary.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(des => des.PhotoUrl, option => option.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(des => des.Age, option => option.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
