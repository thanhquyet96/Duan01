import Vue from 'vue'
import Router from 'vue-router'
import store from '@/store/index';

// Containers
const TheContainer = () => import('@/containers/TheContainer')

// Views - Pages
import Page404 from '@/views/pages/Page404'
//import Page500 from '@/views/pages/Page500'
import Login from '@/views/pages/Login'
//import Register from '@/views/pages/Register'



Vue.use(Router)

var router = new Router({
    mode: 'hash', // Demo is living in GitHub.io, so required!
    linkActiveClass: 'open active',
    scrollBehavior: () => ({ y: 0 }),
    routes: [
        {
            path: '/',
            redirect: '/home',
            name: 'default',
            component: TheContainer,
            meta: { requiresAuth: true, label: 'Trang chủ' },
            children: [
                {
                    path: 'home',
                    name: 'home',
                    meta: { label: 'Trang chủ', requiresAuth: true },
                    component: () => import('@/views/home')
                },
                {
                    path: 'system',
                    name: 'system',
                    redirect: '/system/users',
                    meta: { label: 'Hệ thống' },
                    component: {
                        render(c) { return c('router-view') }
                    },
                    children: [
                        {
                            path: 'users',
                            name: 'users',
                            redirect: '/system/users/list',
                            meta: { label: 'Người dùng' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'user_list',
                                    meta: { label: 'Danh sách người dùng', requiresAuth: true, requiresPrivileges: ['ViewUser'] },
                                    component: () => import('@/views/system/users/list')
                                },
                                {
                                    path: 'create',
                                    name: 'create_user',
                                    meta: { label: 'Thêm mới người dùng', requiresAuth: true, requiresPrivileges: ['ManageUser'] },
                                    component: () => import('@/views/system/users/create')
                                },
                                {
                                    path: 'detail/:userId',
                                    name: 'user_detail',
                                    meta: { label: 'Thông tin người dùng', requiresAuth: true, requiresPrivileges: ['ViewUser', 'ManageUser'] },
                                    component: () => import('@/views/system/users/detail')
                                },
                                {
                                    path: 'privileges/:userId',
                                    name: 'user_privileges',
                                    meta: { label: 'Phân quyền người dùng', requiresAuth: true, requiresPrivileges: ['ManageUser'] },
                                    component: () => import('@/views/system/users/privileges')
                                }
                            ]
                        },
                        {
                            path: 'roles',
                            name: 'roles',
                            redirect: '/system/roles/list',
                            meta: { label: 'Nhóm người dùng' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'role_list',
                                    meta: { label: 'Danh sách nhóm người dùng', requiresAuth: true, requiresPrivileges: ['ViewRole'] },
                                    component: () => import('@/views/system/roles/list')
                                },
                                {
                                    path: 'create',
                                    name: 'create_role',
                                    meta: { label: 'Thêm mới nhóm người dùng', requiresAuth: true, requiresPrivileges: ['ManageRole'] },
                                    component: () => import('@/views/system/roles/create')
                                },
                                {
                                    path: 'detail/:roleId',
                                    name: 'role_detail',
                                    meta: { label: 'Thông tin nhóm người dùng', requiresAuth: true, requiresPrivileges: ['ViewRole', 'ManageRole'] },
                                    component: () => import('@/views/system/roles/detail')
                                },
                                {
                                    path: 'privileges/:roleId',
                                    name: 'role_privileges',
                                    meta: { label: 'Phân quyền nhóm người dùng', requiresAuth: true, requiresPrivileges: ['ManageRole'] },
                                    component: () => import('@/views/system/roles/privileges')
                                }
                            ]
                        },
                        {
                            path: 'exploitation-users',
                            name: 'exploitation_users',
                            redirect: '/system/exploitation-users/list',
                            meta: { label: 'Tài khoản đơn vị khai thác dữ liệu' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'exploitation_user_list',
                                    meta: { label: 'Danh sách tài khoản khai thác dữ liệu', requiresAuth: true, requiresPrivileges: ['ViewExploitationUser'] },
                                    component: () => import('@/views/system/exploitation-users/list')
                                },
                                {
                                    path: 'create',
                                    name: 'create_exploitation_user',
                                    meta: { label: 'Thêm mới tài khoản khai thác dữ liệu', requiresAuth: true, requiresPrivileges: ['ManageExploitationUser'] },
                                    component: () => import('@/views/system/exploitation-users/create')
                                },
                                {
                                    path: 'detail/:exploitationUserId',
                                    name: 'exploitation_user_detail',
                                    meta: { label: 'Thông tin tài khoản khai thác dữ liệu', requiresAuth: true, requiresPrivileges: ['ViewExploitationUser', 'ManageExploitationUser'] },
                                    component: () => import('@/views/system/exploitation-users/detail')
                                },
                                {
                                    path: 'privileges/:exploitationUserId',
                                    name: 'exploitation_user_privileges',
                                    meta: { label: 'Phân quyền tài khoản khai thác dữ liệu', requiresAuth: true, requiresPrivileges: ['ManageExploitationUser'] },
                                    component: () => import('@/views/system/exploitation-users/privileges')
                                }
                            ]
                        },
                        {
                            path: 'exploitation-roles',
                            name: 'exploitationroles',
                            redirect: '/system/exploitation-roles/list',
                            meta: { label: 'Nhóm tài khoản đơn vị khai thác dữ liệu' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'exploitation_role_list',
                                    meta: { label: 'Danh sách nhóm tài khoản đơn vị khai thác dữ liệu', requiresAuth: true, requiresPrivileges: ['ViewExploitationRole'] },
                                    component: () => import('@/views/system/exploitation-roles/list')
                                },
                                {
                                    path: 'create',
                                    name: 'create_exploitation_role',
                                    meta: { label: 'Thêm mới nhóm tài khoản đơn vị khai thác dữ liệu', requiresAuth: true, requiresPrivileges: ['ManageExploitationRole'] },
                                    component: () => import('@/views/system/exploitation-roles/create')
                                },
                                {
                                    path: 'detail/:exploitationRoleId',
                                    name: 'exploitation_role_detail',
                                    meta: { label: 'Thông tin nhóm tài khoản đơn vị khai thác dữ liệu', requiresAuth: true, requiresPrivileges: ['ViewExploitationRole', 'ManageExploitationRole'] },
                                    component: () => import('@/views/system/exploitation-roles/detail')
                                },
                                {
                                    path: 'privileges/:exploitationRoleId',
                                    name: 'exploitation_role_privileges',
                                    meta: { label: 'Phân quyền nhóm tài khoản đơn vị khai thác dữ liệu', requiresAuth: true, requiresPrivileges: ['ManageExploitationRole'] },
                                    component: () => import('@/views/system/exploitation-roles/privileges')
                                }
                            ]
                        },
                        {
                            path: 'sync-users',
                            name: 'sync_users',
                            redirect: '/system/sync-users/list',
                            meta: { label: 'Tài khoản đơn vị đồng bộ dữ liệu' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'syncuser_list',
                                    meta: { label: 'Danh sách tài khoản đơn vị đồng bộ dữ liệu', requiresAuth: true, requiresPrivileges: ['ViewSyncUser'] },
                                    component: () => import('@/views/system/sync-users/list')
                                },
                                {
                                    path: 'create',
                                    name: 'create_syncuser',
                                    meta: { label: 'Thêm mới tài khoản đơn vị đồng bộ dữ liệu', requiresAuth: true, requiresPrivileges: ['ManageSyncUser'] },
                                    component: () => import('@/views/system/sync-users/create')
                                },
                                {
                                    path: 'detail/:syncuserId',
                                    name: 'syncuser_detail',
                                    meta: { label: 'Thông tin tài khoản đơn vị đồng bộ dữ liệu', requiresAuth: true, requiresPrivileges: ['ViewSyncUser', 'ManageSyncUser'] },
                                    component: () => import('@/views/system/sync-users/detail')
                                }
                            ]
                        },
                        {
                            path: 'sync-roles',
                            name: 'sync-roles',
                            redirect: '/system/sync-roles/list',
                            meta: { label: 'Nhóm tài khoản đơn vị đồng bộ dữ liệu' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'syncrole_list',
                                    meta: { label: 'Danh sách nhóm tài khoản đơn vị đồng bộ dữ liệu', requiresAuth: true, requiresPrivileges: ['ViewSyncRole'] },
                                    component: () => import('@/views/system/sync-roles/list')
                                },
                                {
                                    path: 'create',
                                    name: 'create_syncrole',
                                    meta: { label: 'Thêm mới nhóm tài khoản đơn vị đồng bộ dữ liệu', requiresAuth: true, requiresPrivileges: ['ManageSyncRole'] },
                                    component: () => import('@/views/system/sync-roles/create')
                                },
                                {
                                    path: 'detail/:syncRoleId',
                                    name: 'syncrole_detail',
                                    meta: { label: 'Thông tin nhóm tài khoản đơn vị đồng bộ dữ liệu', requiresAuth: true, requiresPrivileges: ['ViewSyncRole', 'ManageSyncRole'] },
                                    component: () => import('@/views/system/sync-roles/detail')
                                },
                                {
                                    path: 'privileges/:syncRoleId',
                                    name: 'syncrole_privileges',
                                    meta: { label: 'Phân quyền nhóm đơn vị đồng bộ dữ liệu', requiresAuth: true, requiresPrivileges: ['ManageSyncRole'] },
                                    component: () => import('@/views/system/sync-roles/privileges')
                                }
                            ]
                        },
                        {
                            path: 'system-parameters',
                            name: 'system_parameters',
                            redirect: '/system/system-parameters/create',
                            meta: { label: 'Tham số hệ thống' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'create',
                                    name: 'system_parameter_create',
                                    meta: { label: 'Thông tin tham số hệ thống', requiresAuth: true, requiresPrivileges: ['ViewSyncUser'] },
                                    component: () => import('@/views/system/system-parameters/create')
                                }
                            ]
                        },
                        {
                            path: 'report-parameters',
                            name: 'report_parameters',
                            redirect: '/system/report-parameters/create',
                            meta: { label: 'Tham số báo cáo' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'create',
                                    name: 'report_parameter_create',
                                    meta: { label: 'Thông tin tham số báo cáo', requiresAuth: true, requiresPrivileges: ['ViewSyncUser'] },
                                    component: () => import('@/views/system/report-parameters/create')
                                }
                            ]
                        }
                    ]
                },
                {
                    path: 'master-data',
                    name: 'master_data',
                    redirect: '/master-data/unit-types/',
                    meta: { label: 'Danh mục' },
                    component: {
                        render(c) { return c('router-view') }
                    },
                    children: [
                        {
                            path: 'unit-types',
                            name: 'unit_types',
                            redirect: '/master-data/unit-types/list',
                            meta: { label: 'Phân loại đơn vị' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'unit_type_list',
                                    meta: { label: 'Danh sách phân loại đơn vị', requiresAuth: true, requiresPrivileges: ['ViewUnitType'] },
                                    component: () => import('@/views/master-data/unit-types/list')
                                },
                                {
                                    path: 'create',
                                    name: 'create_unit_type',
                                    meta: { label: 'Thêm mới phân loại đơn vị', requiresAuth: true, requiresPrivileges: ['ManageUnitType'] },
                                    component: () => import('@/views/master-data/unit-types/create')
                                },
                                {
                                    path: 'detail/:unitTypeId',
                                    name: 'unit_type_detail',
                                    meta: { label: 'Thông tin phân loại đơn vị', requiresAuth: true, requiresPrivileges: ['ViewUnitType', 'ManageUnitType'] },
                                    component: () => import('@/views/master-data/unit-types/detail')
                                }
                            ]
                        },
                        {
                            path: 'units',
                            name: 'units',
                            redirect: '/master-data/units/list',
                            meta: { label: 'Đơn vị' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'unit_list',
                                    meta: { label: 'Danh sách đơn vị', requiresAuth: true, requiresPrivileges: ['ViewUnit'] },
                                    component: () => import('@/views/master-data/units/list')
                                },
                                {
                                    path: 'create',
                                    name: 'create_unit',
                                    meta: { label: 'Thêm mới đơn vị', requiresAuth: true, requiresPrivileges: ['ManageUnit'] },
                                    component: () => import('@/views/master-data/units/create')
                                },
                                {
                                    path: 'edit/:unitId',
                                    name: 'edit_unit',
                                    meta: { label: 'Sửa đơn vị', requiresAuth: true, requiresPrivileges: ['ViewUnit', 'ManageUnit'] },
                                    component: () => import('@/views/master-data/units/edit')
                                }
                            ]
                        },
                        {
                            path: 'countries',
                            name: 'countries',
                            redirect: '/master-data/countries/list',
                            meta: { label: 'Danh mục quốc gia' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'country_list',
                                    meta: { label: 'Danh sách quốc gia', requiresAuth: true, requiresPrivileges: ['ViewCountry'] },
                                    component: () => import('@/views/master-data/countries/list')
                                },
                                {
                                    path: 'create',
                                    name: 'create_country',
                                    meta: { label: 'Thêm mới quốc gia', requiresAuth: true, requiresPrivileges: ['ManageCountry'] },
                                    component: () => import('@/views/master-data/countries/create')
                                },
                                {
                                    path: 'detail/:countryId',
                                    name: 'country_detail',
                                    meta: { label: 'Thông tin quốc gia', requiresAuth: true, requiresPrivileges: ['ViewCountry', 'ManageCountry'] },
                                    component: () => import('@/views/master-data/countries/detail')
                                }
                            ]
                        },
                        {
                            path: 'regions',
                            name: 'regions',
                            redirect: '/master-data/regions/list',
                            meta: { label: 'Danh mục địa bàn' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'region_list',
                                    meta: { label: 'Danh sách địa bàn', requiresAuth: true, requiresPrivileges: ['ViewRegion'] },
                                    component: () => import('@/views/master-data/regions/list')
                                },
                                {
                                    path: 'create',
                                    name: 'create_region',
                                    meta: { label: 'Thêm mới địa bàn', requiresAuth: true, requiresPrivileges: ['ManageRegion'] },
                                    component: () => import('@/views/master-data/regions/create')
                                },
                                {
                                    path: 'detail/:regionId',
                                    name: 'region_detail',
                                    meta: { label: 'Thông tin địa bàn', requiresAuth: true, requiresPrivileges: ['ViewRegion', 'ManageRegion'] },
                                    component: () => import('@/views/master-data/regions/detail')
                                }
                            ]
                        },
                        {
                            path: 'asset-types',
                            name: 'asset_types',
                            redirect: '/master-data/asset-types/list',
                            meta: { label: 'Nhóm tài sản' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'asset_type_list',
                                    meta: { label: 'Danh mục nhóm tài sản', requiresAuth: true, requiresPrivileges: ['ViewAssetType'] },
                                    component: () => import('@/views/master-data/asset-types/list')
                                },
                                {
                                    path: 'create',
                                    name: 'asset_type_create',
                                    meta: { label: 'Thêm mới loại tài sản', requiresAuth: true, requiresPrivileges: ['ManageAssetType'] },
                                    component: () => import('@/views/master-data/asset-types/create')
                                },
                                {
                                    path: 'edit/:assetTypeId',
                                    name: 'asset_type_edit',
                                    meta: { label: 'Cập nhật loại tài sản', requiresAuth: true, requiresPrivileges: ['ManageAssetType'] },
                                    component: () => import('@/views/master-data/asset-types/edit')
                                }
                            ]
                        },
                        {
                            path: 'increasement-causes',
                            name: 'increasement_causes',
                            redirect: '/master-data/increasement-causes/list',
                            meta: { label: 'Lý do tăng' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'increasement_cause_list',
                                    meta: { label: 'Danh mục lí do tăng', requiresAuth: true, requiresPrivileges: ['ViewIncreasementCause'] },
                                    component: () => import('@/views/master-data/increasement-causes/list')
                                },
                                {
                                    path: 'create',
                                    name: 'increasement_cause_create',
                                    meta: { label: 'Thêm mới lí do tăng', requiresAuth: true, requiresPrivileges: ['ManageIncreasementCause'] },
                                    component: () => import('@/views/master-data/increasement-causes/create')
                                },
                                {
                                    path: 'detail/:increasementCauseId',
                                    name: 'increment_cause_detail',
                                    meta: { label: 'Thông tin lí do tăng', requiresAuth: true, requiresPrivileges: ['ManageUser'] },
                                    component: () => import('@/views/master-data/increasement-causes/detail')
                                },
                            ]
                        },
                        {
                            path: 'decreasement-causes',
                            name: 'decreasement_causes',
                            redirect: '/master-data/decreasement-causes/list',
                            meta: { label: 'Lý do giảm' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'decreasement_cause_list',
                                    meta: { label: 'Danh mục lí do giảm', requiresAuth: true, requiresPrivileges: ['ViewDecreasementCause'] },
                                    component: () => import('@/views/master-data/decreasement-causes/list')
                                },
                                {
                                    path: 'create',
                                    name: 'decreasement_cause_create',
                                    meta: { label: 'Thêm mới lí do giảm', requiresAuth: true, requiresPrivileges: ['ManageDecreasementCause'] },
                                    component: () => import('@/views/master-data/decreasement-causes/create')
                                },
                                {
                                    path: 'detail/:decreasementCauseId',
                                    name: 'decrement_cause_detail',
                                    meta: { label: 'Thông tin lí do giảm', requiresAuth: true, requiresPrivileges: ['ManageUser'] },
                                    component: () => import('@/views/master-data/decreasement-causes/detail')
                                },
                            ]
                        },
                        {
                            path: 'asset-sources',
                            name: 'asset_sources',
                            redirect: '/master-data/asset-sources/list',
                            meta: { label: 'Nguồn gốc hình thành tài sản' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'asset_source_list',
                                    meta: { label: 'Danh mục nguồn hình thành tài sản', requiresAuth: true, requiresPrivileges: ['ViewAssetSource'] },
                                    component: () => import('@/views/master-data/asset-sources/list')
                                },
                                {
                                    path: 'create',
                                    name: 'asset_source_create',
                                    meta: { label: 'Thêm mới nguồn hình thành tài sản', requiresAuth: true, requiresPrivileges: ['ManageUser'] },
                                    component: () => import('@/views/master-data/asset-sources/create')
                                },
                                {
                                    path: 'detail/:assetSourceId',
                                    name: 'asset_source_detail',
                                    meta: { label: 'Thông tin nguồn hình thành tài sản', requiresAuth: true, requiresPrivileges: ['ManageUser'] },
                                    component: () => import('@/views/master-data/asset-sources/detail')
                                },
                            ]
                        },
                        {
                            path: 'asset-usage-states',
                            name: 'asset_usage_states',
                            redirect: '/master-data/asset-usage-states/list',
                            meta: { label: 'Hiện trạng sử dụng' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'asset_usage_states_list',
                                    meta: { label: 'Danh mục hiện trạng sử dụng', requiresAuth: true, requiresPrivileges: ['ViewAssetSource'] },
                                    component: () => import('@/views/master-data/asset-usage-states/list')
                                },
                                {
                                    path: 'create',
                                    name: 'asset_usage_states_create',
                                    meta: { label: 'Thêm mới hiện trạng sử dụng', requiresAuth: true, requiresPrivileges: ['ManageUser'] },
                                    component: () => import('@/views/master-data/asset-usage-states/create')
                                },
                                {
                                    path: 'detail/:assetUsageStateId',
                                    name: 'asset_usage_states_detail',
                                    meta: { label: 'Thông tin hiện trạng sử dụng', requiresAuth: true, requiresPrivileges: ['ManageUser'] },
                                    component: () => import('@/views/master-data/asset-usage-states/detail')
                                },
                            ]
                        },
                        {
                            path: 'asset-usage-purposes',
                            name: 'asset_usage_purposes',
                            redirect: '/master-data/asset-usage-purposes/list',
                            meta: { label: 'Mục đích sử dụng' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'asset_usage_purposes_list',
                                    meta: { label: 'Danh mục mục đích sử dụng', requiresAuth: true, requiresPrivileges: ['ViewAssetSource'] },
                                    component: () => import('@/views/master-data/asset-usage-purposes/list')
                                },
                                {
                                    path: 'create',
                                    name: 'asset_usage_purposes_create',
                                    meta: { label: 'Thêm mới hiện trạng sử dụng', requiresAuth: true, requiresPrivileges: ['ManageUser'] },
                                    component: () => import('@/views/master-data/asset-usage-purposes/create')
                                },
                                {
                                    path: 'detail/:assetUsagePurposeId',
                                    name: 'asset_usage_purposes_detail',
                                    meta: { label: 'Thông tin hiện trạng sử dụng', requiresAuth: true, requiresPrivileges: ['ManageUser'] },
                                    component: () => import('@/views/master-data/asset-usage-purposes/detail')
                                },
                            ]
                        },
                    ]
                },
                {
                    path: 'manage-data',
                    name: 'manage_data',
                    redirect: '/manage-data/assets',
                    meta: { label: 'Quản lý dữ liệu' },
                    component: {
                        render(c) { return c('router-view') }
                    },
                    children: [
                        {
                            path: 'assets',
                            name: 'assets',
                            redirect: '/manage-data/assets/list',
                            meta: { label: 'Tài sản' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'assets_list',
                                    meta: { label: 'Danh sách tài sản', requiresAuth: true, requiresPrivileges: ['ViewAsset'] },
                                    component: () => import('@/views/manage-data/assets/list')
                                },
                                {
                                    path: 'detail/:assetId',
                                    name: 'assets_detail',
                                    meta: { label: 'Thông tin tài sản', requiresAuth: true, requiresPrivileges: ['ManageAsset'] },
                                    component: () => import('@/views/manage-data/assets/detail')
                                },

                            ]
                        },
                        {
                            path: 'asset-mutations',
                            name: 'asset-mutations',
                            redirect: '/manage-data/asset-mutations/list',
                            meta: { label: 'Biến động' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'asset_mutations_list',
                                    meta: { label: 'Danh sách biến động tài sản', requiresAuth: true, requiresPrivileges: ['ViewAssetMutation'] },
                                    component: () => import('@/views/manage-data/asset-mutations/list')
                                },
                                {
                                    path: 'list/:assetId',
                                    name: 'asset_mutations_list_asset_id',
                                    meta: { label: 'Danh sách biến động tài sản', requiresAuth: true, requiresPrivileges: ['ViewAssetMutation'] },
                                    component: () => import('@/views/manage-data/asset-mutations/list')
                                },
                                {
                                    path: 'detail/:assetMutationId',
                                    name: 'asset_mutations_detail',
                                    meta: { label: 'Thông tin biến động tài sản', requiresAuth: true, requiresPrivileges: ['ManageAssetMutation'] },
                                    component: () => import('@/views/manage-data/asset-mutations/detail')
                                },
                            ]
                        },
                        {
                            path: 'reports',
                            name: 'reports',
                            redirect: '/manage-data/reports/list',
                            meta: { label: 'Báo cáo' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'reports_list',
                                    meta: { label: 'Danh sách báo cáo', requiresAuth: true, requiresPrivileges: ['ViewReport'] },
                                    component: () => import('@/views/manage-data/reports/list')
                                },
                                {
                                    path: 'detail/:reportId',
                                    name: 'reports_detail',
                                    meta: { label: 'Thông tin báo cáo', requiresAuth: true, requiresPrivileges: ['ManageReport'] },
                                    component: () => import('@/views/manage-data/reports/detail')
                                },
                            ]
                        },
                    ]
                },
                {
                    path: 'search',
                    name: 'search',
                    redirect: '/search/synced-assets',
                    meta: { label: 'Tra cứu tài sản' },
                    component: {
                        render(c) { return c('router-view') }
                    },
                    children: [
                        {
                            path: 'synced-assets',
                            name: 'synced-assets',
                            redirect: '/search/synced-assets/list',
                            meta: { label: 'Tra cứu tài sản' },
                            component: {
                                render(c) { return c('router-view') }
                            },
                            children: [
                                {
                                    path: 'list',
                                    name: 'synced_assets_list',
                                    meta: { label: 'Danh sách tài sản', requiresAuth: true, requiresPrivileges: ['ViewAsset'] },
                                    component: () => import('@/views/search/synced-assets/list')
                                },
                                {
                                    path: 'detail/:syncedAssetsId',
                                    name: 'synced_assets_detail',
                                    meta: { label: 'Thông tin tài sản', requiresAuth: true, requiresPrivileges: ['ManageUser'] },
                                    component: () => import('@/views/search/synced-assets/detail')
                                },

                            ]
                        },

                    ]
                },
                {
                    path: 'logs',
                    name: 'logs',
                    redirect: '/logs/action-logs',
                    meta: { label: 'Nhật ký hệ thống' },
                    component: {
                        render(c) { return c('router-view') }
                    },
                    children: [{
                        path: 'action-logs',
                        name: 'action_logs',
                        redirect: '/logs/action-logs/list',
                        meta: { label: 'Nhật ký thao tác dữ liệu' },
                        component: {
                            render(c) { return c('router-view') }
                        },
                        children: [{
                            path: 'list',
                            name: 'action_logs_list',
                            meta: { label: 'Danh sách nhật ký hệ thống', requiresAuth: true, requiresPrivileges: ['ViewUnit'] },
                            component: () => import('@/views/logs/action-logs/list')
                        }]
                    }]
                }
            ]
        },
        {
            path: '/login',
            name: 'login',
            component: Login
        },
        {
            path: '*',
            component: Page404
        }
    ]
})

router.beforeEach((to, from, next) => {
    var isAuthorized = true;
    for (var i = 0; i < to.matched.length; i++) {
        var route = to.matched[i];

        if (route.meta.requiresAuth) {
            // Check if this route require authentication
            if (!store.state.identity.isAuthenticated) {
                isAuthorized = false;
                break;
            }
            // Check if this route require admin permission
            else if (route.meta.adminOnly && !store.state.identity.isAdministrator) {
                isAuthorized = false;
                break;
            }
            // Check if this route require certain privileges
            else if (route.meta.requiresPrivileges && route.meta.requiresPrivileges.length > 0
                && intersect(store.state.identity.privileges, route.meta.requiresPrivileges).length == 0) {
                isAuthorized = false;
                break;
            }
        }
    }

    if (isAuthorized) {
        next();
    } else {
        next('/login');
    }
});

export default router;
