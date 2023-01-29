using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mekashron.loginApp.BLL.Interfaces
{
    public interface IIcutechService
    {
        Task<string> LoginAsync(string login, string password, string ip);
    }
}
