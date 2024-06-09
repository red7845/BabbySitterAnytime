namespace BabbySitterAnytime.DataBaseModels
{
    public class Area
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<BabysitterArea> Babysitters { get; set; } 
    }
}
