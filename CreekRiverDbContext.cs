using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
        new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
        new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
        new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
        new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });

        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
            new Campsite {Id = 2, CampsiteTypeId = 1, Nickname = "Knockturn Alley", ImageUrl="https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiLUjCh4wWXqqhXmG7C4cNc7fetwLRnRYkAW9xNg-WC8rHFo2gxTgp1dYNwtmO_uJur3lNjRvIIU0IjjuD6mnVYNMVD01l1dw6QK-jvXpPYxLA5Zkh0IHebAlcMCEUz0OoEEOdHD4A3bpu_/s1600/001.JPG"},
            new Campsite {Id = 3, CampsiteTypeId = 3, Nickname = "Chimney Falls", ImageUrl="https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/307f17b7-52d4-4f3f-a171-d77fe66dba18/deqlqb-95f9713c-e751-49cf-866c-f4292325dc2d.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzMwN2YxN2I3LTUyZDQtNGYzZi1hMTcxLWQ3N2ZlNjZkYmExOFwvZGVxbHFiLTk1Zjk3MTNjLWU3NTEtNDljZi04NjZjLWY0MjkyMzI1ZGMyZC5qcGcifV1dLCJhdWQiOlsidXJuOnNlcnZpY2U6ZmlsZS5kb3dubG9hZCJdfQ.C7hm0-EOyf0gPxPl0MWvzx-xP1B2NUg-4cInu8Yd53Y"},
            new Campsite {Id = 4, CampsiteTypeId = 2, Nickname = "Scarborough", ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSXRhvLOQifx3Md17B5Mn3xz7QqN1nj7WmJeQ&s"},
            new Campsite {Id = 5, CampsiteTypeId = 2, Nickname = "Muddy Landing", ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2GazB75A_1GYpIjwi9KF_3jijPgWV6935mg&s" },
            new Campsite {Id = 6, CampsiteTypeId = 4, Nickname = "Haliburton's Coat", ImageUrl="https://d9-wret.s3.us-west-2.amazonaws.com/assets/palladium/production/s3fs-public/styles/side_image/public/vhp_img2997.jpg?itok=nXc98AQF" },
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile{Id = 1, FirstName = "Victoria", LastName = "Washington", Email = "washingmachinevictory@gmail.com"},
            new UserProfile {Id = 2, FirstName = "Catalog", LastName = "Jenkins", Email = "summercatalog@yahoo.com"}
        });

        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation {Id = 1, CampsiteId = 3, UserProfileId = 2, CheckinDate = new DateTime(2024, 08, 29), CheckoutDate = new DateTime(2024, 09, 03)}
        });
    }
}