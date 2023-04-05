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

        public DbSet<Animal> Animals => Set<Animal>();
        public DbSet<Area> Areas => Set<Area>();
        public DbSet<Bundle> Bundles => Set<Bundle>();
        public DbSet<BundleTicket> BundleTickets => Set<BundleTicket>();
        public DbSet<Employee> Employees => Set<Employee>(); // in DB yra RegisteredUsers dalis, neieskot "Employees" lenteles in DB
        public DbSet<Habitat> Habitats => Set<Habitat>();
        public DbSet<RegisteredUser> RegisteredUsers => Set<RegisteredUser>();
        public DbSet<Species> Species => Set<Species>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<WorkTask> WorkTasks => Set<WorkTask>();

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
            modelBuilder.Entity<SpeciesTagRequire>()
            .HasKey(at => new { at.SpeciesId, at.TagId });

            modelBuilder.Entity<SpeciesTagRequire>()
                .HasOne(at => at.Species)
                .WithMany(a => a.TagsRequire)
                .HasForeignKey(at => at.SpeciesId);

            modelBuilder.Entity<SpeciesTagRequire>()
                .HasOne(at => at.Tag)
                .WithMany(t => t.SpeciesRequire)
                .HasForeignKey(at => at.TagId);

            //Jokiu papildomu lauku nera, pridet prie DbSet nebutina
            modelBuilder.Entity<SpeciesTagAvoid>()
                .HasKey(at => new { at.SpeciesId, at.TagId });

            modelBuilder.Entity<SpeciesTagAvoid>()
                .HasOne(at => at.Species)
                .WithMany(a => a.TagsAvoid)
                .HasForeignKey(at => at.SpeciesId);

            modelBuilder.Entity<SpeciesTagAvoid>()
                .HasOne(at => at.Tag)
                .WithMany(t => t.SpeciesAvoid)
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
