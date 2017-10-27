using OneStop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.IServices
{
    public interface IDataService
    {
        Task<IList<Category>> GetHome();
        Task<bool> AddToCart(int productId, int quantity);
    }
}
