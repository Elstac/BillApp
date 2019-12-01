using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillAppDDD.Models.Auth;
using BillAppDDD.Modules.UserAccess.Application.Authentication.RefreshToken;
using BillAppDDD.Modules.UserAccess.Application.Authentication.SignIn;
using BillAppDDD.Modules.UserAccess.Application.Contracts;
using BillAppDDD.Modules.UserAccess.Application.Users.CreateUser;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillAppDDD.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private IUserAccessModule userAccessModule;

        public AuthController(IUserAccessModule userAccessModule)
        {
            this.userAccessModule = userAccessModule;
        }

        [HttpPost("signin")]
        public async Task<SignInResponse> SignIn([FromBody]SignInRequest request)
        {
            return await userAccessModule.ExecuteCommandAsync(new SignInCommand { Username = request.Username, Password = request.Password });
        }

        [HttpPost("createAccount")]
        public async Task CreateAccount([FromBody]SignUpRequest request)
        {
            await userAccessModule.ExecuteCommandAsync(new CreateUser { Username = request.Username, Password = request.Password, Email = request.Email });
        }

        [HttpPost("refreshToken")]
        public async Task<RefreshTokenResponse> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            return await userAccessModule.ExecuteCommandAsync(new RefreshToken {RToken=request.RefreshToken,AccessToken=request.AccessToken});
        }
    }
}
