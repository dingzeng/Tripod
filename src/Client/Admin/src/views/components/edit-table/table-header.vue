<template>
  <thead class="edit-table-header">
    <tr>
      <th
        v-for="col in columns"
        :key="col.prop"
        :style="getThStyles(col)"
      >
        {{ col.label }}
      </th>
    </tr>
  </thead>
</template>

<script>
export default {
  name: 'EditTableHeader',
  data() {
    return {

    }
  },
  props: {
    columns: {
      type: Array,
      default: () => []
    }
  },
  methods: {
    getThStyles(col) {
      const styles = { }
      if (col.width) {
        if (typeof col.width === 'number') {
          styles.width = col.width + 'px'
        } else {
          styles.width = col.width
        }
      }
      return styles
    }
  }
}
</script>
