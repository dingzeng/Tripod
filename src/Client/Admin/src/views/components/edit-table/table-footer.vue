<template>
  <tfoot class="edit-table-footer">
    <tr>
      <td
        v-for="col in columns"
        :key="col.prop"
      >
        {{ getTotal(col.prop) }}
      </td>
    </tr>
  </tfoot>
</template>

<script>
export default {
  name: 'EditTableFooter',
  data() {
    return {}
  },
  methods: {
    getTotal(prop) {
      return this.totalData && this.totalData[prop] ? this.totalData[prop] : ''
    }
  },
  props: {
    totalData: {
      type: Object,
      default: () => {}
    },
    columns: {
      type: Array,
      default: () => []
    }
  }
}
</script>
