using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ECommerceContext _context;

        public CategoriesController(ECommerceContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet("{bangla}")]
        public dynamic GetCategories(int bangla)
        {
            //return await _context.Categories.ToListAsync();
            if (bangla == 1)
            {
                IEnumerable<CategoryBan> data = _context.Categories.Select(p => new CategoryBan
                {
                    c_id = p.c_id,
                    c_title = p.c_title,
                    c_imgLink = p.c_imgLink
                });

                return data.ToList();
            }
            else
            {
                IEnumerable<CategoryEng> data = _context.Categories.Select(p => new CategoryEng
                {
                    c_id = p.c_id,
                    c_title = p.c_title_eng,
                    c_imgLink = p.c_imgLink
                });
                 
                return data.ToList();
            }
        }

        // GET: api/5/1
        [HttpGet("{id}/{info}")]
        public dynamic GetCategory(int id)
        {
            //var category = await _context.Categories.FindAsync(id);
            //string query = "SELECT amount FROM products WHERE c_id = {0}";
            /*var product = await _context.Products
                .FromSqlRaw(query, id).AsNoTracking().ToListAsync();

            if (product == null)
            {
                return NotFound();
            }*/
            IEnumerable<ProductInfo> data = _context.Products.Where(p => p.c_Id == id)
                    .Select(p => new ProductInfo
                    {
                        p_id = p.p_id,
                        p_title = p.p_title,
                        p_title_eng = p.p_title_eng,
                        price = p.price,
                        p_imgLink = p.p_imgLink,
                        amount = p.amount,
                        c_Id = p.c_Id
                    });

            return data.ToList();

        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.c_id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.c_id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.c_id == id);
        }
    }

}
