using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mekashron.loginApp.BLL.Models
{
    public class LoginResult
    {
        public bool IsSuccess
        {
            get
            {
                return string.IsNullOrEmpty(ErrorResult?.ResultMessage);
            }
        }
        public LoginResponseModel LoginResponse { get; set; }
        public ResponseErrorMessage ErrorResult { get; set; }
    }
    public class ResponseErrorMessage
    {

        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }
}
