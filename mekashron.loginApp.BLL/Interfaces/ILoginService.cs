using mekashron.loginApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace mekashron.loginApp.BLL.Interfaces
{
    public interface ILoginService
    {
        //cannot be implemented since i dont have dbcontext to store it
        //Task AuthenticateAsync(UserNamePasswordClientCredential user, LoginResponse loginResponse);
        Task<LoginResult> Login(string userName, string password, string ip);
    }
}
