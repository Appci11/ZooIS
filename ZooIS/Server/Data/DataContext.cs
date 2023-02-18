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
        public DbSet<Bundle> Bundles => Set<Bundle>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<BundleTicket> BundleTickets => Set<BundleTicket>();
        public DbSet<Animal> Animals => Set<Animal>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Habitat> Habitats => Set<Habitat>();
        public DbSet<Area> Areas => Set<Area>();
        public DbSet<Employee> Employees => Set<Employee>();

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

            modelBuilder.Entity<BundleTicket>()
                        .HasKey(bt => new { bt.BundleId, bt.TicketId });

            modelBuilder.Entity<BundleTicket>()
                .HasOne(bt => bt.Bundle)
                .WithMany(b => b.BundleTickets)
                .HasForeignKey(bt => bt.BundleId);

            modelBuilder.Entity<BundleTicket>()
                .HasOne(bt => bt.Ticket)
                .WithMany(t => t.BundleTickets)
                .HasForeignKey(bt => bt.TicketId);

            //Jokiu papildomu lauku nera, pridet prie DbSet nebutina
            modelBuilder.Entity<AnimalTagRequire>()
            .HasKey(at => new { at.AnimalId, at.TagId });

            modelBuilder.Entity<AnimalTagRequire>()
                .HasOne(at => at.Animal)
                .WithMany(a => a.TagsRequire)
                .HasForeignKey(at => at.AnimalId);

            modelBuilder.Entity<AnimalTagRequire>()
                .HasOne(at => at.Tag)
                .WithMany(t => t.AnimalsRequire)
                .HasForeignKey(at => at.TagId);

            //Jokiu papildomu lauku nera, pridet prie DbSet nebutina
            modelBuilder.Entity<AnimalTagAvoid>()
                .HasKey(at => new { at.AnimalId, at.TagId });

            modelBuilder.Entity<AnimalTagAvoid>()
                .HasOne(at => at.Animal)
                .WithMany(a => a.TagsAvoid)
                .HasForeignKey(at => at.AnimalId);

            modelBuilder.Entity<AnimalTagAvoid>()
                .HasOne(at => at.Tag)
                .WithMany(t => t.AnimalsAvoid)
                .HasForeignKey(at => at.TagId);



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
