using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuotesDemoAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagQuote> TagQuotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quote>().HasData(new Quote { Id = 1, Text = "Čím víc sebevrahů, tím míň sebevrahů." });
            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 1, Name = "Anonym", Category = Category.Author });
          
            modelBuilder.Entity<TagQuote>()
                .HasKey(tq => new { tq.TagId, tq.QuoteId });                     
            modelBuilder.Entity<TagQuote>()
                .HasOne(tq => tq.Tag)
                .WithMany(t => t.TagQuotes)
                .HasForeignKey(t => t.TagId);
            modelBuilder.Entity<TagQuote>()
                .HasOne(tq => tq.Quote)
                .WithMany(q => q.TagQuotes)
                .HasForeignKey(q => q.QuoteId);

        }
    }
}
