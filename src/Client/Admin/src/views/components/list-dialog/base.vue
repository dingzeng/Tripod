<template>
  <div>
    <el-dialog :visible.sync="visible" :title="dialogTitle" :modal-append-to-body="false" :append-to-body="true">
      <list-layout>
        <template slot="topLeft">
          <el-form :inline="true" :model="queryParams" class="demo-form-inline" size="small">
            <slot name="queryForm"></slot>
            <el-form-item v-if="$slots.queryForm">
              <el-button type="primary" icon="el-icon-search" @click="query">查询</el-button>
            </el-form-item>
          </el-form>
        </template>
        <template>
          <el-row>
            <el-col :span="leftSpan">
              <el-card shadow="never" style="height: 400px;margin-right: 10px;overflow: auto;">
                <slot name="mainLeft"></slot>
              </el-card>
            </el-col>
            <el-col :span="24- leftSpan">
              <data-table
                :data="data"
                :columns="columns"
                :height="400"
                @selection-change="selectionChange"
                @row-dblclick="rowDblclick"
              >
              </data-table>
            </el-col>
          </el-row>
          <Pagination v-if="isPaging" :total="totalCount" :page="pageIndex" :limit="pageSize"></Pagination>
        </template>
      </list-layout>
      <template slot="footer">
        <el-button size="small" @click="visible = false">取 消</el-button>
        <el-button type="primary" size="small" @click="complete">确 定</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script>
import qs from 'qs'
import request from '@/utils/request'
import ListLayout from '@/views/components/list-layout/index'
import Pagination from '@/components/Pagination/index'
import DataTable from '@/views/components/data-table/index'
export default {
  name: 'ListDialog',
  components: { ListLayout, Pagination, DataTable },
  data() {
    return {
      data: [],
      pageIndex: 1,
      pageSize: 20,
      totalCount: 0,
      visible: false,
      selection: []
    }
  },
  props: {
    uri: {
      type: String,
      required: true
    },
    queryDelegate: Function,
    columns: {
      type: Array,
      required: true
    },
    queryParams: {
      type: Object,
      default: () => {}
    },
    paramsRules: {
      type: Object,
      default: () => {}
    },
    isPaging: {
      type: Boolean,
      default: true
    },
    dialogTitle: {
      type: String,
      default: ''
    },
    dialogWidth: {
      type: String,
      default: '50%'
    },
    leftSpan: {
      type: Number,
      default: 0
    }
  },
  methods: {
    query() {
      const request = {
        params: this.queryParams
      }
      if (this.isPaging) {
        request.pageIndex = this.pageIndex
        request.pageSize = this.pageSize
      }
      this.queryFn(request).then(response => {
        if (this.isPaging) {
          this.data = response.data
          this.totalCount = response.count
        } else {
          this.data = response
        }
      })
    },
    selectionChange(selection) {
      this.selection = selection
    },
    complete() {
      if (this.selection.length === 0) {
        this.$message.warning('未选中任何行')
        return
      }
      this.$parent.$emit('on-ok', this.selection)
      this.visible = false
    },
    rowDblclick(row, column, event) {
      this.$parent.$emit('on-ok', row)
      this.visible = false
    },
    show() {
      this.visible = true
    }
  },
  computed: {
    queryFn() {
      if (this.queryDelegate) return this.queryDelegate
      return function(query) {
        const obj = Object.assign({}, query.params, { pageIndex: query.pageIndex, pageSize: query.pageSize })
        const querystring = qs.stringify(obj)
        return request({
          url: this.uri + '?' + querystring,
          method: 'get'
        })
      }.bind(this)
    }
  },
  mounted() {
    this.query()
  }
}
</script>

<style lang="scss" scoped>
  /deep/ .el-dialog__body {
    padding-top: 0px;
    padding-bottom: 0px;
  }
</style>
