using Newtonsoft.Json;
using OneStop.Helpers;
using OneStop.IServices;
using OneStop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.Services
{
    public class DataService : IDataService
    {
        HttpClient client = new HttpClient();
        private string url = "http://10.0.2.2:8000/";

        public async Task<bool> AddToCart(int productId, int quantity)
        {
            var accessToken = Settings.access_token;
            if (client.DefaultRequestHeaders.Where(x => x.Key == "Authorization").Count() < 1)
                client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("product_id", productId.ToString()));
            formData.Add(new KeyValuePair<string, string>("number_of_items", quantity.ToString()));
            var content = new FormUrlEncodedContent(formData);
            var response = await client.PostAsync(string.Format("{0}/api/chart/add", url), content);
            var stringContent = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode;
        }

        public async Task<Cart> GetCart()
        {
            var accessToken = Settings.access_token;
            if (client.DefaultRequestHeaders.Where(x => x.Key == "Authorization").Count() < 1)
                client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
            var response = await client.GetAsync(string.Format("{0}/api/chart/get", url));
            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                Cart result = JsonConvert.DeserializeObject<Cart>(stringContent);
                return result;
            }
            else
                return null;
        }

        public async Task<IList<Category>> GetHome()
        {
            var response = await client.GetAsync(string.Format("{0}/home/products", url));            
            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                IList<Category> content = JsonConvert.DeserializeObject<IList<Category>>(stringContent);
                return content;
            }
            else
                return null;
        }

        public async Task<IList<PaymentMethod>> GetPayment()
        {
            var accessToken = Settings.access_token;
            if (client.DefaultRequestHeaders.Where(x => x.Key == "Authorization").Count() < 1)
                client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
            var response = await client.GetAsync(string.Format("{0}/api/paymentmethod", url));
            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                IList<PaymentMethod> content = JsonConvert.DeserializeObject<IList<PaymentMethod>>(stringContent);
                return content;
            }
            else
                return null;
        }

        public async Task<Cart> RemoveFromCart(int productId)
        {
            var accessToken = Settings.access_token;
            if (client.DefaultRequestHeaders.Where(x => x.Key == "Authorization").Count() < 1)
                client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
            var response = await client.DeleteAsync(string.Format("{0}/api/chart/remove/{1}", url, productId));
            if (response.IsSuccessStatusCode)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                Cart result = JsonConvert.DeserializeObject<Cart>(stringContent);
                return result;
            }
            else
                return null;
        }
    }
}
