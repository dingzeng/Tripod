<template>
  <div>
    <div :class="prefix + 'top'">
      <el-row type="flex" justify="space-between">
        <el-col :span="16">
          <div :class="prefix + 'top-left'">
            <slot name="topLeft"></slot>
          </div>
        </el-col>
        <el-col :span="8">
          <div :class="prefix + 'top-right'">
            <slot name="topRight"></slot>
          </div>
        </el-col>
      </el-row>
    </div>
    <div :class="prefix + 'main'">
      <slot></slot>
    </div>
    <div :class="prefix + 'footer'">
      <slot name="footer"></slot>
    </div>
  </div>
</template>

<script>
const prefix = 'app-list-layout-'
export default {
  name: 'ListLayout',
  data() {
    return {
      prefix: prefix
    }
  },
  methods: {}
}
</script>

<style lang="scss" scoped>
$prefix: "app-list-layout-";
.#{$prefix}top {
  padding: 10px 10px;
  .#{$prefix}top-right {
    text-align: right;
  }
}
.#{$prefix}footer {
  position: absolute;
  bottom: 0px;
  right: 0px;
}
</style>
