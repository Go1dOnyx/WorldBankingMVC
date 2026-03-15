using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WorldBankDB.DataAccess.EF.Models;
using Microsoft.AspNetCore.Identity;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorldBankDB.DataAccess.EF.Context
{
    public partial class WorldBankDBContext : IdentityDbContext<Users, IdentityRole<Guid>, Guid>
    {
        public WorldBankDBContext()
        {
        }

        public WorldBankDBContext(DbContextOptions<WorldBankDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankAccounts> BankAccounts { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=WorldBankDB;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //optional: renaming the default Identity tables to custom names
            builder.Entity<IdentityRole<Guid>>().ToTable("Roles");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

            //Custom Entity Models
            builder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("UserID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasConversion<int>() //allow us to store enum as an integer
                    .HasDefaultValue(1);

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasDefaultValueSql("GETUTCDATE()");

                //Might need to delete or update this
                entity.HasMany(e => e.BankAccounts)
                    .WithOne()
                    .HasForeignKey(a => a.UserId);
            });

            builder.Entity<BankAccounts>(entity =>
            {
                entity.ToTable("Accounts", tableBuilder => 
                {
                    tableBuilder.HasCheckConstraint(
                        "CK_Amount_NotBelowZero",
                       sql: "Amount >= 0");
                });

                entity.HasKey(e => e.BankAccountId);

                entity.Property(e => e.BankAccountId)
                    .HasColumnName("BankAccountID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccountNum)
                    .UseIdentityColumn(seed: 4701755112279000, increment: 1)
                    .IsRequired();

                entity.Property(e => e.AccountBalance).HasColumnType("decimal(18, 2)"); 

                entity.Property(e => e.RoutingNum)
                    .HasDefaultValue(121110001)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.BankAccounts)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Transaction>(entity => 
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.Type).IsRequired();

                entity.Property(e => e.TransactionDate).IsRequired();

                entity.HasOne(t => t.BankAccount)
                    .WithMany(e => e.Transactions)
                    .HasForeignKey(t => t.BankAccountId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder builder);
    }
}