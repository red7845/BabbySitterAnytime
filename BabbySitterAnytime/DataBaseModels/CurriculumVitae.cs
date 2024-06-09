using System.ComponentModel.DataAnnotations;

namespace BabbySitterAnytime.DataBaseModels
{
    public class CurriculumVitae
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid BabySitterId { get; set; }

        public virtual Babysitter Babysitter { get; set; }
    }
}
