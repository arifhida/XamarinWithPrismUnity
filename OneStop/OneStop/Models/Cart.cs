using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.Models
{
    public class Cart
    {
        public CartTotal totals { get; set; }
        public List<CartDetail> details { get; set; }
    }
}
