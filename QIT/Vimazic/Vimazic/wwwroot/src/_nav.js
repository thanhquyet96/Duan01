export default {
    items: [
        {
            code: 'home',
            name: 'Trang chủ',
            url: '/home',
            icon: 'fa fa-home',
            //badge: {
            //    variant: 'primary',
            //    text: 'NEW'
            //}
        },
        {
            divider: true
        },
        {
            code: 'system',
            name: 'Quản lý hệ thống',
            url: '/system',
            icon: 'fa fa-cog',
            children: [
                {
                    code: 'manage_users',
                    name: 'Người dùng',
                    url: '/system/users',
                    icon: 'fa fa-user',
                    requiresPrivileges: ['ViewUser', 'ManageUser']
                },
                {
                    code: 'manage_roles',
                    name: 'Nhóm người dùng',
                    url: '/system/roles',
                    icon: 'fa fa-users',
                    requiresPrivileges: ['ViewRole', 'ManageRole']
                },
                {
                    code: 'manage_exploitation_users',
                    name: 'Tài khoản đơn vị khai thác dữ liệu',
                    url: '/system/exploitation-users',
                    icon: 'fa fa-users',
                    requiresPrivileges: ['ViewExploitationUser', 'ManageExploitationUser']
                },
                {
                    code: 'manage_exploiting_roles',
                    name: 'Nhóm tài khoản đơn vị khai thác dữ liệu',
                    url: '/system/exploitation-roles',
                    icon: 'fa fa-users',
                    requiresPrivileges: ['ViewExploitationRole','ManageExploitationRole']
                },
                {
                    code: 'manage_sync_users',
                    name: 'Tài khoản đơn vị đồng bộ dữ liệu',
                    url: '/system/sync-users',
                    icon: 'fa fa-users',
                    requiresPrivileges: ['ViewSyncUser', 'ManageSyncUser']
                },
                {
                    code: 'manage_sync_roles',
                    name: 'Nhóm tài khoản đơn vị đồng bộ dữ liệu',
                    url: '/system/sync-roles',
                    icon: 'fa fa-users',
                    requiresPrivileges: ['ViewSyncRole', 'ManageSyncRole']
                },
                {
                    code: 'manage_system_parameters',
                    name: 'Tham số hệ thống',
                    url: '/system/system-parameters',
                    icon: 'fa fa-users',
                    requiresPrivileges: ['ManageSystemParameter']
                },
                {
                    code: 'manage_report_parameters',
                    name: 'Tham số báo cáo',
                    url: '/system/report-parameters',
                    icon: 'fa fa-users',
                    requiresPrivileges: ['ManageReportParameter']
                },
                {
                    code: 'manage_sync_parameters',
                    name: 'Tham số đồng bộ dữ liệu',
                    url: '/system/sync-parameters',
                    icon: 'fa fa-users',
                    requiresPrivileges: ['ManageSyncParameter']
                }
            ]
        },

        {
            divider: true
        },

        {
            code: 'manage_master_data',
            name: 'Quản lý danh mục',
            url: '/master-data',
            icon: 'fa fa-list-alt',
            children: [
                {
                    code: 'manage_unit_types',
                    name: 'Phân loại đơn vị',
                    url: '/master-data/unit-types',
                    icon: 'fa fa-user',
                    requiresPrivileges: ['ViewUnitType', 'ManageUnitType']
                },
                {
                    code: 'manage_units',
                    name: 'Đơn vị',
                    url: '/master-data/units',
                    icon: 'fa fa-user',
                    requiresPrivileges: ['ViewUnit', 'ManageUnit']
                },
                {
                    code: 'manage_asset_types',
                    name: 'Nhóm tài sản',
                    url: '/master-data/asset-types',
                    icon: 'fa fa-object-group',
                    requiresPrivileges: ['ViewAssetType', 'ManageAssetType']
                },
                {
                    code: 'manage_increasement_causes',
                    name: 'Lý do tăng',
                    url: '/master-data/increasement-causes',
                    icon: 'fa fa-arrow-up',
                    requiresPrivileges: ['ViewIncreasementCause', 'ManageIncreasementCause']
                },
                {
                    code: 'manage_decreasement_causes',
                    name: 'Lý do giảm',
                    url: '/master-data/decreasement-causes',
                    icon: 'fa fa-arrow-down',
                    requiresPrivileges: ['ViewDecreasementCause', 'ManageDecraseementCause']
                },
                {
                    code: 'manage_asset_sources',
                    name: 'Nguồn gốc hình thành tài sản',
                    url: '/master-data/asset-sources',
                    icon: 'fa fa-database',
                    requiresPrivileges: ['ViewAssetSource', 'ManageAssetSource']
                },
                {
                    code: 'manage_usage_states',
                    name: 'Hiện trạng sử dụng',
                    url: '/master-data/asset-usage-states',
                    icon: 'fa fa-database',
                    requiresPrivileges: ['ViewUsageState', 'ManageUsageState']
                },
                {
                    code: 'manage_usage_purposes',
                    name: 'Mục đích sử dụng',
                    url: '/master-data/asset-usage-purposes',
                    icon: 'fa fa-database',
                    requiresPrivileges: ['ViewUsagePurpose', 'ManageUsagePurpose']
                },
                {
                    code: 'manage_countries',
                    name: 'Danh mục quốc gia',
                    url: '/master-data/countries',
                    icon: 'fa fa-globe',
                    requiresPrivileges: ['ViewCountry', 'ManageCountry']
                },
                {
                    code: 'manage_regions',
                    name: 'Danh mục địa bàn',
                    url: '/master-data/regions',
                    icon: 'fa fa-location-arrow',
                    requiresPrivileges: ['ViewRegion', 'ManageRegion']
                },
            ]
        },

        {
            divider: true
        },

        {
            code: 'manage_data',
            name: 'Quản lý dữ liệu',
            url: '/manage-data',
            icon: 'fa fa-home',
            children: [
                {
                    code: 'manage_assets',
                    name: 'Tài sản',
                    url: '/manage-data/assets',
                    icon: 'fa fa-database',
                    requiresPrivileges: ['ManageAsset']
                },
                {
                    code: 'manage_asset_mutations',
                    name: 'Biến động',
                    url: '/manage-data/asset-mutations',
                    icon: 'fa fa-database',
                    requiresPrivileges: ['ViewAssetMutation', 'ManageAssetMutation']
                },
                {
                    code: 'manage_reports',
                    name: 'Báo cáo',
                    url: '/manage/reports',
                    icon: 'fa fa-database',
                    requiresPrivileges: ['ViewReport', 'ManageReport']
                }
            ]
        },

        {
            divider: true
        },

        {
            code: 'search',
            name: 'Tra cứu lịch sử đồng bộ dữ liệu',
            url: '/search',
            icon: 'fa fa-home',
            children: [
                {
                    code: 'search_synced_assets',
                    name: 'Tài sản',
                    url: '/search/synced-assets',
                    icon: 'fa fa-database',
                    requiresPrivileges: ['SearchSyncedAsset']
                },
                {
                    code: 'search_synced_asset_exploitation',
                    name: 'Hoạt động khai thác tài sản',
                    url: '/search/synced-asset-exploitations',
                    icon: 'fa fa-database',
                    requiresPrivileges: ['SearchSyncedAssetExploitation']
                },
                {
                    code: 'search_synced_reports',
                    name: 'Báo cáo',
                    url: '/search/synced-reports',
                    icon: 'fa fa-database',
                    requiresPrivileges: ['SearchSyncedReport']
                }
            ]
        },

        {
            divider: true
        },

        {
            code: 'reporting',
            name: 'Báo cáo',
            url: '/reports',
            icon: 'fa fa-report',
            children: [
                {
                    code: 'view_summary_reports',
                    name: 'Báo cáo tổng hợp',
                    url: '/reports/summary-reports',
                    icon: 'fa fa-report',
                    requiresPrivileges: ['ViewSummaryReport']
                },
                {
                    code: 'view_public_reports',
                    name: 'Báo cáo công khai',
                    url: '/reports/public-reports',
                    icon: 'fa fa-report',
                    requiresPrivileges: ['ViewPublicReport']
                },
                {
                    code: 'view_government_reports',
                    name: 'Báo cáo chính phủ',
                    url: '/reports/goverment-reports',
                    icon: 'fa fa-report',
                    requiresPrivileges: ['ViewGovermentReport']
                },
                {
                    code: 'view_statistic_reports',
                    name: 'Báo cáo thống kê hiện vật',
                    url: '/reports/statistic-reports',
                    icon: 'fa fa-report',
                    requiresPrivileges: ['ViewStatisticReport']
                }
            ]
        },

        {
            code: 'system_logs',
            name: 'Nhật ký hệ thống',
            url: '/logs',
            icon: 'fa fa-report',
            children: [
                {
                    code: 'action_logs',
                    name: 'Nhật ký thao tác dữ liệu',
                    url: '/logs/action-logs',
                    icon: 'fa fa-report',
                    requiresPrivileges: ['ViewActionLog']
                },
                {
                    code: 'sync_logs',
                    name: 'Nhật ký đồng bộ dữ liệu',
                    url: '/logs/sync-logs',
                    icon: 'fa fa-report',
                    requiresPrivileges: ['ViewSyncLog']
                },
                {
                    code: 'backup_logs',
                    name: 'Nhật ký sao lưu dữ liệu',
                    url: '/logs/backup-logs',
                    icon: 'fa fa-report',
                    requiresPrivileges: ['ViewBackupLog']
                }
            ]
        }
    ]
}
