<style>
  .is-error .el-input__inner {
    border-color: #f56c6c;
  }
</style>
<template>
  <tbody class="edit-table-body">
    <tr
      class="edit-table-body-tr"
      :class="[{
        'edit-table-body-tr-hover': index === currentRowIndex || index === editRowIndex
      }]"
      v-for="(row, index) in data"
      :key="index"
      :style="rowStyles"
      @click="handleRowClick($event, row, index)"
      @keydown="handleRowKeydown($event, row, index)"
      @mouseover="handleRowMouseover($event, row, index)"
      @mouseout="currentRowIndex = -1"
    >
      <!-- 序号 -->
      <td v-if="indexed" align="center" style="width: 60px;">{{ index + 1 }}</td>
      <!-- 编辑行 -->
      <template v-if="index === editRowIndex">
        <template v-for="col in columns">
          <td
            class="edit-table-body-cell"
            :class="[{ 'is-error': validateStatus[col.prop] === false }]"
            :key="col.prop"
            :align="col.align || alignDefaults[col.type || 'string']"
            :style="getTdStyles(col)"
            @click.stop="handleCellClick($event, row, index, col)"
          >
            <template v-if="col.type == 'boolean'">
              <el-switch
                :disabled="!col.editable"
                v-model="row[col.prop]"
                @change="validateCell(row, col)"
              >
              </el-switch>
            </template>
            <template v-else-if="col.type == 'enum'">
              <el-select
                v-if="col.editable"
                v-model="row[col.prop]"
                :placeholder="col.placeholder || '请选择'"
                @change="validateCell(row, col)"
              >
                <el-option
                  v-for="option in col.options"
                  :key="option.value"
                  :value="option.value"
                  :label="option.label"
                >
                </el-option>
              </el-select>
              <span v-else>
                {{ getSelectLabel(col.options, row[col.prop]) }}
              </span>
            </template>
            <template v-else-if="col.type == 'date'">
              <el-date-picker
                v-model="row[col.prop]"
                type="date"
                :readonly="!col.editable"
                :placeholder="col.placeholder || '选择日期'"
                @change="validateCell(row, col)"
              >
              </el-date-picker>
            </template>
            <template v-else>
              <template v-if="col.editable">
                <el-input
                  v-if="col.type == 'number' || col.type == 'integer' || col.type == 'float'"
                  v-model.number="row[col.prop]"
                  :placeholder="col.placeholder || '请输入'"
                  @blur="validateCell(row, col)"
                >
                </el-input>
                <!-- string、url、email -->
                <el-input
                  v-else
                  v-model.trim="row[col.prop]"
                  :placeholder="col.placeholder || '请输入'"
                  @blur="validateCell(row, col)"
                >
                </el-input>
              </template>
              <span v-else>
                {{ row[col.prop] }}
              </span>
            </template>
          </td>
        </template>
      </template>
      <template v-else>
        <template v-for="col in columns">
          <td
            class="edit-table-body-cell"
            :key="col.prop"
            :align="col.align || alignDefaults[col.type || 'string']"
            :style="getTdStyles(col)"
            @click.stop="handleCellClick($event, row, index, col)"
          >
            <template v-if="col.type == 'boolean'">
              <el-switch disabled v-model="row[col.prop]"></el-switch>
            </template>
            <template v-else-if="col.type == 'enum'">
              {{ getSelectLabel(col.options, row[col.prop]) }}
            </template>
            <template v-else-if="col.type == 'date'">
              {{ formatDate(row[col.prop], 'yyyy-MM-dd') }}
            </template>
            <template v-else>
              {{ row[col.prop] }}
            </template>
          </td>
        </template>
      </template>
      <!-- 操作 -->
      <!-- TODO 操作列的宽度处理 -->
      <td align="center" style="width: 100px">
        <el-button type="text" @click="deleteRow(index)" icon="el-icon-delete" size="mini"></el-button>
        <template v-for="(action, indexKey) in actions">
          <el-button
            v-if="!action.visible || action.visible(row)"
            :key="indexKey"
            :type="action.type"
            :icon="action.icon"
            @click="action.click(row)"
          >
            {{ action.label }}
          </el-button>
        </template>
      </td>
    </tr>
  </tbody>
</template>

