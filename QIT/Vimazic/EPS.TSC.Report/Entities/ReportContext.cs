using System.Data.Entity;

namespace EPS.TSC.Report.Entities
{
    public class ReportContext : DbContext
    {
        public ReportContext()
            : base("name=TSCConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var schema = new Oracle.ManagedDataAccess.Client.OracleConnectionStringBuilder(this.Database.Connection.ConnectionString).UserID;
            modelBuilder.HasDefaultSchema(schema);
        }

        public virtual DbSet<RPT_08A_DK_TSC_01> RPT_08A_DK_TSC_01 { get; set; }
        public virtual DbSet<RPT_08A_DK_TSC_02> RPT_08A_DK_TSC_02 { get; set; }
        public virtual DbSet<RPT_08A_DK_TSC_03> RPT_08A_DK_TSC_03 { get; set; }
        public virtual DbSet<RPT_08A_DK_TSKCHT_01> RPT_08A_DK_TSKCHT_01 { get; set; }
        public virtual DbSet<RPT_08A_DK_TSKCHT_02> RPT_08A_DK_TSKCHT_02 { get; set; }
        public virtual DbSet<RPT_08A_DK_TSKCHT_03> RPT_08A_DK_TSKCHT_03 { get; set; }
        public virtual DbSet<RPT_08B_DK_TSC_01> RPT_08B_DK_TSC_01 { get; set; }
        public virtual DbSet<RPT_08B_DK_TSC_02> RPT_08B_DK_TSC_02 { get; set; }
        public virtual DbSet<RPT_08B_DK_TSC_03> RPT_08B_DK_TSC_03 { get; set; }
        public virtual DbSet<RPT_08B_DK_TSKCHT_01> RPT_08B_DK_TSKCHT_01 { get; set; }
        public virtual DbSet<RPT_08B_DK_TSKCHT_02> RPT_08B_DK_TSKCHT_02 { get; set; }
        public virtual DbSet<RPT_08B_DK_TSKCHT_03> RPT_08B_DK_TSKCHT_03 { get; set; }
        public virtual DbSet<RPT_08C_DK_TSKCHT_01> RPT_08C_DK_TSKCHT_01 { get; set; }
        public virtual DbSet<RPT_08C_DK_TSKCHT_02> RPT_08C_DK_TSKCHT_02 { get; set; }
        public virtual DbSet<RPT_08D_DK_TSKCHT> RPT_08D_DK_TSKCHT { get; set; }
        public virtual DbSet<RPT_09A_CK_TSC> RPT_09A_CK_TSC { get; set; }
        public virtual DbSet<RPT_09B_CK_TSC> RPT_09B_CK_TSC { get; set; }
        public virtual DbSet<RPT_09C_CK_TSC> RPT_09C_CK_TSC { get; set; }
        public virtual DbSet<RPT_09DD_CK_TSC> RPT_09DD_CK_TSC { get; set; }
        public virtual DbSet<RPT_09D_CK_TSC> RPT_09D_CK_TSC { get; set; }
        public virtual DbSet<RPT_10A_CK_TSC> RPT_10A_CK_TSC { get; set; }
        public virtual DbSet<RPT_10B_CK_TSC> RPT_10B_CK_TSC { get; set; }
        public virtual DbSet<RPT_10C_CK_TSC> RPT_10C_CK_TSC { get; set; }
        public virtual DbSet<RPT_10D_CK_TSC> RPT_10D_CK_TSC { get; set; }
        public virtual DbSet<RPT_11A_CK_TSC> RPT_11A_CK_TSC { get; set; }
        public virtual DbSet<RPT_11B_CK_TSC> RPT_11B_CK_TSC { get; set; }
        public virtual DbSet<RPT_11C_CK_TSC> RPT_11C_CK_TSC { get; set; }
        public virtual DbSet<RPT_11D_CK_TSC> RPT_11D_CK_TSC { get; set; }
        public virtual DbSet<RPT_BCCP_01> RPT_BCCP_01 { get; set; }
        public virtual DbSet<RPT_BCCP_02> RPT_BCCP_02 { get; set; }
        public virtual DbSet<RPT_BCCP_03> RPT_BCCP_03 { get; set; }
        public virtual DbSet<RPT_BCCP_04> RPT_BCCP_04 { get; set; }
        public virtual DbSet<RPT_BCCP_05> RPT_BCCP_05 { get; set; }
        public virtual DbSet<RPT_BCCP_06> RPT_BCCP_06 { get; set; }
        public virtual DbSet<RPT_BCCP_07> RPT_BCCP_07 { get; set; }
        public virtual DbSet<RPT_BCCP_08> RPT_BCCP_08 { get; set; }
        public virtual DbSet<RPT_BCCP_09> RPT_BCCP_09 { get; set; }
        public virtual DbSet<RPT_BCCP_10> RPT_BCCP_10 { get; set; }
        public virtual DbSet<RPT_BCCP_11> RPT_BCCP_11 { get; set; }
        public virtual DbSet<RPT_BCTSCTKVHV> RPT_BCTSCTKVHV { get; set; }

    }
}