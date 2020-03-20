using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.TSC.Data.Entities
{
    [Table("PRIVILEGES")]
    public partial class PRIVILEGE
    {
        public PRIVILEGE()
        {
            ROLE_PRIVILEGES = new HashSet<ROLE_PRIVILEGE>();
            USER_PRIVILEGES = new HashSet<USER_PRIVILEGE>();
        }

        [Column(TypeName = "VARCHAR2(50)")]
        [Key]
        public string ID { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR2(250)")]
        public string NAME { get; set; }
        [Column(TypeName = "VARCHAR2(4000)")]
        public string DESCRIPTION { get; set; }
        public bool? IS_EXPLOITING_PRIVILEGES { get; set; }

        [InverseProperty("PRIVILEGE")]
        public virtual ICollection<ROLE_PRIVILEGE> ROLE_PRIVILEGES { get; set; }
        [InverseProperty("PRIVILEGE")]
        public virtual ICollection<USER_PRIVILEGE> USER_PRIVILEGES { get; set; }
    }

    public enum Privilege
    {
        #region System
        ViewUser,
        ManageUser,
        ViewRole,
        ManageRole,
        ViewSyncUser,
        ManageSyncUser,
        ManageSystemParameter,
        ManageReportParameter,
        ManageSyncParameter,
        ViewActionLog,
        ViewSyncLog,
        ViewBackupLog,
        ViewSyncRole,
        ManageSyncRole,
        ViewExploitationUser,
        ManageExploitationUser,
        ViewExploitationRole,
        ManageExploitationRole,

        #endregion

        #region Master data
        ViewUnitType,
        ManageUnitType,
        ViewUnit,
        ManageUnit,
        ViewAssetType,
        ManageAssetType,
        ViewIncreasementCause,
        ManageIncreasementCause,
        ViewDecreasementCause,
        ManageDecreasementCause,
        ViewAssetSource,
        ManageAssetSource,
        ViewUsageState,
        ManageUsageState,
        ViewUsagePurpose,
        ManageUsagePurpose,
        ViewCountry,
        ManageCountry,
        ViewRegion,
        ManageRegion,
        #endregion

        #region Manage data
        ViewAsset,
        ManageAsset,
        ViewAssetMutation,
        ManageAssetMutation,
        ViewReport,
        ManageReport,
        #endregion

        #region Search data
        SearchSyncedAsset,
        SearchSyncedAssetExploitation,
        SearchSyncedReport,
        #endregion

        #region Reports
        ViewSummaryReport,
        ViewPublicReport,
        ViewGovermentReport,
        ViewStatisticReport
        #endregion
    }
}
