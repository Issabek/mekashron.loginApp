using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mekashron.loginApp.BLL.Models
{
    public partial class ErrorResponseModel
    {
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }
}
