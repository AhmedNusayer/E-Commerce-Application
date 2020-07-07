using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class CategoryEng
    {
        [Key]
        public int c_id { get; set; }
        [Column("c_title_eng")]
        public string c_title { get; set; }
        public string c_imgLink { get; set; }
    }
}
