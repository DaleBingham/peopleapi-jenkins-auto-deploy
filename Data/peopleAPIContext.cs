using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using peopleapi.Models;

namespace peopleapi.Data
{
    public partial class peopleAPIContext : DbContext
    {
        
        public peopleAPIContext(DbContextOptions<peopleAPIContext> options)
            : base(options)
        {  }

        public virtual DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("peopleapi-context"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.LastName)
                    .HasName("IX_Person_lastname");

                entity.HasIndex(e => e.PersonId)
                    .HasName("IX_Person");

                entity.HasIndex(e => e.State)
                    .HasName("IX_Person_state");

                entity.Property(e => e.PersonId)
                    .HasColumnName("personId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CellPhone)
                    .HasColumnName("cellPhone")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Linkedin)
                    .HasColumnName("linkedin")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middleName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Twitter)
                    .HasColumnName("twitter")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WorkPhone)
                    .HasColumnName("workPhone")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasColumnName("zipCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
