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
          <td class="edit-table-body-cell" :key="col.prop" :style="getTdStyles(col)" @click.stop="cellClick($event, row, index, col)">
            <template v-if="col.type == 'index'">
              {{ index + 1 }}
            </template>
            <template v-else-if="col.type == 'checkbox'">
              <el-checkbox v-model="row[col.prop]"></el-checkbox>
            </template>
            <template v-else-if="col.type == 'select'">
              <el-select v-model="row[col.prop]">
                <el-option v-for="(value, key) in col.options" :key="key" :value="key" :label="value"></el-option>
              </el-select>
            </template>
            <template v-else-if="col.type == 'date'">
              <el-date-picker v-model="row[col.prop]" type="date"></el-date-picker>
            </template>
            <template v-else>
              <el-input v-model="row[col.prop]"></el-input>
            </template>
          </td>
        </template>
      </template>
      <template v-else>
        <template v-for="col in columns">
          <td class="edit-table-body-cell" :key="col.prop" :style="getTdStyles(col)" @click.stop="cellClick($event, row, index, col)">
            <template v-if="col.type == 'index'">
              {{ index + 1 }}
            </template>
            <template v-else-if="col.type == 'checkbox'">
              <el-checkbox v-model="row[col.prop]" disabled></el-checkbox>
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

    },
    rowMouseover(event, row, index) {
      this.currentRowIndex = index
    },
    cellClick(event, row, index, col) {
      if (this.editRowIndex != index) {
        this.editRowIndex = index
        this.$nextTick(() => {
          if (event.currentTarget.firstChild && event.currentTarget.firstChild.nodeName == 'INPUT') {
            event.currentTarget.firstChild.focus()
          }
        })
      }
    },
    getTdStyles(col) {
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
