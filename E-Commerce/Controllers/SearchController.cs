using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ECommerceContext _context;

        public SearchController(ECommerceContext context)
        {
            _context = context;
        }

        [HttpGet("{bangla}/{searchString}")]
        public dynamic Search(int bangla, string searchString)
        {
            var products = from m in _context.Products
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.p_title.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                             s.p_title_eng.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                             s.specification.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                             s.specification_eng.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            if (bangla == 1)
            {
                IEnumerable<ProductBan> searchBan = products.Select(p => new ProductBan
                {
                    p_id = p.p_id,
                    p_title = p.p_title,
                    price = p.price,
                    p_imgLink = p.p_imgLink,
                    amount = p.amount,
                    specification = p.specification,
                    c_Id = p.c_Id
                });

                return searchBan.ToList();
            }
            else
            {
                IEnumerable<ProductEng> searchEng = products.Select(p => new ProductEng
                {
                    p_id = p.p_id,
                    c_Id = p.c_Id,
                    amount = p.amount_eng,
                    p_title = p.p_title_eng,
                    price = p.price_eng,
                    p_imgLink = p.p_imgLink,
                    specification = p.specification_eng
                });

                return searchEng.ToList();
            }

        }
    }
}
