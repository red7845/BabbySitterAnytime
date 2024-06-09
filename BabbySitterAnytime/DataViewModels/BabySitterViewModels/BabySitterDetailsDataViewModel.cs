using BabbySitterAnytime.DataBaseModels;

namespace BabbySitterAnytime.DataViewModels.BabySitterViewModels
{
    public class BabySitterDetailsDataViewModel : BabySitterCreateDataViewModel
    {
        public Guid Id { get; set; }
        public CVDataViewModel CurriculumVitae { get; set; }
        public string PhotoUrl { get; set; }
        public double Score { get; set; }
    }
}
