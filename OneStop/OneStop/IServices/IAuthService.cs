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
        Task<List<MasterItem>> GetMenus(bool isLogin);
    }
}
