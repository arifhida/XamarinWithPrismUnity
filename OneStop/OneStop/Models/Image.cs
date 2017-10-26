using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.Models
{
    public class Image
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int image_type_id { get; set; }
        public string image { get; set; }
        public string image_url { get; set; }
    }
}
