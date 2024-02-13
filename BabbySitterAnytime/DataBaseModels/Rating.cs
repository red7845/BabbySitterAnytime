namespace BabbySitterAnytime.DataBaseModels
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public Guid BabysitterId { get; set; }

        public Babysitter Babysitter { get; set; }
    }
}
