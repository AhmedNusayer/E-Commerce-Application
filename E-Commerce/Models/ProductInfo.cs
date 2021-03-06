﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    //model for Catagories/purchase/id api
    public class ProductInfo
    {
        [Key]
        public int p_id { get; set; }
        public int c_Id { get; set; }
        public string p_title { get; set; }
        public string p_title_eng { get; set; }
        public string amount { get; set; }
        public int price { get; set; }
        public string p_imgLink { get; set; }
    }
}
