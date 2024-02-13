using BabbySitterAnytime.DataBaseModels;

namespace BabbySitterAnytime.DataViewModels.BabySitterViewModels
{
    public class BabySitterDetailsDataViewModel : BabySitterCreateDataViewModel
    {
        public CurriculumVitae CurriculumVitae { get; set; }
        public double Score { get; set; }
    }
}
