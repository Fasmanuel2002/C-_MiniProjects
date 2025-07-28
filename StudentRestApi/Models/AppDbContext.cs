using Microsoft.EntityFrameworkCore;

namespace StudentRestApi.Models
{
    public class AppDbContext : DbContext
    {
          public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
           {
           }

           public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Send Student Table
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    FirstName = "Ernesto",
                    LastName = "Salmantino",
                    Email = "ernestoSalmantino@gmail.com",
                    DateOfBirth = new DateTime(1992, 8, 14),
                    DepartmentId = 1,
                    Gender = Gender.Male,
                    PhotoPath = "Images/Ernesto.png"
                }

                );

           

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 2,
                    FirstName = "Debora",
                    LastName = "Fuchibol",
                    Email = "DeboraSalmantino@gmail.com",
                    DateOfBirth = new DateTime(1994, 6, 16),
                    DepartmentId = 1,
                    Gender = Gender.Female,
                    PhotoPath = "Images/Debora.png"
                }

                );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 3,
                    FirstName = "Javi",
                    LastName = "Avila",
                    Email = "JaviAvila@gmail.com",
                    DateOfBirth = new DateTime(1970, 8, 14),
                    DepartmentId = 1,
                    Gender = Gender.Male,
                    PhotoPath = "Images/Javi.png"
                }

                );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 4,
                    FirstName = "Noelia",
                    LastName = "Salmantina",
                    Email = "NoeliaSalmantina@gmail.com",
                    DateOfBirth = new DateTime(1992, 8, 14),
                    Gender = Gender.Female,
                    PhotoPath = "Images/Noelia.png"
                }

                );
            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   StudentId = 5,
                   FirstName = "Luis",
                   LastName = "Salmantino",
                   Email = "LuisSalmantino@gmail.com",
                   DateOfBirth = new DateTime(1990, 8, 14),
                   DepartmentId = 1,
                   Gender = Gender.Male,
                   PhotoPath = "Images/Luis.png"
               }

               );


        }
    }
}
