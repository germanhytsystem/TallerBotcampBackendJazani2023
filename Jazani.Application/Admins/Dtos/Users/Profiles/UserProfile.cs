using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Users.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile() { 
        
            CreateMap<User,UserDto>();

            CreateMap<User,UserSecurityDto>();

            CreateMap<User,UserSaveDto>().ReverseMap();
        }

    }
}
