<template>
  <thead class="edit-table-header">
    <tr>
      <th v-if="indexed" style="width: 60px;">序号</th>
      <th
        v-for="col in columns"
        :key="col.prop"
        :align="col.theadAlign || alignDefaults[col.type || 'string']"
        :style="getThStyles(col)"
      >
        {{ col.label }}
        <span v-if="col.required" style="color: #f56c6c;">*</span>
      </th>
      <th style="width: 100px">操作</th>
    </tr>
  </thead>
</template>

<script>
import { alignDefaults }from './defaults'
export default {
  name: 'EditTableHeader',
  data() {
    return {
      alignDefaults
    }
  },
  props: {
    columns: {
      type: Array,
      default: () => []
    },
    indexed: {
      type: Boolean,
      default: false
    }
  },
  methods: {
    getThStyles(col) {
      const styles = { }
      if (col.width) {
        if (typeof col.width === 'number') {
          styles.width = col.width + 'px'
        }else {
          styles.width = col.width
        }
      }
      return styles
    }
  }
}
</script>
