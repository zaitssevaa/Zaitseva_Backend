using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Zaitseva_Backend.Models.DTOClass;

namespace Zaitseva_Backend.Models
{
    public class DTOClass
    {
        public class AgencyDTO
        {
            public int AgencyId { get; set; }
            public string AgencyName { get; set; }
            public string Address { get; set; }
            public int TelephoneNumber { get; set; }

            public static explicit operator AgencyDTO(Agency agency)
            {
                AgencyDTO agency1 = new AgencyDTO();
                agency1.AgencyId = agency.AgencyId;
                agency1.AgencyName = agency.AgencyName;
                agency1.Address = agency.Address;
                agency1.TelephoneNumber= agency.TelephoneNumber;
                return agency1;
               
            }

        }

        public class TourDTO
        {
            public int TourId { get; set; }
            public string TourName { get; set; }
            public string TourDescription { get; set; }
            public string TourType
            {
                get
                {
                    return "Hiiiii";
                }
                set { }
            }
            public string TourCountry { get; set; }
            public DateTime TourDate { get; set; }
            public double TourPriсe { get; set; }
            public bool isHOT => (TourDate - DateTime.Now) < TimeSpan.FromDays(5); //?????????????????????????????????????

            public static explicit operator TourDTO(Tour tour) {
                TourDTO tour1 = new TourDTO();
                tour1.TourId = tour.TourId;
                tour1.TourName = tour.TourName;
                tour1.TourPriсe = tour.TourPriсe;
                tour1.TourDate = tour.TourDate;
                tour1.TourDescription = tour.TourDescription;
                return tour1;
            }
        }
    }
}
