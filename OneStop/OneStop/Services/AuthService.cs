using OneStop.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OneStop.Models;

namespace OneStop.Services
{
    public class AuthService : IAuthService
    {
        HttpClient client = new HttpClient();
        private string url = "http://10.0.2.2:8000/";

        public Task<List<MasterItem>> GetMenus(bool isLogin)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoginAsync(string Username, string Password)
        {
            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("username", Username));
            formData.Add(new KeyValuePair<string, string>("password", Password));
            var content = new FormUrlEncodedContent(formData);
            var response = await client.PostAsync(string.Format("{0}/api/auth/token", url), content);
            var stringContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                
            }
            else
            {

            }
            return response.IsSuccessStatusCode;
        }
    }

}
