<template>
    <CSidebar fixed
              :minimize="minimize"
              :show="show"
              @update:show="(value) => $store.commit('set', ['sidebarShow', value])">
        <CSidebarBrand class="d-md-down-none" to="/">
            <img class="navbar-brand-full" src="/img/logo.png" height="35" alt="Logo" style="padding-right: 5px">
            <template v-if="!minimize">
                Bộ Tài chính
            </template>
        </CSidebarBrand>

        <CRenderFunction flat :content-to-render="$options.nav" />
        <CSidebarMinimizer class="d-md-down-none"
                           @click.native="$store.commit('set', ['sidebarMinimize', !minimize])" />
    </CSidebar>
</template>

<script>
    import nav from './_nav'

    export default {
        name: 'TheSidebar',
        nav,
        computed: {
            show() {
                return this.$store.state.common.sidebarShow
            },
            minimize() {
                return this.$store.state.common.sidebarMinimize
            }
        }
    }
</script>
