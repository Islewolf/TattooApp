using System.ComponentModel.DataAnnotations;
using TattooApp.Validation;

namespace TattooApp.Models
{
    public class Artist
    {

        public long ArtistId { get; set; }

        [Display(Name = "Role")]
        public string? Role { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; } = string.Empty;

        public ICollection<Binder> Binders { get; set; } = new List<Binder>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
    }
}