using mekashron.loginApp.BLL.Interfaces;
using mekashron.loginApp.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mekashron.loginApp.Client.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        //private readonly ILogger _logger;
        private readonly ILoginService _loginService;
        public LoginController(IConfiguration configuration, ILoginService loginService)
        {
            this._configuration = configuration;
            this._loginService = loginService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Не правильный логин или пароль");
            }
            var ip = HttpContext.Connection.LocalIpAddress;
            return Ok(await _loginService.Login(login, password, ip.ToString()));

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
