<template>
  <div class="menu-wrapper">
    <template v-if="item.isLeaf">
      <app-link :to="item.path">
        <el-menu-item :index="item.code" :class="{'submenu-title-noDropdown':!item.isLeaf}">
          <item :icon="item.icon" :title="item.name" />
        </el-menu-item>
      </app-link>
    </template>
    <el-submenu v-else ref="subMenu" :index="item.code" popper-append-to-body>
      <template slot="title">
        <item :icon="item.icon" :title="item.name" />
      </template>
      <sidebar-item
        v-for="child in item.children"
        :key="child.code"
        :is-nest="true"
        :item="child"
        class="nest-menu"
      />
    </el-submenu>
  </div>
</template>

<script>
// import path from 'path'
// import { isExternal } from '@/utils/validate'
import Item from './Item'
import AppLink from './Link'
import FixiOSBug from './FixiOSBug'

export default {
  name: 'SidebarItem',
  components: { Item, AppLink },
  mixins: [FixiOSBug],
  props: {
    item: {
      type: Object,
      required: true
    },
    isNest: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {}
  },
  methods: {
    findRouter() {
      return {}
    }
  }
}
</script>
