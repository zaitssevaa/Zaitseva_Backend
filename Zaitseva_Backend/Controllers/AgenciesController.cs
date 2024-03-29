﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Zaitseva_Backend.Models;
using static Zaitseva_Backend.Models.DTOClass;
//using Zaitseva_Backend.Models.iterfacec;

namespace Zaitseva_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class AgenciesController : ControllerBase
    {
        //private readonly IAllTour _allTour;
        //private readonly IAgencie _allAgencie;

        //public AgenciesController(IAllTour IALLTour, IAgencie IAgen)
        //{
        //    _allTour = IALLTour;
        //    _allAgencie = IAgen;
        //}

        //public ViewResult List(){
        //    var tour = _allTour.AllTours;
        //    return View(tour);
        //}

        //private ViewResult View(IEnumerable<Tour> tour)
        //{
        //    throw new NotImplementedException();
        //}
        private readonly TourContext _context;

        public AgenciesController(TourContext context)
        {
            _context = context;
        }

        // GET: api/Agencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agency>>> GetAgency()
        {
            if (_context.Agency == null)
            {
                return NotFound();
            }
            return await _context.Agency.ToListAsync();
        }

        // GET: api/Agencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgencyDTO>> GetAgency(int id)
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
            AgencyDTO agencyDTO = (AgencyDTO)agency;

            return agencyDTO;
        }


        // PUT: api/Agencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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
        public async Task<ActionResult<Agency>> PostAgency(Agency agency)
        {
            if (_context.Agency == null)
            {
                return Problem("Entity set 'TourContext.Agency'  is null.");
            }
            _context.Agency.Add(agency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgency", new { id = agency.AgencyId }, agency);
        }

        // DELETE: api/Agencies/5
        [HttpDelete("{id}")]
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
