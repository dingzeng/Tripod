<template>
  <div>
    <div class="edit-table-toolbar">
      <div style="float: left;">
        <el-button @click="addNewRow" size="mini" icon="el-icon-plus" plain>新增行</el-button>
        <el-button @click="deleteAll" size="mini" icon="el-icon-delete" plain>清 空</el-button>
        <slot name="toolbar"></slot>
      </div>
      <div style="float: right;">
        <el-input v-model="keyword" placeholder="请输入，按回车添加到表格" size="mini" style="width: 300px;"></el-input>
        <el-button @click="searchAndAppend" type="primary" size="mini">确定</el-button>
      </div>
      <div style="clear: both;"></div>
    </div>
    <div class="edit-table-wrapper">
      <table :border="border" class="edit-table" :style="tableStyles">
        <table-header
          :columns="columns"
          :indexed="indexed"
        >
        </table-header>
        <table-body
          :columns="columns"
          :actions="actions"
          :indexed="indexed"
          v-model="data"
        >
        </table-body>
        <table-footer
          v-if="showTotal"
          :columns="columns"
          :totalData="totalData"
        >
        </table-footer>
      </table>
    </div>
  </div>
</template>

<script>
import TableHeader from './table-header'
import TableBody from './table-body'
import TableFooter from './table-footer'
export default {
  name: 'EditTable',
  components: {
    TableHeader,
    TableBody,
    TableFooter
  },
  data() {
    return {
      data: this.value,
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
    border: {
      type: Number,
      default: 1
    },
    width: {
      type: [Number, String],
      default: '100%'
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
    addNewRow() {
      this.data.push({})
    },
    deleteAll() {
      this.data = []
    },
    searchAndAppend() {

    }
  },
  computed: {
    showTotal() {
      return this.columns.some(c => c.total)
    },
    totalData() {
      // TODO
      return {}
    },
    tableStyles() {
      return {
        width: this.width
      }
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
