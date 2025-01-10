using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WorldBankDB.DataAccess.EF.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorldBankDB.DataAccess.EF.Context
{
    public partial class WorldBankDBContext : IdentityDbContext<IdentityUser>
    {
        public WorldBankDBContext()
        {
        }

        public WorldBankDBContext(DbContextOptions<WorldBankDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual new DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=WorldBankDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.ToTable("Accounts", tableBuilder => 
                {
                    tableBuilder.HasCheckConstraint(
                        "CK_Amount_NotBelowZero",
                       sql: "Amount >= 0");
                });

                entity.HasKey(e => e.AccountId);

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RoutingNum).ValueGeneratedOnAdd();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(e => e.UserId)
            });

            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Apt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            //Might need to update properties. 
            modelBuilder.Entity<Cards>(entity => 
            {
                entity.HasKey(e => e.CardId);

                entity.Property(e => e.CardId)
                    .HasColumnName("CardID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CardName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CardNumber).IsRequired();

                entity.Property(e => e.ExpirationDate).IsRequired();

                entity.Property(e => e.SecurityCode).IsRequired();

                entity.Property(e => e.CardAmount)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property<bool>(e => e.IsLocked).IsRequired();

                entity.Property(e => e.CreatedDate).IsRequired();

                entity.Property<bool>(e => e.IsCredit).IsRequired();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                //Foreign Key One-to-One
                entity.HasOne(e => e.Accounts)
                    .WithOne(e => e.Cards)
                    .HasForeignKey<Cards>(e => e.AccountId);
            });

            modelBuilder.Entity<Users>(entity =>   
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmailAddr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName) //updated, it to not be required
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber) //Added
                    .IsRequired()
                    .ValueGeneratedNever();

                entity.Property(e => e.Role) //Added
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("user");

                entity.Property(e => e.Status) //Added
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("active");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
