using mekashron.loginApp.BLL.Interfaces;
using mekashron.loginApp.BLL.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace mekashron.loginApp.BLL.Services
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly SignInManager<UserNamePasswordClientCredential> _signInManager;
        private readonly IIcutechService _icutechService;
        private readonly RetryExecutor _retryExecutor;
        //private readonly UserManager<UserNamePasswordClientCredential> _userManager;
        private readonly IConfiguration _configuration;
        public LoginService( IHttpContextAccessor access, IIcutechService icutechService, IConfiguration configuration)
        {
            //this._signInManager = signInManager;
            this._httpContextAccessor = access;
            this._icutechService = icutechService;
            this._retryExecutor= new RetryExecutor();
            this._configuration= configuration; 
           // this._userManager= userManager;
        }
        public async Task<string> Login(string userName, string password,string ip)
        {
            var loginResponse =await _retryExecutor.Retry(async() => 
            await _icutechService.LoginAsync(userName, password, ip),
            _configuration.GetValue<int>("MaxRetries"),
            _configuration.GetValue<int>("MaxInterval")
            );

            return loginResponse;
        }
        //cannot be implemented since i dont have dbcontext to store it
        //public async Task AuthenticateAsync(UserNamePasswordClientCredential user, LoginResponse loginResponse)
        //{
        //    await _userManager.AddLoginAsync(user, new("", "", ""));
        //    await _signInManager.SignInAsync(user, true);
        //}
    }
}
