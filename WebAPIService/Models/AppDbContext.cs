using Microsoft.EntityFrameworkCore;

namespace WebAPIService.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "admin@gmail.com", FullName = "ADMIN ONE", Password = "o0o0o" },
                new User { Id = 2, Email = "duc@gmail.com", FullName = "Nguyen Van Duc", Password = "0993337423" },
                new User { Id = 3, Email = "dat@gmail.com", FullName = "Hoang Van Thanh", Password = "123456" }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    Street = null,
                    City = null,
                    State = null,
                    Country = null,
                    User = 1 
                },
                new Address
                {
                    Id = 2,
                    Street = "Cam Doai",
                    City = "Hai Duong",
                    State = "Cam Giang",
                    Country = "Viet Nam",
                    User = 3 
                },
                new Address
                {
                    Id = 3,
                    Street = "Ham Heo",
                    City = "Ha Noi",
                    State = "Soc Son",
                    Country = "Viet Nam",
                    User = 2 
                }
            );
        }
    }
}
