using System;
using EPS.TSC.Data.Entities;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EPS.TSC.Data
{
    public partial class TSCContext : DbContext, IDataProtectionKeyContext
    {
        public TSCContext()
        {
        }

        public TSCContext(DbContextOptions<TSCContext> options)
            : base(options)
        {
        }
        public virtual DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
        public virtual DbSet<IDENTITY_CLIENT> IDENTITY_CLIENTS { get; set; }
        public virtual DbSet<IDENTITY_REFRESH_TOKEN> IDENTITY_REFRESH_TOKENS { get; set; }
        public virtual DbSet<PRIVILEGE> PRIVILEGES { get; set; }
        public virtual DbSet<ROLE> ROLES { get; set; }
        public virtual DbSet<ROLE_PRIVILEGE> ROLE_PRIVILEGES { get; set; }
        public virtual DbSet<USER> USERS { get; set; }
        public virtual DbSet<USER_PRIVILEGE> USER_PRIVILEGES { get; set; }
        public virtual DbSet<USER_ROLE> USER_ROLES { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-STJ8GH4C;User ID=sa;password=123456;Initial Catalog=TSC;Integrated Security=True;Trusted_Connection=false;").UseLazyLoadingProxies();
                //  options.UseSqlServer(Configuration.GetConnectionString("TSC")).UseLazyLoadingProxies()
                ////op => 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
            //    .HasAnnotation("Relational:DefaultSchema", "TSC");

            //modelBuilder.Entity<DataProtectionKey>(entity =>
            //{
            //    entity.ToTable("DATA_PROTECTION_KEYS");
            //    //entity.Property(x => x.Id).HasColumnName("ID");
            //    //entity.Property(x => x.FriendlyName).HasColumnName("FRIENDLY_NAME");
            //    //entity.Property(x => x.Xml).HasColumnName("XML");
            //});


            //modelBuilder.Entity<IDENTITY_CLIENT>(entity =>
            //{
            //    entity.ToTable("IDENTITY_CLIENTS");
            //    entity.HasKey(e => e.IDENTITY_CLIENT_ID);
            //    //.HasName("SYS_C0023531");

            //    entity.HasIndex(e => e.IDENTITY_CLIENT_ID)
            //        //.HasName("SYS_C0023531")
            //        .IsUnique();

            //    entity.Property(e => e.IDENTITY_CLIENT_ID).ValueGeneratedNever();
            //});

            //modelBuilder.Entity<IDENTITY_REFRESH_TOKEN>(entity =>
            //{
            //    entity.HasKey(e => e.IDENTITY_REFRESH_TOKEN_ID);
            //    //.HasName("SYS_C0023537");

            //    entity.HasIndex(e => e.IDENTITY_REFRESH_TOKEN_ID)
            //        //.HasName("SYS_C0023537")
            //        .IsUnique();

            //    entity.Property(e => e.IDENTITY_REFRESH_TOKEN_ID).ValueGeneratedNever();
            //});


            //modelBuilder.Entity<PRIVILEGE>(entity =>
            //{
            //    entity.HasIndex(e => e.ID)
            //        //.HasName("SYS_C0023539")
            //        .IsUnique();

            //    entity.Property(e => e.ID).ValueGeneratedNever();
            //});


            //modelBuilder.Entity<ROLE>(entity =>
            //{
            //    entity.HasIndex(e => e.ID)
            //        //.HasName("SYS_C0023542")
            //        .IsUnique();

            //});

            //modelBuilder.Entity<ROLE_PRIVILEGE>(entity =>
            //{
            //    entity.HasKey(e => new { e.ROLE_ID, e.PRIVILEGE_ID });
            //    //.HasName("SYS_C0023543");

            //    entity.HasIndex(e => new { e.ROLE_ID, e.PRIVILEGE_ID })
            //        //.HasName("SYS_C0023543")
            //        .IsUnique();

            //    entity.HasOne(d => d.PRIVILEGE)
            //        .WithMany(p => p.ROLE_PRIVILEGES)
            //        .HasForeignKey(d => d.PRIVILEGE_ID)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        ;//.HasConstraintName("SYS_C0023545");

            //    entity.HasOne(d => d.ROLE)
            //        .WithMany(p => p.ROLE_PRIVILEGES)
            //        .HasForeignKey(d => d.ROLE_ID)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        ;//.HasConstraintName("SYS_C0023544");
            //});


            //modelBuilder.Entity<USER>(entity =>
            //{
            //    entity.ToTable("USERS");
            //    //entity.Property(x => x.Id).HasColumnName("ID");
            //    //entity.Property(x => x.UserName).HasColumnName("USER_NAME");
            //    //entity.Property(x => x.NormalizedUserName).HasColumnName("NORMALIZED_USER_NAME");
            //    //entity.Property(x => x.TwoFactorEnabled).HasColumnName("TWO_FACTOR_ENABLED");
            //    //entity.Property(x => x.PhoneNumberConfirmed).HasColumnName("PHONE_NUMBER_CONFIRMED");
            //    //entity.Property(x => x.PhoneNumber).HasColumnName("PHONE_NUMBER");
            //    //entity.Property(x => x.LockoutEnd).HasColumnName("LOCKOUT_END");
            //    //entity.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");
            //    //entity.Property(x => x.SecurityStamp).HasColumnName("SECURITY_STAMP");
            //    //entity.Property(x => x.PasswordHash).HasColumnName("PASSWORD_HASH");
            //    //entity.Property(x => x.EmailConfirmed).HasColumnName("EMAIL_CONFIRMED");
            //    //entity.Property(x => x.NormalizedEmail).HasColumnName("NORMALIZED_EMAIL");
            //    //entity.Property(x => x.Email).HasColumnName("EMAIL");
            //    //entity.Property(x => x.LockoutEnabled).HasColumnName("LOCKOUT_ENABLED");
            //    //entity.Property(x => x.AccessFailedCount).HasColumnName("ACCESS_FAILED_COUNT");

            //    //entity.HasOne(d => d.UNIT)
            //    //    .WithMany(p => p.USERS)
            //    //    .HasForeignKey(d => d.UNIT_ID)
            //    //    .OnDelete(DeleteBehavior.Restrict)
            //    //    ;//.HasConstraintName("SYS_C0023555");
            //});

            //modelBuilder.Entity<USER_PRIVILEGE>(entity =>
            //{
            //    entity.HasKey(e => new { e.USER_ID, e.PRIVILEGE_ID });
            //    //.HasName("SYS_C0023556");

            //    entity.HasIndex(e => new { e.USER_ID, e.PRIVILEGE_ID })
            //        //.HasName("SYS_C0023556")
            //        .IsUnique();

            //    entity.HasOne(d => d.PRIVILEGE)
            //        .WithMany(p => p.USER_PRIVILEGES)
            //        .HasForeignKey(d => d.PRIVILEGE_ID)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        ;//.HasConstraintName("SYS_C0023558");

            //    entity.HasOne(d => d.USER)
            //        .WithMany(p => p.USER_PRIVILEGES)
            //        .HasForeignKey(d => d.USER_ID)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        ;//.HasConstraintName("SYS_C0023557");
            //});

            //modelBuilder.Entity<USER_ROLE>(entity =>
            //{
            //    entity.HasKey(e => new { e.USER_ID, e.ROLE_ID });
            //    //.HasName("SYS_C0023559");

            //    entity.HasIndex(e => new { e.USER_ID, e.ROLE_ID })
            //        //.HasName("SYS_C0023559")
            //        .IsUnique();

            //    entity.HasOne(d => d.ROLE)
            //        .WithMany(p => p.USER_ROLES)
            //        .HasForeignKey(d => d.ROLE_ID)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        ;//.HasConstraintName("SYS_C0023561");

            //    entity.HasOne(d => d.USER)
            //        .WithMany(p => p.USER_ROLES)
            //        .HasForeignKey(d => d.USER_ID)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        ;//.HasConstraintName("SYS_C0023560");
            //});

        }
    }
}
