using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.Models
{
    public class PaymentMethod
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string payment
        {
            get
            {
                return string.Format("Pay with {0}", name);
            }
        }
    }
}
