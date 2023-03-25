using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zaitseva_Backend.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Zaitseva_Backend.Models.DTOClass;

namespace Zaitseva_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly TourContext _context;

        public ToursController(TourContext context)
        {
            _context = context;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTour()
        {
          if (_context.Tour == null)
          {
              return NotFound();
          }
            return await _context.Tour.ToListAsync();
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Tour>>> GetHOTTour() 
        { 
            var hottour = await _context.Tour.Where(t =>((t.TourDate - DateTime.Now) < TimeSpan.FromDays(5))).ToListAsync();
            if (hottour == null) 
            {
                return NotFound();
            }
            return hottour;
        }

        [HttpGet]
        [Route("{price}")]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTourByPrice(double price)
        {
            var tours = await _context.Tour.Where(t => t.TourPriсe < price).ToListAsync();
            if (tours == null)
            {
                return NotFound();
            }
            return tours;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetOrderByPrise()
        {
            var tours = await _context.Tour.OrderBy(t => t.TourPriсe).ToListAsync();
            if (tours == null)
            {
                return NotFound();
            }
            return tours;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetSelectPrise(double price)
        {
            var tours = await _context.Tour.Where(t => t.TourPriсe <= price).Select(t => t.TourName).ToListAsync();
            if (tours == null)
            {
                return NotFound();
            }
            return tours;
        }

        //[HttpGet]
        //[Route("{id}")]
        //public async Task<ActionResult<IEnumerable<Tour>>> GetAllAgency(int id)
        //{
        //    var AllAgency = await _context.Agency.Where(a => a.AgencyTourAgencyid == id).ToListAsync();

        //    if (AllAgency == null)
        //    {
        //        return NotFound();
        //    }

        //    return AllAgency;
        //}

        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourDTO>> GetTour(int id)
        {
          if (_context.Tour == null)
          {
              return NotFound();
          }
            var tour = await _context.Tour.FindAsync(id);

            if (tour == null)
            {
                return NotFound();
            }

            TourDTO tourDTO = (TourDTO)tour;

            return tourDTO;
        }

        // PUT: api/Tours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(int id, Tour tour)
        {
            if (id != tour.TourId)
            {
                return BadRequest();
            }

            _context.Entry(tour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
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

        // POST: api/Tours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tour>> PostTour(TourDTO tourDTO)
        {
          if (_context.Tour == null)
          {
              return Problem("Entity set 'TourContext.Tour'  is null.");
          }
            // приведение типов
            Tour tour = new Tour();
            tour = (Tour)tourDTO;

            //var agency = await _context.Agency;

            _context.Tour.Add(tour);
            //agency.Add(tour);
            await _context.SaveChangesAsync();

            
    

            return CreatedAtAction("GetTour", new { id = tour.TourId }, tour);
        }

        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(int id)
        {
            if (_context.Tour == null)
            {
                return NotFound();
            }
            var tour = await _context.Tour.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            _context.Tour.Remove(tour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // удаление тура 
        private bool TourExists(int id)
        {
            return (_context.Tour?.Any(e => e.TourId == id)).GetValueOrDefault();
        }
    }
}
