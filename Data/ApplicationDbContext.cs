using Cours.Models;
using Microsoft.EntityFrameworkCore;

namespace Cours.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Dettes)
            .WithOne(d => d.Client)
            .HasForeignKey(d => d.ClientId);

        modelBuilder.Entity<User>()
         .HasOne(user => user.Client)
         .WithOne(client => client.User)
         .HasForeignKey<Client>(c => c.UserId)
         .OnDelete(DeleteBehavior.Cascade)
         .IsRequired(false);

        modelBuilder.Entity<Paiement>()
        .HasOne(p => p.Dette)
        .WithMany(d => d.Paiements)
        .HasForeignKey(p => p.DetteId);

    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Dette> Dettes { get; set; }
    public DbSet<Paiement> Paiements { get; set; }




}