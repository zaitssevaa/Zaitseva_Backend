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
        //public bool isHOT => (TourDate - DateTime.Now) < TimeSpan.FromDays(5); //?????????????????????????????????????
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
        public void AddAgency(Agency Agency)
        {
            AgencyTour.Add(Agency);
        }

        public void DeleteAgency(Agency Agency)
        {
            AgencyTour.Remove(Agency);
        }

        public void UpdateName(string NewTourName)
        {
            TourName = NewTourName;
        }

        public void UpdateData (DateTime NewData)
        {
            TourDate = NewData;
        }

        public void UpdatePrice (double NewTourPrice)
        {
            TourPriсe = NewTourPrice;
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
           // tour.isHOT = tourdto.isHOT;
            List<Agency> agencies = new List<Agency>();
            return tour;
        }
    }
}
