using mekashron.loginApp.BLL.Interfaces;
using mekashron.loginApp.BLL.Models;
using mekashron.loginApp.BLL.Utils;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mekashron.loginApp.BLL.Services
{
    public class IcutechService : IIcutechService
    {
        private readonly IConfiguration _configuration;
        private readonly string _url;
        public IcutechService(IConfiguration config)
        {
            this._configuration = config;
            this._url = _configuration["IcutechUrl"];
        }

        public async Task<LoginResponseModel> LoginAsync(string login, string password, string ip)
        {
            var icuClient = new ICUTechClient(ICUTechClient.EndpointConfiguration.IICUTechPort, _url);
            icuClient.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = X509.Ignore();
            icuClient.Endpoint.Binding = BindingResult.GetBinding(_url);
            var loginresult = await icuClient.LoginAsync(login, password, ip);
            var deserializedLoginResponse =  JsonConvert.DeserializeObject<LoginResponseModel>(loginresult.@return);
            if(deserializedLoginResponse.EntityId==null ) 
            {
                throw new NullReferenceException(loginresult.@return);
            }
            return deserializedLoginResponse;
        }
    }
}
