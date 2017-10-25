using Newtonsoft.Json.Linq;
using OneStop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.IServices
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string Username, string Password);
        List<MasterItem> GetMenus(bool isLogin);

        Task<RegistrationResult> RegisterAsync(RegisterModel register);

        Task<JObject> GetHome();
    }
}
