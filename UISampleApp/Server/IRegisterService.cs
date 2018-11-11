using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Models;

namespace UISampleApp.Server
{
    public interface IRegisterService
    {
        Task<ResponseCode> CreateUserAccount(UserInfo user);
    }
}
