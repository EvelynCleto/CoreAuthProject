using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreStocks.Data;

namespace CoreStocks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProtectedResourcesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProtectedResourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<ProtectedResource> GetProtectedResource(int id)
        {
            var resource = _context.ProtectedResources.Find(id);
            if (resource == null)
            {
                return NotFound();
            }
            return resource;
        }

        [HttpPost]
        public ActionResult<ProtectedResource> CreateProtectedResource(ProtectedResource resource)
        {
            _context.ProtectedResources.Add(resource);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProtectedResource), new { id = resource.Id }, resource);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProtectedResource(int id, ProtectedResource resource)
        {
            if (id != resource.Id)
            {
                return BadRequest();
            }

            _context.Entry(resource).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProtectedResource(int id)
        {
            var resource = _context.ProtectedResources.Find(id);
            if (resource == null)
            {
                return NotFound();
            }

            _context.ProtectedResources.Remove(resource);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
