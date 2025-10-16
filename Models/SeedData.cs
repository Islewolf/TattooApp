using Microsoft.EntityFrameworkCore;

namespace TattooApp.Models {
    public static class SeedData {

        public static void SeedDatabase(DataContext context) {
            context.Database.Migrate();
            if (context.Artists.Count() == 0 
                    && context.Appointments.Count() == 0
                    && context.Specialties.Count() == 0) {

                // Create specialties
                Specialty traditional = new Specialty { Name = "Traditional", Description = "Klassiskur tattovering stílur" };
                Specialty realism = new Specialty { Name = "Realism", Description = "Veruleikalíkur myndir og portrettir" };
                Specialty japanese = new Specialty { Name = "Japanese", Description = "Japanskur listastílur við drakar og blómur" };
                Specialty watercolor = new Specialty { Name = "Watercolor", Description = "Vatnlitur" };

                context.Specialties.AddRange(traditional, realism, japanese, watercolor);
                
                // Create artists
                Artist artist1 = new Artist 
                { 
                    Name = "Jóannes Mortensen", 
                    Email = "joannes@tattoo.fo",
                    Phone = "+298 214567",
                    Role = "Senior Artist"
                };
                
                Artist artist2 = new Artist 
                { 
                    Name = "Anna Sólstein", 
                    Email = "anna@tattoo.fo",
                    Phone = "+298 318294",
                    Role = "Master Artist"
                };
                
                Artist artist3 = new Artist 
                { 
                    Name = "Símun Poulsen", 
                    Email = "simun@tattoo.fo",
                    Phone = "+298 551238",
                    Role = "Artist"
                };

                context.Artists.AddRange(artist1, artist2, artist3);
                context.SaveChanges();

                // Assign specialties to artists
                artist1.Specialties.Add(traditional);
                artist1.Specialties.Add(japanese);
                artist2.Specialties.Add(realism);
                artist2.Specialties.Add(watercolor);
                artist3.Specialties.Add(traditional);
                artist3.Specialties.Add(realism);

                // Create appointments
                context.Appointments.AddRange(
                    new Appointment 
                    {  
                        ClientName = "Hákun Andreasen", 
                        ClientEmail = "hakun@olivant.fo",
                        ClientPhone = "+298 224589",
                        AppointmentDate = DateTime.Now.AddDays(3),
                        DurationMinutes = 120,
                        TattooDescription = "Dreki á baki við norrønum mynstri",
                        ArtistId = artist1.ArtistId
                    },
                    new Appointment 
                    {  
                        ClientName = "Rannvá Jacobsen", 
                        ClientEmail = "rannva@post.fo",
                        ClientPhone = "+298 416723",
                        AppointmentDate = DateTime.Now.AddDays(5),
                        DurationMinutes = 90,
                        TattooDescription = "Mynd av ommu við blómum",
                        ArtistId = artist2.ArtistId
                    },
                    new Appointment 
                    {  
                        ClientName = "Óli Hansen", 
                        ClientEmail = "oli@gmail.com",
                        ClientPhone = "+298 289144",
                        AppointmentDate = DateTime.Now.AddDays(7),
                        DurationMinutes = 60,
                        TattooDescription = "Lítil vatnlitur blóma á hándlig",
                        ArtistId = artist2.ArtistId
                    },
                    new Appointment 
                    {  
                        ClientName = "Malan Petersen", 
                        ClientEmail = "malan@olivant.fo",
                        ClientPhone = "+298 593312",
                        AppointmentDate = DateTime.Now.AddDays(1),
                        DurationMinutes = 180,
                        TattooDescription = "Fullur ermi við havfrúgvum og skipum",
                        ArtistId = artist3.ArtistId
                    }
                );
                
                context.SaveChanges();
            }
        }
    }
}
