using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Product
    {
        [Key]
        public int p_id { get; set; }
        public int c_Id { get; set; }
        public string p_title { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
        public string p_imgLink { get; set; }
        public string specification { get; set; }
    }
}
