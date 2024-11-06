using Microsoft.EntityFrameworkCore;
using LaverieEntities.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Laverie.Infrastructure.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Proprietaire> Proprietaires { get; set; }
        public DbSet<Laveries> Laveries { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Cycle> Cycles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proprietaire>(entity =>
            {
                entity.HasKey(e => e._CIN);
                entity.Property(e => e._Surname).HasColumnName("Surnom");
                entity.HasMany(p => p.propLaverie)
                      .WithOne(p => p.Proprietaire)
                      .HasForeignKey(v => v.ProprietaireCIN)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Laveries>(entity =>
            {
                entity.HasKey(l => l.IdLaverie);
                entity.Property(l => l.CapaciteLaverie).HasColumnName("Capacite");
                entity.Property(l => l.AddresseLaverie).HasColumnName("Addresse");
                entity.HasMany(p => p.machinesLaverie)
                      .WithOne(p => p.Laverie)
                      .HasForeignKey(v => v.IDLaverie)
                      .OnDelete(DeleteBehavior.Cascade);



            });
            modelBuilder.Entity<Machine>(entity =>
            {
                entity.HasKey(l => l.IdMachine);
                entity.Property(l => l.MarqueMachine).HasColumnName("Marque");
                entity.Property(l => l.EtatMachine).HasColumnName("Etat");
                entity.HasMany(p => p.cyclesMachine)
                      .WithOne(p => p.Machine)
                      .HasForeignKey(v => v.IdMachine)
                      .OnDelete(DeleteBehavior.Cascade);



            });
            modelBuilder.Entity<Cycle>(entity =>
            {
                entity.HasKey(c => c.IdCycle); 
                entity.Property(c => c.NomCycle).HasColumnName("NomDuCycle");
                entity.Property(c => c.DureeCycleHR).HasColumnName("DureeHeures");
                entity.Property(c => c.coutCycle).HasColumnName("Cout");


            });

            


            base.OnModelCreating(modelBuilder);
        }
    }
}