<script>
import { alignDefaults } from './defaults'
import { formatDate } from '../../../utils/index'
import Schema from 'async-validator'
export default {
  name: 'EditTableBody',
  data() {
    return {
      formatDate,
      data: this.value,
      editRowIndex: -1,
      currentRowIndex: -1,
      alignDefaults,
      validateStatus: {}, // 编辑行的验证状态
      keyword: ''
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
    },
    indexed: {
      type: Boolean,
      default: false
    },
    actions: {
      type: Array,
      default: () => []
    }
  },
  methods: {
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
      const option = options.find(o => o.value === value)
      return option ? option.label : ''
    },
    handleRowClick(event, row, index) {

    },
    handleRowKeydown(event, row, index) {
      console.log(event, row, index)
      if (event.code === 'ArrowDown') {
        if (this.editRowIndex === this.data.length - 1) {
          this.data.push({})
        }
        this.changeEditRowIndex(this.editRowIndex + 1)
      } else if (event.code === 'ArrowUp') {
        if (this.editRowIndex > 0) {
          this.changeEditRowIndex(this.editRowIndex - 1)
        }
      }
    },
    handleRowMouseover(event, row, index) {
      this.currentRowIndex = index
    },
    handleCellClick(event, row, index, col) {
      this.changeEditRowIndex(index, () => {
        // auto focus
        this.$nextTick(() => {
          if (event.target &&
            event.target.firstChild &&
            event.target.firstChild.firstElementChild &&
            event.target.firstChild.firstElementChild.nodeName === 'INPUT') {
            event.target.firstChild.firstElementChild.focus()
          }
        })
      })
    },
    changeEditRowIndex(index, callback) {
      if (this.editRowIndex === index) return
      if (this.editRowIndex === -1) {
        this.editRowIndex = index
        callback()
      } else {
        this.validateRow(this.data[this.editRowIndex], (rowPasswd) => {
          if (rowPasswd) {
            this.editRowIndex = index
            this.validateStatus = {}
            callback()
          }
        })
      }
    },
    deleteRow(index) {
      if (index === this.editRowIndex) {
        this.editRowIndex = -1
        this.validateStatus = {}
      }
      this.data.splice(index, 1)
    },
    validateRow(row, callback) {
      if (!row) return
      const descriptor = this.getRowValidateDescriptor(row)
      const validator = new Schema(descriptor)
      let rowPasswd = true
      validator.validate(row, { firstFields: true }, (errors, fields) => {
        if (errors) {
          this.columns.filter(col => col.editable).forEach(col => {
            const passed = !fields.hasOwnProperty(col.prop)
            this.$set(this.validateStatus, col.prop, passed)
            if (!passed) {
              rowPasswd = false
            }
          })
        }
        callback(rowPasswd)
      })
    },
    validateCell(row, col) {
      const descriptor = {}
      descriptor[col.prop] = this.getColumnValidateRules(row, col)
      const validator = new Schema(descriptor)
      validator.validate(row, { firstFields: true }, (errors, fields) => {
        let passed = true
        if (errors) {
          errors.forEach(error => {
            this.$message({ message: error.message, type: 'warning' })
          })
          passed = false
        }
        this.$set(this.validateStatus, col.prop, passed)
      })
    },
    getColumnValidateRules(row, column) {
      const rules = []
      function isNeedValidateType(type) {
        return type === 'number' || type === 'integer' || type === 'string'
      }
      if (isNeedValidateType(column.type)) {
        rules.push({ type: column.type, message: `${column.label}类型错误` })
      }
      if (column.required) {
        rules.push({ required: true, message: `${column.label}必填` })
      }
      if (column.pattern) {
        rules.push({ pattern: column.pattern, message: `${column.label}格式错误` })
      }
      const isNumberType = function(type) {
        return type === 'number' || type === 'integer' || type === 'float'
      }
      if (column.hasOwnProperty('min') && column.hasOwnProperty('max')) {
        if (isNumberType(column.type)) {
          rules.push({ type: column.type, min: column.min, max: column.max, message: `${column.label}必须在${column.min}~${column.max}范围内` })
        } else {
          rules.push({ type: column.type, min: column.min, max: column.max, message: `${column.label}长度必须在${column.min}~${column.max}范围内` })
        }
      } else {
        if (column.hasOwnProperty('min')) {
          if (isNumberType(column.type)) {
            rules.push({ type: column.type, min: column.min, message: `${column.label}不能小于${column.min}` })
          } else {
            rules.push({ type: column.type, min: column.min, message: `${column.label}长度不能小于${column.min}` })
          }
        }
        if (column.hasOwnProperty('max')) {
          if (isNumberType(column.type)) {
            rules.push({ type: column.type, max: column.max, message: `${column.label}不能大于${column.max}` })
          } else {
            rules.push({ type: column.type, max: column.max, message: `${column.label}长度不能大于${column.max}` })
          }
        }
      }
      if (column.hasOwnProperty('len')) {
        rules.push({ type: column.type, len: column.len, message: `${column.label}长度必须为${column.max}` })
      }
      if (column.type === 'enum') {
        const labels = column.options.map(option => option.label).join('、')
        const message = `${column.label}必须选择${labels}中的一个`
        rules.push({ type: 'enum', enum: column.options.map(option => option.value), message: message })
      }
      if (column.hasOwnProperty('validator')) {
        const validatorRule = function(rule, value) {
          return column.validator(value, row)
        }
        rules.push({ validator: validatorRule })
      }
      if (column.hasOwnProperty('asyncValidator')) {
        const asyncValidatorRule = function(rule, value, callback) {
          column.asyncValidator(value, row, callback)
        }
        rules.push({ asyncValidator: asyncValidatorRule })
      }
      return rules
    },
    getRowValidateDescriptor(row) {
      const descriptor = { }
      this.columns.forEach(column => {
        if (!column.editable) return
        const rules = this.getColumnValidateRules(row, column)
        if (rules.length) {
          descriptor[column.prop] = rules
        }
      })
      return descriptor
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
    },
    editRowIndex(value) {
      this.validateStatus = {}
    }
  }
}
</script>
