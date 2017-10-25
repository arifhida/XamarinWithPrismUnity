using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.Models
{
    public class Product
    {
        public int id { get; set; }
        public string product_name { get; set; }
        public string package_code { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string compatibility { get; set; }
        public string urldownload { get; set; }
        public string status { get; set; }
        public DateTime created { get; set; }
        public int category_id { get; set; }
        public int sub_category_id { get; set; }
    }
}
