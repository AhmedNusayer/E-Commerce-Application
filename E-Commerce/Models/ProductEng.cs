using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class ProductEng
    {
        [Key]
        public int p_id { get; set; }
        public int c_Id { get; set; }
        public string p_title { get; set; }
        public string amount { get; set; }

        public static implicit operator ActionResult<object>(ProductEng v)
        {
            throw new NotImplementedException();
        }
    }
}
