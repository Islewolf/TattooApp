using System.ComponentModel.DataAnnotations;

namespace TattooApp.Models
{
    public class FlashCard
    {
        public long FlashCardId { get; set; }

        [Required]
        public string Style { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        [Range(0, 10000)]
        public decimal Price { get; set; }
        
        public long BinderId { get; set; }
        public Binder Binder { get; set; } = null!;
    }
}