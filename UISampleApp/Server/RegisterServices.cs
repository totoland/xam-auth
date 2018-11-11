using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Models;
using UISampleApp.Models.Commons;
using UISampleApp.Server;
using Xamarin.Forms;

[assembly: Dependency(typeof(RegisterServices))]
namespace UISampleApp.Server
{
    public class RegisterServices: IRegisterService
    {
        private readonly string tag = "RegisterServices";
        private readonly IMessage message = DependencyService.Get<IMessage>();
        private readonly string serverEndpoint = "http://192.168.1.34:9000/auth/login";


        public async Task<ResponseCode> CreateUserAccount(UserInfo user)
        {
            var client = new HttpClient
            {
                //Set timeout
                Timeout = TimeSpan.FromSeconds(10)
            };

            var model = new UserInfo
            {
                username = user.username,
                password = user.password
            };

            var responseCode = new ResponseCode
            {
                RespCode = ResponseCode.SUCCESS
            };

            var json = JsonConvert.SerializeObject(model);
            
            try
            {
                HttpContent httpContent = new StringContent(json);

                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(serverEndpoint, httpContent);
                
                if (!response.IsSuccessStatusCode)
                {
                    message.Debug(tag, "response not success");
                    responseCode = new ResponseCode
                    {
                        RespCode = "500"
                    };
                    return responseCode;
                }

                message.Debug(tag, response.RequestMessage.ToString());

                var content = await response.Content.ReadAsStringAsync();
                UserInfo respUser = JsonConvert.DeserializeObject<UserInfo>(content);

                #region user not found
                if (respUser == null)
                {
                    responseCode = new ResponseCode
                    {
                        RespCode = ResponseCode.NOT_FOUND
                    };
                    return responseCode;
                }
                #endregion

                responseCode.Data = respUser;

                return responseCode;
            }
            catch (Exception e)
            {
                message.Debug(tag,e.ToString());
                responseCode = new ResponseCode
                {
                    RespCode = ResponseCode.SERVICE_UNAVAILABLE,
                    RespDesc = e.Message
                };
            }

            return responseCode;
        }
    }
}
