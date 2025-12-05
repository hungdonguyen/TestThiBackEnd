using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestThiBackEnd.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            return Ok(await _context.Orders.ToListAsync());
        }
    }
}
