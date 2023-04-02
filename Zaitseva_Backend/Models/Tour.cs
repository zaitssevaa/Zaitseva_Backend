namespace Zaitseva_Backend.Models
{
    public class Tour
    {
        public int TourId { get; set; }
        public string TourName { get; set; }
        public string TourDescription { get; set; }
        public string TourType { get; set; }
        public string TourCountry { get; set;}
        public DateTime TourDate { get; set;}
        public double TourPriсe { get; set;}
        public List<Agency> AgencyTour { get; set;}

        public void CreateTour(string Name, string Description, string TypeTour, string Country, DateTime Date, double Priсe)
        {
            TourName = Name;
            TourDescription = Description;
            TourType = TypeTour;
            TourCountry = Country;
            TourDate = Date;
            TourPriсe = Priсe;
        }
        public void AddAgency(Agency NewAgenct)
        {
            if (AgencyTour == null)
                AgencyTour = new List<Agency>();
            AgencyTour.Add(NewAgenct);
            //AgencyTour.Add(Agency);
        }

        public void DeleteAgency(Agency Agency)
        {
            AgencyTour.Remove(Agency);
        }

        public bool IsHot()
        {
            if ((TourDate - DateTime.Now) < TimeSpan.FromDays(5)) 
            {
                return true;
            }
            return false;
        }

        List<Agency> SelectAgency()
        {
            return AgencyTour;
        }
        
       // List

        public static explicit operator Tour(DTOClass.TourDTO tourdto)
        {
            Tour tour = new Tour();
            tour.TourId = tourdto.TourId;
            tour.TourName = tourdto.TourName;
            tour.TourType = tourdto.TourType;
            tour.TourDescription = tourdto.TourDescription;
            tour.TourCountry = tourdto.TourCountry;
            tour.TourDate = tourdto.TourDate;
            tour.TourPriсe = tourdto.TourPriсe;
            List<Agency> agencies = new List<Agency>();
            return tour;
        }
    }
}
