<template>
  <tbody class="edit-table-body">
    <tr
      class="edit-table-body-tr"
      :class="[{
        'edit-table-body-tr-hover': index == currentRowIndex
      }]"
      v-for="(row, index) in data"
      :key="index"
      :style="rowStyles"
      @click="rowClick($event, row, index)"
      @mouseover="rowMouseover($event, row, index)"
      @mouseout="currentRowIndex = -1"
    >
      <template v-if="index === editRowIndex">
        <template v-for="col in columns">
          <td class="edit-table-body-cell" :key="col.prop">
            <template v-if="col.type == 'index'">
              {{ index + 1 }}
            </template>
            <template v-else-if="col.type == 'checkbox'">
              <input type="checkbox" v-model="row[col.prop]">
            </template>
            <template v-else-if="col.type == 'select'">
              <select v-model="row[col.prop]">
                <option v-for="(value, key) in col.options" :key="key" :value="key">{{ value }}</option>
              </select>
            </template>
            <template v-else-if="col.type == 'date'">
              <input type="date" v-model="row[col.prop]">
            </template>
            <template v-else>
              <input type="text" v-model="row[col.prop]">
            </template>
          </td>
        </template>
      </template>
      <template v-else>
        <template v-for="col in columns">
          <td class="edit-table-body-cell" :key="col.prop">
            <template v-if="col.type == 'index'">
              {{ index + 1 }}
            </template>
            <template v-else-if="col.type == 'checkbox'">
              <input type="checkbox" v-model="row[col.prop]" readonly>
            </template>
            <template v-else-if="col.type == 'select'">
              {{ col.options[row[col.prop]] }}
            </template>
            <template v-else-if="col.type == 'date'">
              {{ row[col.prop] }}
            </template>
            <template v-else>
              {{ row[col.prop] }}
            </template>
          </td>
        </template>
      </template>
    </tr>
  </tbody>
</template>

<script>
export default {
  name: 'EditTableBody',
  data() {
    return {
      data: this.value,
      editRowIndex: -1,
      currentRowIndex: -1
    }
  },
  props: {
    value: {
      type: Array,
      default: () => []
    },
    columns: {
      type: Array,
      default: () => []
    }
  },
  methods: {
    rowClick(event, row, index) {
      this.editRowIndex = index
    },
    rowMouseover(event, row, index) {
      this.currentRowIndex = index
    }
  },
  computed: {
    rowStyles() {
      const styles = {}
      return styles
    }
  },
  watch: {
    value(value) {
      this.data = value
    },
    data(value) {
      this.$emit('input', value)
    }
  }
}
</script>
