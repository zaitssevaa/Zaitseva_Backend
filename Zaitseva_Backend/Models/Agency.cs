using System.Collections.Generic;
using System.Net;


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
        public void UpdateName(string NewAgencyName)
        {
            AgencyName = NewAgencyName;
        }
        public void UpdateAddress(string NewAddress)
        {
            Address = NewAddress;
        }
        public void UpdateTelephoneNumber(int NewTelephoneNumber)
        {
            TelephoneNumber = NewTelephoneNumber;
        }
        public void AddTours(Tour NeeTours)
        {
            Tours.Add(NeeTours);
        }
        public void DeleteTours(Tour WasteTours)
        {
            Tours.Remove(WasteTours);
        }
        List<Tour> SelectTour()
        {
            return Tours;
           
        }
    }
}
