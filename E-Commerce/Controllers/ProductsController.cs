using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Models;
using System.Collections.Immutable;

namespace E_Commerce.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ECommerceContext _context;

        public ProductsController(ECommerceContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet("{bangla}")]
        public dynamic GetProducts(int bangla)
        {
            //return await _context.Products.ToListAsync();
            if (bangla == 1)
            {
                IEnumerable<ProductBan> data = _context.Products.Select(p => new ProductBan
                {
                    p_id = p.p_id,
                    c_Id = p.c_Id,
                    p_title = p.p_title,
                    amount = p.amount,
                    price = p.price,
                    p_imgLink = p.p_imgLink,
                    specification = p.specification
                });

                return data.ToList();
            }
            else
            {
                IEnumerable<ProductEng> data = _context.Products.Select(p => new ProductEng
                {
                    p_id = p.p_id,
                    c_Id = p.c_Id,
                    p_title = p.p_title_eng,
                    price = p.price,
                    amount = p.amount,
                    p_imgLink = p.p_imgLink,
                    specification = p.specification_eng
                });

                return data.ToList();
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}/{bangla}")]
        public dynamic GetProduct(int id,int bangla)
        {
            //var product = await _context.Products.FindAsync(id);

            /*if (product == null)
            {
                return NotFound();
            }*/
            if (bangla == 1)
            {
                IEnumerable<ProductBan> data = _context.Products.Where(p => p.p_id == id)
                    .Select(p => new ProductBan
                {
                    c_Id = p.c_Id,
                    p_id = p.p_id,
                    p_title = p.p_title,
                    amount = p.amount,
                    price = p.price,
                    p_imgLink = p.p_imgLink,
                    specification = p.specification
                });

                return data.ToList();
            }
            else
            {
                IEnumerable<ProductEng> data = _context.Products.Where(p => p.p_id == id)
                    .Select(p => new ProductEng
                {
                    c_Id = p.c_Id,
                    p_id = p.p_id,
                    p_title = p.p_title_eng,
                    amount = p.amount,
                    price = p.price,
                    p_imgLink = p.p_imgLink,
                    specification = p.specification_eng
                });

                return data.ToList();
            }
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.p_id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.p_id }, product);
        }

        // DELETE: Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.p_id == id);
        }


        [HttpPost("{purchase}")]
        public async Task<ActionResult<IEnumerable<Purchase>>> PurchaseProduct(IEnumerable<Purchase> purchaseHistories)
        {
            foreach(var data in purchaseHistories){
                PurchaseHistory purchaseHistory = new PurchaseHistory();
                purchaseHistory.customer_id = data.customer_id;
                purchaseHistory.c_Id = data.c_Id;
                purchaseHistory.p_id = data.p_id;
                purchaseHistory.p_title = data.p_title;
                purchaseHistory.p_count = data.p_count;
                purchaseHistory.price = data.price;
                purchaseHistory.p_status = data.p_status;
                purchaseHistory.date_time = data.date_time;
                _context.purchase_history.Add(purchaseHistory);
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{purchase}/{history}/{1}")]
        public async Task<ActionResult<IEnumerable<PurchaseHistory>>> GetPurchaseHistory()
        {
            return await _context.purchase_history.ToListAsync();
        }

        [HttpDelete("{purchase}/{id}")]
        public async Task<ActionResult<PurchaseHistory>> DeletePurchaseHistory(int id)
        {
            var purchaseHistory = await _context.purchase_history.FindAsync(id);
            if (purchaseHistory == null)
            {
                return NotFound();
            }

            _context.purchase_history.Remove(purchaseHistory);
            await _context.SaveChangesAsync();

            return purchaseHistory;
        }
    }
}
