namespace BabbySitterAnytime.DataBaseModels
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
        public Guid BabysitterId { get; set; }

        public virtual Babysitter Babysitter { get; set; }
    }
}
