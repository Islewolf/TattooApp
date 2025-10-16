using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TattooApp.Models
{
    public class Appointment
    {
        public long AppointmentId { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Client Email")]
        public string ClientEmail { get; set; } = string.Empty;
        
        [Display(Name = "Client Phone")]
        public string? ClientPhone { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [Range(1, 360, ErrorMessage = "Enter between 1 and 360 minutes")]
        [Display(Name = "Duration (minutes)")]
        public int DurationMinutes { get; set; }

        [Display(Name = "Tattoo Description")]
        public string? TattooDescription { get; set; }

        [Required(ErrorMessage = "Please select an artist")]
        [Display(Name = "Artist")]
        public long ArtistId { get; set; }

        public Artist Artist { get; set; } = null!;

    }
}
