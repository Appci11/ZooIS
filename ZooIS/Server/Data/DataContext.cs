using Microsoft.EntityFrameworkCore;
using System.Xml;
using ZooIS.Server.TutorialClasses;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RegisteredUser> RegisteredUsers => Set<RegisteredUser>();
        public DbSet<UserSettings> UserSettings => Set<UserSettings>();
        public DbSet<TBundle> TBundles => Set<TBundle>();
        public DbSet<Ticket> Tickets=> Set<Ticket>();
        public DbSet<TBundleTicket> BundleTickets => Set<TBundleTicket>();

        // for tutorial purposes
        //public DbSet<User> Users { get; set; }
        //public DbSet<Character> Characters { get; set; }
        //public DbSet<Weapon> Weapons { get; set; }
        //public DbSet<Skill> Skills { get; set; }

        //public DbSet<Au> Aus { get; set; }
        //public DbSet<Meu> Meus { get; set; }
        //public DbSet<AuMeu> AuMeus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSettings>()
              .Property(e => e.Id)
              .ValueGeneratedNever();

            modelBuilder.Entity<TBundleTicket>()
                        .HasKey(bt => new { bt.TBundleId, bt.TicketId });

            modelBuilder.Entity<TBundleTicket>()
                .HasOne(bt => bt.TBundle)
                .WithMany(b => b.TBundleTickets)
                .HasForeignKey(bt => bt.TBundleId);

            modelBuilder.Entity<TBundleTicket>()
                .HasOne(bt => bt.Ticket)
                .WithMany(t => t.TBundleTickets)
                .HasForeignKey(bt => bt.TicketId);


            //tutorial for n x n
            //modelBuilder.Entity<AuMeu>()
            //            .HasKey(am => new { am.AuId, am.MeuId });
            //modelBuilder.Entity<AuMeu>()
            //    .HasOne(am => am.Au)
            //    .WithMany(a => a.AuMeus)
            //    .HasForeignKey(am => am.AuId);
            //modelBuilder.Entity<AuMeu>()
            //    .HasOne(am => am.Meu)
            //    .WithMany(m => m.AuMeus)
            //    .HasForeignKey(am => am.MeuId);
        }
    }
}
