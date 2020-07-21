using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class ProductEng
    {
        [Key]
        public int p_id { get; set; }
        public int c_Id { get; set; }
        [Column("p_title_eng")]
        public string p_title { get; set; }
        public string amount { get; set; }
        public int price { get; set; }
        public string p_imgLink { get; set; }
        [Column("specification_eng")]
        public string specification { get; set; }
    }
}
