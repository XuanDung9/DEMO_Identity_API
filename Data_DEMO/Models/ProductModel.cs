﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_DEMO.Models
{
    public class ProductModel
    {
        public long Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public long? Price { get; set; }
    }
}
