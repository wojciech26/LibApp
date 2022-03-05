using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<Customer>>();

            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.MembershipTypes.Any())
                    SeedMembershipTypes(context);

                if (!context.Roles.Any())
                    SeedRoles(context);

                if (!context.Customers.Any())
                     SeedCustomers(userManager);

                if (!context.Genre.Any())
                    SeedGenres(context);

                if (!context.Books.Any())
                    SeedBooks(context);

                context.SaveChanges();
            }
        }

        private static void SeedBooks(ApplicationDbContext context)
        {
            context.Books.AddRange(
                new Book
                {
                    GenreId = 8,
                    Name = "The Stormcaller",
                    AuthorName = "Tom LLoyd",
                    ReleaseDate = DateTime.Parse("20/04/2006"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 5
                },
                new Book
                {
                    GenreId = 8,
                    Name = "A Dance with Dragons",
                    AuthorName = "George R.R. Martin",
                    ReleaseDate = DateTime.Parse("03/05/2011"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 12
                },
                new Book
                {
                    GenreId = 1,
                    Name = "The Girl on the Train",
                    AuthorName = "Paula Hawkins",
                    ReleaseDate = DateTime.Parse("02/02/2015"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 11
                },
                new Book
                {
                    GenreId = 7,
                    Name = "The Fault in Our Stars",
                    AuthorName = "John Green",
                    ReleaseDate = DateTime.Parse("17/11/2012"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 6
                },
                new Book
                {
                    GenreId = 1,
                    Name = "Gone Girl",
                    AuthorName = "Filian Flynn",
                    ReleaseDate = DateTime.Parse("03/03/2012"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 9
                },
                new Book
                {
                    GenreId = 1,
                    Name = "Mockingjay",
                    AuthorName = "Suzanne Collins",
                    ReleaseDate = DateTime.Parse("10/10/2010"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                },
                new Book
                {
                    GenreId = 2,
                    Name = "The Lost Symbol",
                    AuthorName = "Dan Brown",
                    ReleaseDate = DateTime.Parse("03/05/2009"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 14
                },
                new Book
                {
                    GenreId = 2,
                    Name = "The Secret",
                    AuthorName = "Rhonda Byrne",
                    ReleaseDate = DateTime.Parse("26/12/2006"),
                    DateAdded = DateTime.Now,
                    NumberInStock = 10
                }
            );
        }

        private static void SeedGenres(ApplicationDbContext context)
        {
            context.Genre.AddRange(
                new Genre
                {
                    Id = 1,
                    Name = "Thriller"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Mystery"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Horror"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Biography"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Criminal"
                },
                new Genre
                {
                    Id = 6,
                    Name = "Sci - Fi"
                },
                new Genre
                {
                    Id = 7,
                    Name = "Romance"
                },
                new Genre
                {
                    Id = 8,
                    Name = "Fantasy"
                    
                }
            );
        }

        private static void SeedCustomers(UserManager<Customer> userManager)
        {
            var hasher = new PasswordHasher<Customer>();

            var customer1 = new Customer
            {
                Name = "Wojciech Wasikiewicz",
                Email = "wojciech2694@gmail.com",
                NormalizedEmail = "wojciech2694@gmail.com",
                UserName = "wojciech2694@gmail.com",
                NormalizedUserName = "wojciech2694@gmail.com",
                MembershipTypeId = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "zaq12wsx")
            };

  
            userManager.CreateAsync(customer1).Wait();
            userManager.AddToRoleAsync(customer1, "owner").Wait();

            var customer2 = new Customer
            {
                Name = "Jan Kowalski",
                Email = "jkowalski@gmail.com",
                NormalizedEmail = "jkowalski@gmail.com",
                UserName = "jkowalski@gmail.com",
                NormalizedUserName = "jkowalski@gmail.com",
                MembershipTypeId = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "qwertyuiop")
            };


            userManager.CreateAsync(customer2).Wait();
            userManager.AddToRoleAsync(customer2, "storemanager").Wait();

            var customer3 = new Customer
            {
                Name = "Zbigniew Nowak",
                Email = "znowak@gmail.com",
                NormalizedEmail = "znowak@gmail.com",
                UserName = "znowak@gmail.com",
                NormalizedUserName = "znowak@gmail.com",
                MembershipTypeId = 1,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "asdfgh12")
            };


            userManager.CreateAsync(customer3).Wait();
            userManager.AddToRoleAsync(customer3, "user").Wait();
        }

        private static void SeedRoles(ApplicationDbContext context)
        {
            context.Roles.AddRange(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "user"
                },
                
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Owner",
                    NormalizedName = "owner"
                },

                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "StoreManager",
                    NormalizedName = "storemanager"
                }
            );

            context.SaveChanges();
        }

        private static void SeedMembershipTypes(ApplicationDbContext context)
        {
            context.MembershipTypes.AddRange(
                new MembershipType
                {
                    Id = 1,
                    Name = "Pay as You Go",
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0
                },
                new MembershipType
                {
                    Id = 2,
                    Name = "Monthly",
                    SignUpFee = 30,
                    DurationInMonths = 1,
                    DiscountRate = 10
                },
                new MembershipType
                {
                    Id = 3,
                    Name = "Quaterly",
                    SignUpFee = 90,
                    DurationInMonths = 3,
                    DiscountRate = 15
                },
                new MembershipType
                {
                    Id = 4,
                    Name = "Yearly",
                    SignUpFee = 300,
                    DurationInMonths = 12,
                    DiscountRate = 20
                }
            );

            context.SaveChanges();
        }
    }
}