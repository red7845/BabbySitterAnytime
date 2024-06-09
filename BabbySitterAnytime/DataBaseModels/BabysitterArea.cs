namespace BabbySitterAnytime.DataBaseModels
{
    public class BabysitterArea
    {
        public Guid BabysitterId { get; set; }
        public virtual Babysitter Babysitter { get; set; }

        public Guid AreaId { get; set; }
        public virtual Area Area { get; set; }
    }
}
