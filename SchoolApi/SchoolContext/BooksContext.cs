using Microsoft.EntityFrameworkCore;
using SchoolApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.SchoolContext
{
    public class BooksContext : DbContext
    {

        public DbSet<Book> books { get; set; }
        public DbSet<DeveloperAuthor> developerAuthors { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeveloperAuthor>().HasData(
           new DeveloperAuthor()
            {
                 Id = Guid.Parse("d28888e9-2ba9-473e-a40f-e38cb54f9b35"),
                  FirstName = "Sydney",
                   LastName = "Hadebe"
            }, 
             new DeveloperAuthor()
             {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "C# Developer",
                    LastName = "Back-end Developer"
             }
             );

           modelBuilder.Entity<Book>().HasData(
            new Book()
            {
                 Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), //xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx)
                AuthorId = Guid.Parse("d28888e9-2ba9-473e-a40f-e38cb54f9b35"),
                 Title = "Amazon web services",
                Description = "Backend developers, i wish to work for Amazon South Africa"

            },
            new Book()
            {
                  Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                  AuthorId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                  Title = "Banking Industry",
                  Description ="Microservices and Monolithic"
            }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
