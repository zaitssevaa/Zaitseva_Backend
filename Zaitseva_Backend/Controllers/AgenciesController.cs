using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Zaitseva_Backend.Models;
using static Zaitseva_Backend.Models.DTOClass;
//using Zaitseva_Backend.Models.iterfacec;

namespace Zaitseva_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    //[ApiController]

    public class AgenciesController : ControllerBase
    {

        private readonly TourContext _context;

        public AgenciesController(TourContext context)
        {
            _context = context;
        }

        // GET: api/Agencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agency>>> GetAllAgency()
        {
            if (_context.Agency == null)
            {
                return NotFound();
            }
            return await _context.Agency.ToListAsync();
        }

        // GET: api/Agencies/5
        [HttpGet("Nmae")]
        //[Authorize]
        public async Task<ActionResult<AgencyDTO>> GetAgency(string Name)
        { 
            if (_context.Agency == null)
            {
                return NotFound();
            }
            var agency = await _context.Agency.Where(a => a.AgencyName.Contains(Name)).FirstOrDefaultAsync();

            if (agency == null)
            {
                return NotFound();
            }
            AgencyDTO agencyDTO = (AgencyDTO)agency;

            return agencyDTO;
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Agency>>> GetAgencyTour(int id)
        {
            if (_context.Agency == null)
            {
                return NotFound();
            }
            var agency = _context.Agency.Include(t => t.Tours).Where(a => a.AgencyId == id).ToListAsync();
            return await agency;
        }


        [HttpGet("{id},Country")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Agency>>> AgencyCountry(int id, string country)
        {
            if (_context.Agency == null)
            {
                return NotFound();
            }
            var agency = _context.Agency.Include(t => t.Tours.Where(t => t.TourCountry == country)).Where(a => a.AgencyId == id).ToListAsync();
            //foreach (tour in agency.Tours)
            //var tours = agency.Tours.Where(t => t.TourCountry == CountryName).ToListAsync();
            return await agency;
        }


        [HttpGet("{id},Country")]
        //[Authorize]

        public async Task<ActionResult<IEnumerable<string>>> GetAgencylocal(string address)
        {
            var agency = await _context.Agency.Where(a => a.Address.StartsWith(address)).Select(a => a.AgencyName).ToListAsync();
            if (agency == null)
            {
                return NotFound();
            }
            return agency;
        }


        [HttpPut("{idagency}")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<IActionResult>>> PutTourAddAgency(int idagency, List<int> idtours)
        {
            Agency agency = _context.Agency.Where(a => a.AgencyId== idagency).FirstOrDefault();
            var touragency = _context.Agency.Include(a => a.Tours).FirstOrDefault(a => a.AgencyId == idagency);
            foreach (int idtour in idtours)
            {
                if (touragency.Tours.Any(t => t.TourId == idtour))
                    continue;
                else
                {
                    Tour tour = _context.Tour.Where(t => t.TourId == idtour).FirstOrDefault();
                    if (tour == null)
                    {
                        return NotFound();
                    }
                    tour.AddAgency(agency);
                }
            }
            // var agency = await _context.Agency.(a => a.idagency.address).ToListAsync();
            await _context.SaveChangesAsync();
            if (agency == null)
            {
                return NotFound();
            }
            else 
            return NoContent();
        }

        [HttpPut("{idagency}")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<IActionResult>>> PutTourDeleteAgency(int idagency, List<int> idtours)
        {
            Agency agency = _context.Agency.Where(a => a.AgencyId == idagency).FirstOrDefault();
            foreach (int idtour in idtours)
            {
                Tour tour = _context.Tour.Include(a => a.AgencyTour).Where(t => t.TourId == idtour).FirstOrDefault();
                if (tour == null)
                {
                    return NotFound();
                }
                agency.DeleteTours(tour);
            }
            // var agency = await _context.Agency.(a => a.idagency.address).ToListAsync();
            await _context.SaveChangesAsync();
            if (agency == null)
            {
                return NotFound();
            }
            else
                return NoContent();
        }

        // PUT: api/Agencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
       //[Authorize(Roles = "admin")]
        public async Task<IActionResult> PutAgency(int id, Agency agency)
        {
            if (id != agency.AgencyId)
            {
                return BadRequest();
            }

            _context.Entry(agency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgencyExists(id))
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

        // POST: api/Agencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<Agency>> PostAgency(AgencyDTO agencyDTO)
        {
            if (_context.Agency == null)
            {
                return Problem("Entity set 'TourContext.Agency'  is null.");
            }
            // приведение типов
            Agency agency = new Agency();
            agency = (Agency)agencyDTO;

            _context.Agency.Add(agency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgency", new { id = agency.AgencyId }, agency);
        }

        // DELETE: api/Agencies/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteAgency(int id)
        {
            if (_context.Agency == null)
            {
                return NotFound();
            }
            var agency = await _context.Agency.FindAsync(id);
            if (agency == null)
            {
                return NotFound();
            }

            _context.Agency.Remove(agency);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgencyExists(int id)
        {
            return (_context.Agency?.Any(e => e.AgencyId == id)).GetValueOrDefault();
        }
    }
}
