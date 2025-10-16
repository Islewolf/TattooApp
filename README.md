# Tattoo Shop Management System

ASP.NET Core project for managing a tattoo shop. Made for the ASP.NET Core course exam.

## What it does

This is a simple web app where you can manage artists and appointments for a tattoo shop. It has:
- A dashboard that shows today's appointments and upcoming ones
- Artist management (add, edit, delete, view artists)
- Appointment booking system
- Sample data in Faroese

## How to run it

1. Make sure you have .NET 7 SDK and SQL Server installed

2. Open terminal in the project folder and run:
   ```
   dotnet ef database update
   dotnet run
   ```

3. Open browser and go to `https://localhost:5001`

That's it! The database will be created automatically with some sample data.

## What I learned / used

This project covers the main topics from the course:

**Controllers & Actions:**
- HomeController for the dashboard
- ArtistController with full CRUD operations
- AppointmentController for booking management

**Models & Database:**
- Artist, Appointment, Specialty models
- Entity Framework Core with SQL Server
- Relationships between models (one-to-many, many-to-many)
- Migrations and seed data

**Views & Forms:**
- Razor views with layouts
- Form binding and validation
- Bootstrap for styling
- Client and server-side validation using data annotations

## Database

The app uses these main tables:
- Artists (with name, email, phone, role)
- Appointments (with client info, date/time, artist)
- Specialties (tattoo styles like Traditional, Realism, etc.)
- Many-to-many relationship between Artists and Specialties

## Notes

Based on the example from "Pro ASP.NET Core 7" by Adam Freeman (Chapter 31), but refactored for a tattoo shop instead of the original product catalog.

