namespace Zaitseva_Backend.Models
{
    public class Tour
    {
        public int TourId { get; set; }
        public string TourName { get; set; }
        public string TourDescription { get; set; }
        public string TourType {
            get
            {
                return "Hiiiii";
            }
            set { }
        }
        public string TourCountry { get; set;}
        public DateTime TourDate { get; set;}
        public double TourPriсe { get; set;}
        public bool isHOT => (TourDate - DateTime.Now) < TimeSpan.FromDays(5); //?????????????????????????????????????
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
        List<Agency> SelectAgency()
        {
            return AgencyTour;
        }
    }
}
