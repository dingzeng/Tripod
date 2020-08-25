<template>
  <div>
    <div class="edit-table-toolbar">
      <button @click.stop.prevent="addNewRow">新增行</button>
      <button @click.stop.prevent="deleteAll">清空</button>
      <slot name="toolbar"></slot>
    </div>
    <div class="edit-table-wrapper">
      <table :border="border" class="edit-table" :style="tableStyles">
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
