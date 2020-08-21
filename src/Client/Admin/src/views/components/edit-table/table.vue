<template>
  <div>
    <div class="edit-table-toolbar">
      <button @click="addNewRow">新增行</button>
      <button @click="deleteAll">清空</button>
      <slot name="toolbar"></slot>
    </div>
    <table :border="border" :width="width" class="edit-table">
      <table-header
        :columns="columns"
      >
      </table-header>
      <table-body
        :columns="columns"
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
      data: this.value
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
    }
  },
  methods: {
    addNewRow() {
      this.data.push({})
    },
    deleteAll() {
      this.data = []
    }
  },
  computed: {
    showTotal() {
      return this.columns.some(c => c.total)
    },
    totalData() {
      // TODO
      return {}
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
