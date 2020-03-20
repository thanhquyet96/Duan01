export default [
    {
        _name: 'CSidebarNav',
        _children: [
            {
                _name: 'CSidebarNavItem',
                code: 'home',
                name: 'Trang chủ',
                to: '/home',
                icon: 'cil-home'
            },
            {
                _name: 'CSidebarNavDropdown',
                code: 'system',
                name: 'Quản lý hệ thống',
                to: '/system',
                icon: 'cil-settings',
                items: [
                    {
                        code: 'manage_users',
                        name: 'Người dùng',
                        to: '/system/users',
                        icon: 'cil-user',
                        requiresPrivileges: ['ViewUser', 'ManageUser']
                    },
                    {
                        code: 'manage_roles',
                        name: 'Nhóm người dùng',
                        to: '/system/roles',
                        icon: 'cil-people',
                        requiresPrivileges: ['ViewRole', 'ManageRole']
                    },
                    {
                        code: 'manage_exploitation_users',
                        name: 'Tài khoản khai thác',
                        to: '/system/exploitation-users',
                        icon: 'cil-user',
                        requiresPrivileges: ['ViewExploitationUser', 'ManageExploitationUser']
                    },
                    {
                        code: 'manage_exploiting_roles',
                        name: 'Nhóm tài khoản khai thác',
                        to: '/system/exploitation-roles',
                        icon: 'cil-people',
                        requiresPrivileges: ['ViewExploitationRole', 'ManageExploitationRole']
                    },
                    {
                        code: 'manage_sync_users',
                        name: 'Tài khoản đồng bộ',
                        to: '/system/sync-users',
                        icon: 'cil-user',
                        requiresPrivileges: ['ViewSyncUser', 'ManageSyncUser']
                    },
                    {
                        code: 'manage_sync_roles',
                        name: 'Nhóm tài khoản đồng bộ',
                        to: '/system/sync-roles',
                        icon: 'cil-people',
                        requiresPrivileges: ['ViewSyncRole', 'ManageSyncRole']
                    },
                    {
                        code: 'manage_system_parameters',
                        name: 'Tham số hệ thống',
                        to: '/system/system-parameters',
                        icon: 'cilSpreadsheet',
                        requiresPrivileges: ['ManageSystemParameter']
                    },
                    {
                        code: 'manage_report_parameters',
                        name: 'Tham số báo cáo',
                        to: '/system/report-parameters',
                        icon: 'cilSpreadsheet',
                        requiresPrivileges: ['ManageReportParameter']
                    },
                    {
                        code: 'manage_sync_parameters',
                        name: 'Tham số đồng bộ dữ liệu',
                        to: '/system/sync-parameters',
                        icon: 'cilSpreadsheet',
                        requiresPrivileges: ['ManageSyncParameter']
                    }
                ]
            },
            {
                _name: 'CSidebarNavDropdown',
                code: 'manage_master_data',
                name: 'Quản lý danh mục',
                to: '/master-data',
                icon: 'cilListRich',
                items: [
                    {
                        code: 'manage_unit_types',
                        name: 'Phân loại đơn vị',
                        to: '/master-data/unit-types',
                        icon: 'cilBuilding',
                        requiresPrivileges: ['ViewUnitType', 'ManageUnitType']
                    },
                    {
                        code: 'manage_units',
                        name: 'Đơn vị',
                        to: '/master-data/units',
                        icon: 'cilBuilding',
                        requiresPrivileges: ['ViewUnit', 'ManageUnit']
                    },
                    {
                        code: 'manage_asset_types',
                        name: 'Nhóm tài sản',
                        to: '/master-data/asset-types',
                        icon: 'cilListRich',
                        requiresPrivileges: ['ViewAssetType', 'ManageAssetType']
                    },
                    {
                        code: 'manage_increasement_causes',
                        name: 'Lý do tăng',
                        to: '/master-data/increasement-causes',
                        icon: 'cilArrowCircleTop',
                        requiresPrivileges: ['ViewIncreasementCause', 'ManageIncreasementCause']
                    },
                    {
                        code: 'manage_decreasement_causes',
                        name: 'Lý do giảm',
                        to: '/master-data/decreasement-causes',
                        icon: 'cilArrowCircleBottom',
                        requiresPrivileges: ['ViewDecreasementCause', 'ManageDecraseementCause']
                    },
                    {
                        code: 'manage_asset_sources',
                        name: 'Nguồn gốc hình thành tài sản',
                        to: '/master-data/asset-sources',
                        icon: 'cilListRich',
                        requiresPrivileges: ['ViewAssetSource', 'ManageAssetSource']
                    },
                    {
                        code: 'manage_usage_states',
                        name: 'Hiện trạng sử dụng',
                        to: '/master-data/asset-usage-states',
                        icon: 'cilListRich',
                        requiresPrivileges: ['ViewUsageState', 'ManageUsageState']
                    },
                    {
                        code: 'manage_usage_purposes',
                        name: 'Mục đích sử dụng',
                        to: '/master-data/asset-usage-purposes',
                        icon: 'cilListRich',
                        requiresPrivileges: ['ViewUsagePurpose', 'ManageUsagePurpose']
                    },
                    {
                        code: 'manage_countries',
                        name: 'Danh mục quốc gia',
                        to: '/master-data/countries',
                        icon: 'cilGlobeAlt',
                        requiresPrivileges: ['ViewCountry', 'ManageCountry']
                    },
                    {
                        code: 'manage_regions',
                        name: 'Danh mục địa bàn',
                        to: '/master-data/regions',
                        icon: 'cilLocationPin',
                        requiresPrivileges: ['ViewRegion', 'ManageRegion']
                    },
                ]
            },
            {
                _name: 'CSidebarNavDropdown',
                code: 'manage_data',
                name: 'Quản lý dữ liệu',
                to: '/manage',
                icon: 'cil3d',
                items: [
                    {
                        code: 'manage_assets',
                        name: 'Tài sản',
                        to: '/manage-data/assets',
                        icon: 'cilGrid',
                        requiresPrivileges: ['ViewAsset','ManageAsset']
                    },
                    {
                        code: 'manage_asset_mutations',
                        name: 'Biến động',
                        to: '/manage-data/asset-mutations',
                        icon: 'cil3d',
                        requiresPrivileges: ['ViewAssetMutation', 'ManageAssetMutation']
                    },
                    {
                        code: 'manage_reports',
                        name: 'Báo cáo',
                        to: '/manage-data/reports',
                        icon: 'cilBook',
                        requiresPrivileges: ['ViewReport', 'ManageReport']
                    }
                ]
            },
            {
                _name: 'CSidebarNavDropdown',
                code: 'search',
                name: 'Tra cứu lịch sử đồng bộ dữ liệu',
                to: '/search',
                icon: 'cilMagnifyingGlass',
                items: [
                    {
                        code: 'search_synced_assets',
                        name: 'Tài sản',
                        to: '/search/synced-assets',
                        icon: 'cilGrid',
                        requiresPrivileges: ['SearchSyncedAsset']
                    },
                    {
                        code: 'search_synced_asset_exploitation',
                        name: 'Hoạt động khai thác tài sản',
                        to: '/search/synced-asset-exploitations',
                        icon: 'cilMagnifyingGlass',
                        requiresPrivileges: ['SearchSyncedAssetExploitation']
                    },
                    {
                        code: 'search_synced_reports',
                        name: 'Báo cáo',
                        to: '/search/synced-reports',
                        icon: 'cilBook',
                        requiresPrivileges: ['SearchSyncedReport']
                    }
                ]
            },
            {
                _name: 'CSidebarNavDropdown',
                code: 'reporting',
                name: 'Báo cáo',
                to: '/reports',
                icon: 'cilBook',
                items: [
                    {
                        code: 'view_summary_reports',
                        name: 'Báo cáo tổng hợp',
                        to: '/reports/summary-reports',
                        icon: 'cilBook',
                        requiresPrivileges: ['ViewSummaryReport']
                    },
                    {
                        code: 'view_public_reports',
                        name: 'Báo cáo công khai',
                        to: '/reports/public-reports',
                        icon: 'cilBook',
                        requiresPrivileges: ['ViewPublicReport']
                    },
                    {
                        code: 'view_government_reports',
                        name: 'Báo cáo chính phủ',
                        to: '/reports/goverment-reports',
                        icon: 'cilBook',
                        requiresPrivileges: ['ViewGovermentReport']
                    },
                    {
                        code: 'view_statistic_reports',
                        name: 'Báo cáo thống kê hiện vật',
                        to: '/reports/statistic-reports',
                        icon: 'cilBook',
                        requiresPrivileges: ['ViewStatisticReport']
                    }
                ]
            },

            {
                _name: 'CSidebarNavDropdown',
                code: 'system_logs',
                name: 'Nhật ký hệ thống',
                to: '/logs',
                icon: 'cilCalendar',
                items: [
                    {
                        code: 'action_logs',
                        name: 'Nhật ký thao tác dữ liệu',
                        to: '/logs/action-logs',
                        icon: 'cilCalendar',
                        requiresPrivileges: ['ViewActionLog']
                    },
                    {
                        code: 'sync_logs',
                        name: 'Nhật ký đồng bộ dữ liệu',
                        to: '/logs/sync-logs',
                        icon: 'cilCalendar',
                        requiresPrivileges: ['ViewSyncLog']
                    },
                    {
                        code: 'backup_logs',
                        name: 'Nhật ký sao lưu dữ liệu',
                        to: '/logs/backup-logs',
                        icon: 'cilCalendar',
                        requiresPrivileges: ['ViewBackupLog']
                    }
                ]
            }
        ]
    }
]