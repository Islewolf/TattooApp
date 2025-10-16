using System.ComponentModel.DataAnnotations;

namespace TattooApp.Models
{
    public class Specialty
    {
        public long SpecialtyId { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        public ICollection<Artist> Artists { get; set; } = new List<Artist>();
    }
}