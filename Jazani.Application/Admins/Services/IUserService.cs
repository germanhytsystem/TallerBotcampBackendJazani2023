using Jazani.Application.Admins.Dtos.Users;
using Jazani.Application.Cores.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Services
{
    public interface IUserService:ISaveService<UserDto,UserSaveDto,int>
    {

        Task<UserSecurityDto> LoginAsync(UserAuthDto userAuthDto);

    }
}
