﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneStop.Models
{
    public class Category 
    {        
        public string name { get; set; }
        public List<Product> products { get; set; }
    }
}
