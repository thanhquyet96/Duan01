<template>
    <div class="app">
        <AppHeader fixed>
            <SidebarToggler class="d-lg-none" display="md" mobile />
            <b-link class="navbar-brand" to="#">
                <img class="navbar-brand-full" src="static/img/brand/logo.png" height="25" alt="Logo"> &nbsp; Bộ Tài chính
                <img class="navbar-brand-minimized" src="static/img/brand/logo.png" width="30" height="30" alt="Logo">
            </b-link>
            <SidebarToggler class="d-md-down-none" display="md" />
            <!--<b-navbar-nav class="d-md-down-none">
                <b-nav-item class="px-3">Dashboard</b-nav-item>
                <b-nav-item class="px-3">Users</b-nav-item>
                <b-nav-item class="px-3">Settings</b-nav-item>
            </b-navbar-nav>-->
            <b-navbar-nav class="ml-auto">
                <!--<b-nav-item class="d-md-down-none">
                    <i class="icon-bell"></i>
                    <b-badge pill variant="danger">5</b-badge>
                </b-nav-item>
                <b-nav-item class="d-md-down-none">
                    <i class="icon-list"></i>
                </b-nav-item>
                <b-nav-item class="d-md-down-none">
                    <i class="icon-location-pin"></i>
                </b-nav-item>-->
                <AppHeaderDropdown right no-caret>
                    <template slot="button-content">
                        <img src="static/img/avatars/default.png"
                             class="img-avatar"
                             alt="hungnl00164@gmail.com" />
                    </template>
                    <div>
                        <!--
                        <b-dropdown-header tag="div" class="text-center"><strong>Account</strong></b-dropdown-header>
                        <b-dropdown-item>
                            <i class="fa fa-bell-o" /> Updates
                            <b-badge variant="info">{{ itemsCount }}</b-badge>
                        </b-dropdown-item>
                        <b-dropdown-item>
                            <i class="fa fa-envelope-o" /> Messages
                            <b-badge variant="success">{{ itemsCount }}</b-badge>
                        </b-dropdown-item>
                        <b-dropdown-item>
                            <i class="fa fa-tasks" /> Tasks
                            <b-badge variant="danger">{{ itemsCount }}</b-badge>
                        </b-dropdown-item>
                        <b-dropdown-item>
                            <i class="fa fa-comments" /> Comments
                            <b-badge variant="warning">{{ itemsCount }}</b-badge>
                        </b-dropdown-item>-->
                        <b-dropdown-header tag="div" class="text-center">
                            ce
                            <strong>Settings</strong>
                        </b-dropdown-header>
                        <b-dropdown-item :to="{ path: '/profile' }"><i class="fa fa-user" /> Profile</b-dropdown-item>
                        <!--<b-dropdown-item><i class="fa fa-wrench" /> Settings</b-dropdown-item>
                        <b-dropdown-item>
                            <i class="fa fa-usd" /> Payments
                            <b-badge variant="secondary">{{ itemsCount }}</b-badge>
                        </b-dropdown-item>
                        <b-dropdown-item>
                            <i class="fa fa-file" /> Projects
                            <b-badge variant="primary">{{ itemsCount }}</b-badge>
                        </b-dropdown-item>-->
                        <b-dropdown-divider />
                        <!--<b-dropdown-item><i class="fa fa-shield" /> Lock Account</b-dropdown-item>-->
                        <!--<b-dropdown-item><i class="fa fa-lock" /> Logout</b-dropdown-item>-->
                        <a role="menuitem" href="#" target="_self" class="dropdown-item" @click.prevent="logout"><i class="fa fa-lock"></i> Logout</a>
                    </div>
                </AppHeaderDropdown>
            </b-navbar-nav>
            <!--<AsideToggler class="d-none d-lg-block" />-->
            <!--<AsideToggler class="d-lg-none" mobile />-->
        </AppHeader>
        <div class="app-body">
            <AppSidebar fixed>
                <SidebarHeader />
                <SidebarForm />
                <SidebarNav :navItems="nav"></SidebarNav>
                <SidebarFooter />
                <SidebarMinimizer />
            </AppSidebar>
            <main class="main">
                <breadcrumb :list="list" />
                <div class="container-fluid">
                    <router-view></router-view>
                </div>
            </main>
            <!--<AppAside fixed>
                <DafaultAside />
            </AppAside>-->
        </div>
        <TheFooter>
            <!--footer-->
        </TheFooter>
    </div>
</template>
<script>
    import nav from '../_nav'
    import { sidebarCssClasses } from '@coreui/vue/src/shared/classes'
    import { Header as AppHeader, HeaderDropdown as AppHeaderDropdown, SidebarToggler, Sidebar as AppSidebar, SidebarFooter, SidebarForm, SidebarHeader, SidebarMinimizer, SidebarNav, Aside as AppAside, AsideToggler, Footer as TheFooter, Breadcrumb } from '@coreui/vue'
    // import { Header as AppHeader, HeaderDropdown as AppHeaderDropdown, SidebarToggler, Sidebar as AppSidebar, SidebarFooter, SidebarForm, SidebarHeader, SidebarMinimizer, SidebarNav, Aside as AppAside, AsideToggler, Breadcrumb } from '../components/'
    // import { Footer as TheFooter } from '@coreui/vue'
    import DafaultAside from './DafaultAside'
    import { transcode } from 'buffer';
    import { Array } from 'core-js';

    export default {
        name: 'full',
        components: {
            AsideToggler,
            AppHeader,
            AppHeaderDropdown,
            AppSidebar,
            AppAside,
            TheFooter,
            Breadcrumb,
            DafaultAside,
            SidebarForm,
            SidebarFooter,
            SidebarToggler,
            SidebarHeader,
            SidebarNav,
            SidebarMinimizer
        },
        data() {
            return {
                itemsCount: 42,
                breadcrumbKey: 0
            }
        },
        computed: {
            name() {
                return this.$route.name
            },
            list() {
                var routes = this.$route.matched;

                return routes.slice(1);
            },
            nav() {
                var navItems = JSON.parse(JSON.stringify(nav.items));
                var privileges = this.$store.state.identity.privileges;

                RemoveUnauthorizedItems(navItems);

                function RemoveUnauthorizedItems(items) {
                    if (items && items.length > 0) {
                        for (var i = items.length - 1; i >= 0; i--) {
                            var item = items[i];

                            var requiresPrivileges = item.requiresPrivileges || [];
                            if (item.children && item.children.length > 0) {
                                requiresPrivileges = requiresPrivileges.concat(item.children.map(x => x.requiresPrivileges).reduce((x, y) => (x || []).concat(y || [])));
                            }

                            if (requiresPrivileges && requiresPrivileges.length > 0
                                && intersect(privileges, requiresPrivileges).length == 0) {
                                items.remove(item);
                            } else {
                                RemoveUnauthorizedItems(item.children);
                            }
                        }
                    }
                }

                return navItems;
            },
        },
        created() {
            // reset sidebar's state
            sidebarCssClasses.map((className) => document.body.classList.remove(className));
        },
        methods: {
            logout() {
                var vm = this;
                this.$store.dispatch('deauthenticate');
                vm.$router.push({ path: '/login' });
            }
        }
    }
</script>
