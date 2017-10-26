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

        public async Task<IList<Category>> GetHome()
        {
            var response = await client.GetAsync(string.Format("{0}/home/products", url));
            var stringContent = await response.Content.ReadAsStringAsync();
            IList<Category> content = JsonConvert.DeserializeObject<IList<Category>>(stringContent);
            return content;
        }

        public List<MasterItem> GetMenus(bool isLogin)
        {
            var menus = new List<MasterItem>();
            menus.Add(new MasterItem() { Title = "Home", IconSource="", Navigation = "/Initial/Navigate/MainPage" });
            menus.Add(new MasterItem() { Title = "Profile", IconSource = "", Navigation = "/Initial/Navigate/UserProfilePage", IsLoggedIn = true });
            menus.Add(new MasterItem() { Title = "Login", IconSource = "", IsLoggedIn = false, Navigation= "/Initial/Navigate/LoginPage" });
            menus.Add(new MasterItem() { Title = "Register", IconSource = "", IsLoggedIn = false, Navigation = "/Initial/Navigate/RegisterPage" });

            return menus.Where(x => x.IsLoggedIn == null || x.IsLoggedIn == isLogin).ToList();

        }

        public async Task<UserData> GetProfile()
        {
            var accessToken = Settings.access_token;
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            var response = await client.GetAsync(string.Format("{0}/api/getuserdetails", url));
            var stringContent = await response.Content.ReadAsStringAsync();
            JObject result = JsonConvert.DeserializeObject<dynamic>(stringContent);
            JObject data = result.Value<JObject>("data");
            UserData userData = JsonConvert.DeserializeObject<UserData>(data.ToString());           
            return userData;            
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

        public async Task<RegistrationResult> RegisterAsync(RegisterModel register)
        {
            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("email", register.email));
            formData.Add(new KeyValuePair<string, string>("name", register.name));
            formData.Add(new KeyValuePair<string, string>("password", register.password));
            formData.Add(new KeyValuePair<string, string>("password_confirmation", register.password_confirmation));
            var content = new FormUrlEncodedContent(formData);
            var response = await client.PostAsync(string.Format("{0}/api/auth/register", url), content);
            var stringContent = await response.Content.ReadAsStringAsync();
            JObject jsonResponse = JsonConvert.DeserializeObject<dynamic>(stringContent);
            var result = new RegistrationResult();
            result.Succes = response.IsSuccessStatusCode;
            result.Message = jsonResponse.Value<string>("message");
            return result;
        }
    }

}
