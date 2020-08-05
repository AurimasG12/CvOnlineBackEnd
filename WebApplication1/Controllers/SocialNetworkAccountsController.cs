using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Authentication;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialNetworkAccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SocialNetworkAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SocialNetworkAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocialNetworkAccounts>>> GetSocialNetworkAccounts()
        {
            return await _context.SocialNetworkAccounts.ToListAsync();
        }

        // GET: api/SocialNetworkAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SocialNetworkAccounts>> GetSocialNetworkAccounts(int id)
        {
            var socialNetworkAccounts = await _context.SocialNetworkAccounts.FindAsync(id);

            if (socialNetworkAccounts == null)
            {
                return NotFound();
            }

            return socialNetworkAccounts;
        }

        // PUT: api/SocialNetworkAccounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocialNetworkAccounts(int id, SocialNetworkAccounts socialNetworkAccounts)
        {
            if (id != socialNetworkAccounts.Id)
            {
                return BadRequest();
            }

            _context.Entry(socialNetworkAccounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialNetworkAccountsExists(id))
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

        // POST: api/SocialNetworkAccounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<SocialNetworkAccounts>> PostSocialNetworkAccounts(SocialNetworkAccounts socialNetworkAccounts)
        {
            _context.SocialNetworkAccounts.Add(socialNetworkAccounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSocialNetworkAccounts", new { id = socialNetworkAccounts.Id }, socialNetworkAccounts);
        }

        // DELETE: api/SocialNetworkAccounts/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<SocialNetworkAccounts>> DeleteSocialNetworkAccounts(int id)
        {
            var socialNetworkAccounts = await _context.SocialNetworkAccounts.FindAsync(id);
            if (socialNetworkAccounts == null)
            {
                return NotFound();
            }

            _context.SocialNetworkAccounts.Remove(socialNetworkAccounts);
            await _context.SaveChangesAsync();

            return socialNetworkAccounts;
        }

        private bool SocialNetworkAccountsExists(int id)
        {
            return _context.SocialNetworkAccounts.Any(e => e.Id == id);
        }
    }
}
