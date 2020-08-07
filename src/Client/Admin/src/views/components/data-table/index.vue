<template>
  <div>
    <el-table
      :data="data"
      :height="height"
      style="width: 100%"
      size="small"
      stripe
      border
      highlight-current-row
      @selection-change="handleSelectionChange"
      @row-dblclick="handleRowDbClick"
    >
      <el-table-column v-if="selection" type="selection" width="39"></el-table-column>
      <template v-for="col in columns">
        <el-table-column v-if="col.type=='opt'" :key="col.prop" label="操作" width="150" align="center">
          <template slot-scope="scope">
            <el-button
              v-for="(btn, index) in col.buttons"
              :key="index"
              size="mini"
              type="text"
              :icon="btn.icon"
              @click="btn.onclick(scope.$index, scope.row)"
            >
              {{ btn.text }}
            </el-button>
          </template>
        </el-table-column>
        <el-table-column v-else-if="col.type=='tag'" :key="col.prop" :label="col.label" :width="col.width">
          <template slot-scope="scope">
            <el-tag :type="col.tagTypes[scope.row[col.prop]]">{{ col.tagLabels[scope.row[col.prop]] }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column v-else-if="col.type=='enum'" :key="col.prop" :label="col.label" :width="col.width">
          <template slot-scope="scope">
            {{ col.enums[scope.row[col.prop]] }}
          </template>
        </el-table-column>
        <el-table-column
          v-else
          :key="col.prop"
          :type="col.type"
          :prop="col.prop"
          :label="col.label"
          :width="col.width"
        />
      </template>
    </el-table>
  </div>
</template>

<script>
export default {
  name: 'DataTable',
  props: {
    data: {
      type: Array,
      default: () => []
    },
    columns: {
      type: Array,
      default: () => []
    },
    height: {
      type: [String, Number]
    },
    selection: {
      type: Boolean,
      default: true
    }
  },
  data() {
    return {

    }
  },
  methods: {
    handleSelectionChange(selection) {
      this.$emit('selection-change', selection)
    },
    handleRowDbClick(row, column, event) {
      this.$emit('row-dblclick', row, column, event)
    }
  }
}
</script>
