using ApiTest4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTest4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {

        private readonly MyManagementContext _context;
        public ProductController(MyManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var product = _context.Products.Include(c=>c.Category).OrderBy(p => p.Id).ToList();
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }
    }
}
