using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectBackend.Infrastructure.Models;

namespace ProjectBackend.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<BankUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<DebitCard> DebitCards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.FromAccount)
                .WithMany(a => a.SentTransactions)
                .HasForeignKey(t => t.FromAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.ToAccount)
                .WithMany(a => a.ReceivedTransactions)
                .HasForeignKey(t => t.ToAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DebitCard>()
                .HasOne(dc => dc.BankAccount)
                .WithMany(ba => ba.DebitCards)
                .HasForeignKey(dc => dc.BankAccountId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<DebitCard>()
                .HasOne(ow => ow.Owner)
                .WithMany(u => u.DebitCards)
                .HasForeignKey(ow => ow.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BankAccount>()
                .HasOne(ba => ba.BankUser)
                .WithMany(u => u.BankAccounts)
                .HasForeignKey(ba => ba.BankUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
