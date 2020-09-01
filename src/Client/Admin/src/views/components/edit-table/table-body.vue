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
          <td 
            class="edit-table-body-cell" 
            :key="col.prop" 
            :align="col.align || alignDefaults[col.type || 'text']"
            :style="getTdStyles(col)" 
            @click.stop="cellClick($event, row, index, col)">
            <template v-if="col.type == 'index'">
              {{ index + 1 }}
            </template>
            <template v-else-if="col.type == 'checkbox'">
              <el-checkbox v-model="row[col.prop]"></el-checkbox>
            </template>
            <template v-else-if="col.type == 'select'">
              <el-select v-model="row[col.prop]" :placeholder="col.placeholder || '请选择'">
                <el-option v-for="option in col.options" :key="option.value" :value="option.value" :label="option.label"></el-option>
              </el-select>
            </template>
            <template v-else-if="col.type == 'date'">
              <el-date-picker v-model="row[col.prop]" type="date" :placeholder="col.placeholder || '选择日期'"></el-date-picker>
            </template>
            <template v-else-if="col.type == 'handler'">
              <template v-for="(action, index) in col.actions">
                <template v-if="typeof action === 'string' && action === 'delete'">
                  <el-button :key="index" @click="deleteRow(index)" icon="el-icon-delete">删除</el-button>
                </template>
              </template>
            </template>
            <template v-else>
              <el-input v-model="row[col.prop]" :placeholder="col.placeholder || '请输入'"></el-input>
            </template>
          </td>
        </template>
      </template>
      <template v-else>
        <template v-for="col in columns">
          <td 
            class="edit-table-body-cell" 
            :key="col.prop" 
            :align="col.align || alignDefaults[col.type || 'text']"
            :style="getTdStyles(col)" 
            @click.stop="cellClick($event, row, index, col)">
            <template v-if="col.type == 'index'">
              {{ index + 1 }}
            </template>
            <template v-else-if="col.type == 'checkbox'">
              <el-checkbox v-model="row[col.prop]"></el-checkbox>
            </template>
            <template v-else-if="col.type == 'select'">
              {{ getSelectLabel(col.options, row[col.prop]) }}
            </template>
            <template v-else-if="col.type == 'date'">
              {{ formatDate(row[col.prop], 'yyyy-MM-dd') }}
            </template>
            <template v-else-if="col.type == 'handler'">
              
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
const alignDefaults = {
  'text': 'left',
  'index': 'center',
  'checkbox': 'center',
  'select': 'left',
  'date': 'left'
}
import { formatDate } from '../../../utils/index'
export default {
  name: 'EditTableBody',
  data() {
    return {
      formatDate,
      data: this.value,
      editRowIndex: -1,
      currentRowIndex: -1,
      alignDefaults,
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
      if (this.editRowIndex !== index) {
        this.editRowIndex = index
        this.$nextTick(() => {
          if (event.currentTarget.firstChild 
            && event.currentTarget.firstChild.firstElementChild
            && event.currentTarget.firstChild.firstElementChild.nodeName === 'INPUT') {
            event.currentTarget.firstChild.firstElementChild.focus()
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
    },
    getSelectLabel(options, value) {
      const option = options.find(o => o.value == value)
      return option ? option.label : ''
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
