using System.ComponentModel.DataAnnotations;

namespace TattooApp.Models
{
    public class Binder
    {
        public long BinderId { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public long ArtistId { get; set; }
        public Artist Artist { get; set; } = null!;

        public ICollection<FlashCard> FlashCards { get; set; } = new List<FlashCard>();
    }
}