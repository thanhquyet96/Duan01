using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EPS.TSC.Data.Logging
{
    public partial class LoggingContext : DbContext
    {
        public LoggingContext()
        {
        }

        public LoggingContext(DbContextOptions<LoggingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DATA_SYNC_LOG> DATA_SYNC_LOGS { get; set; }
        public virtual DbSet<SYSTEM_LOG> SYSTEM_LOGS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("DATA SOURCE=localhost/orcl;PASSWORD=logging;USER ID=Logging");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:DefaultSchema", "LOGGING");

            modelBuilder.Entity<DATA_SYNC_LOG>(entity =>
            {
                entity.HasIndex(e => e.ID)
                    //.HasName("SYS_C0021826")
                    .IsUnique();

                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SYSTEM_LOG>(entity =>
            {
                entity.HasIndex(e => e.ID)
                    //.HasName("SYS_C0021818")
                    .IsUnique();

                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            //modelBuilder.HasSequence("ISEQ$$_85408");

            //modelBuilder.HasSequence("ISEQ$$_85417");

            //modelBuilder.HasSequence("ISEQ$$_85427");

            //modelBuilder.HasSequence("ISEQ$$_85436");

            //modelBuilder.HasSequence("ISEQ$$_85854");

            //modelBuilder.HasSequence("ISEQ$$_85863");

            //modelBuilder.HasSequence("ISEQ$$_85956");

            //modelBuilder.HasSequence("ISEQ$$_85965");

            //modelBuilder.HasSequence("ISEQ$$_86476");

            //modelBuilder.HasSequence("ISEQ$$_86485");

            //modelBuilder.HasSequence("ISEQ$$_86716");

            //modelBuilder.HasSequence("ISEQ$$_86725");

            //modelBuilder.HasSequence("ISEQ$$_86949");

            //modelBuilder.HasSequence("ISEQ$$_86958");

            //modelBuilder.HasSequence("ISEQ$$_87191");

            //modelBuilder.HasSequence("ISEQ$$_87200");

            //modelBuilder.HasSequence("ISEQ$$_87433");

            //modelBuilder.HasSequence("ISEQ$$_87442");

            //modelBuilder.HasSequence("ISEQ$$_87848");

            //modelBuilder.HasSequence("ISEQ$$_87857");

            //modelBuilder.HasSequence("ISEQ$$_88138");

            //modelBuilder.HasSequence("ISEQ$$_88147");
        }
    }
}
