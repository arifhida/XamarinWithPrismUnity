using OneStop.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OneStop.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OneStop.Helpers;

namespace OneStop.Services
{
    public class AuthService : IAuthService
    {
        HttpClient client = new HttpClient();
        private string url = "http://10.0.2.2:8000/";

        public List<MasterItem> GetMenus(bool isLogin)
        {
            var menus = new List<MasterItem>();
            menus.Add(new MasterItem() { Title = "Home", IconSource="", Navigation = "/Initial/Navigate/MainPage" });
            menus.Add(new MasterItem() { Title = "About", IconSource = "", Navigation = "/Initial/Navigate/MainPage" });
            menus.Add(new MasterItem() { Title = "Login", IconSource = "", IsLoggedIn = false, Navigation= "/Initial/Navigate/LoginPage" });

            return menus.Where(x => x.IsLoggedIn == null || x.IsLoggedIn == isLogin).ToList();

        }

        public async Task<bool> LoginAsync(string Username, string Password)
        {
            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("username", Username));
            formData.Add(new KeyValuePair<string, string>("password", Password));
            var content = new FormUrlEncodedContent(formData);
            var response = await client.PostAsync(string.Format("{0}/api/auth/token", url), content);
            var stringContent = await response.Content.ReadAsStringAsync();
            JObject token = JsonConvert.DeserializeObject<dynamic>(stringContent);
            if (response.IsSuccessStatusCode)
            {
                var accessToken = token.Value<string>("access_token");
                Settings.access_token = accessToken;
            }


            return response.IsSuccessStatusCode;
        }
    }

}
