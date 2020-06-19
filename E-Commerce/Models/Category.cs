using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Category
    {
        [Key]
        public int c_id { get; set; }
        public string c_title { get; set; }
        public string c_imgLink { get; set; }
    }
}
