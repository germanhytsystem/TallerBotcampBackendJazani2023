using Jazani.Application.Admins.Dtos.Users;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<Results<BadRequest,CreatedAtRoute<UserDto>>> Post([FromBody] UserSaveDto userSaveDto)
        {
            UserDto userDto= await _userService.CreateAsync(userSaveDto);

            return TypedResults.CreatedAtRoute(userDto);
        }

    }
}
