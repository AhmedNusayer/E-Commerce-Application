using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Product
    {
        [Key]
        public int p_id { get; set; }
        public int c_Id { get; set; }
        public string p_title { get; set; }
        public string p_title_eng { get; set; }
        public string amount { get; set; }
        public int price { get; set; }
        public string p_imgLink { get; set; }
        public string specification { get; set; }
        public string specification_eng { get; set; }
    }
}
