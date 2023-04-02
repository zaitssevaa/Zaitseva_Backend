using System.Collections.Generic;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Zaitseva_Backend.Models
{
    public class Agency
    {
        public int AgencyId { get; set; }
        public string AgencyName { get; set;}
        public string Address { get; set;}
        public int TelephoneNumber { get; set;}
        public List<Tour> Tours { get; set; } // list? - 

        public void CreateAgencyy(string Name, string Address, int Phone)
        {
            AgencyName = Name;
            this.Address = Address;
            TelephoneNumber = Phone;
        }
        public Agency()
        {
            List<Tour> Tours = new List<Tour>();
        }
        public void AddTours(Tour NewTours)
        {
            if (Tours == null)
            Tours = new List<Tour>();
            Tours.Add(NewTours);
        }
        public void DeleteTours(Tour WasteTours)
        {
            Tours.Remove(WasteTours);
        }
        List<Tour> SelectTour()
        {
            return Tours;
        }

        public static explicit operator Agency(DTOClass.AgencyDTO agencydto)
        {
            Agency agency = new Agency();
            agency.AgencyId = agencydto.AgencyId;
            agency.AgencyName = agencydto.AgencyName;
            agency.TelephoneNumber = agencydto.TelephoneNumber; 
            agency.Address = agencydto.Address;
            List<Tour> Tours  = new List<Tour>();
            return agency;
        }
    }
}
