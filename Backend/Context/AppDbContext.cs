using Backend.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{   

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Services)
                .WithOne(s => s.Freelancer)
                .HasForeignKey(s => s.UserId);



            modelBuilder.Entity<User>()
                .HasMany(u => u.Contracts)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);



            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.Buyer)
                .HasForeignKey(r => r.BuyerId);


            modelBuilder.Entity<User>()
                .HasMany(u => u.Proposals)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);


            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Service)
                .WithMany()
                .HasForeignKey(c => c.ServiceId);


            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId);


            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId);


            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);


            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Contract)
                .WithMany()
                .HasForeignKey(p => p.ContractId);
                

                
        }
    }
}
