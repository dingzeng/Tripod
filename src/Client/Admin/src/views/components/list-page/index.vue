<template>
  <div>
    <!-- list -->
    <list-layout>
      <template slot="topLeft">
        <el-form :inline="true" :model="queryParams" class="query-form-inline" size="small">
          <slot name="queryForm" />
          <el-form-item v-if="$slots.queryForm">
            <el-button type="primary" icon="el-icon-search" @click="query">查询</el-button>
          </el-form-item>
        </el-form>
      </template>
      <template slot="topRight">
        <el-button type="primary" icon="el-icon-plus" size="small" plain @click="handleAdd">新增</el-button>
      </template>
      <template>
        <el-row>
          <el-col :span="leftSpan">
            <el-card shadow="never" style="margin-right: 10px;">
              <slot name="mainLeft"></slot>
            </el-card>
          </el-col>
          <el-col :span="24- leftSpan">
            <data-table
              :data="data"
              :columns="listPageColumns"
              @row-dblclick="handleEdit"
            />
          </el-col>
        </el-row>
      </template>
      <template slot="footer">
        <Pagination v-if="isPaging" :total="totalCount" :page.sync="pageIndex" :limit.sync="pageSize" @pagination="handlePaging" />
      </template>
    </list-layout>
    <!-- info -->
    <el-dialog
      :title="title"
      :visible.sync="dialogVisible"
      :width="dialogWidth"
      :fullscreen="dialogFullscreen"
      :modal-append-to-body="false"
      :close-on-click-modal="false"
      :before-close="closeDialog"
      @closed="dialogClosed"
    >
      <el-form
        ref="modelForm"
        :model="innerModel"
        :rules="modelRules"
        :validate-on-rule-change="false"
        label-width="110px"
        size="small"
      >
        <slot />
        <data-maintain v-if="showDataMaintain && innerAction != 'add'" :value="innerModel"></data-maintain>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button size="small" @click="closeDialog">取 消</el-button>
        <el-button type="primary" size="small" @click="doSave">确 定</el-button>
      </div>
    </el-dialog>
    <!-- save confirm -->
    <el-dialog
      title="提示"
      width="300px"
      :show-close="false"
      :visible.sync="confirmDialogVisible"
      :close-on-click-modal="false"
    >
      <p>你想要保存更改吗？</p>
      <div slot="footer" class="dialog-footer">
        <el-button size="small" @click="confirmDialogVisible = false">取 消</el-button>
        <el-button size="small" @click="confirmDialogVisible = false;dialogVisible = false">不保存</el-button>
        <el-button type="primary" size="small" @click="confirmDialogVisible = false;doSave()">保 存</el-button>
      </div>
    </el-dialog>
  </div>
</template>

<script>
import request from '@/utils/request'
import DataMaintain from '@/views/components/list-page/data-maintain'
import ListLayout from '@/views/components/list-layout/index'
import Pagination from '@/components/Pagination/index'
import DataTable from '@/views/components/data-table/index'
import api from '@/api/common.js'
export default {
  name: 'ListPage',
  components: { DataMaintain, ListLayout, Pagination, DataTable },
  props: {
    uri: {
      type: String,
      required: true
    },
    pk: {
      type: String,
      default: 'id'
    },
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
    model: {
      type: Object,
      default: () => {}
    },
    modelRules: {
      type: Object,
      default: () => {}
    },
    dialogTitle: {
      type: String,
      default: ''
    },
    dialogWidth: {
      type: String,
      default: '50%'
    },
    dialogFullscreen: {
      type: Boolean,
      default: false
    },
    isLoadPage: {
      type: Boolean,
      default: false
    },
    operations: {
      type: Array,
      default: () => []
    },
    page: {
      type: Object,
      default: () => {}
    },
    showDataMaintain: {
      type: Boolean,
      default: false
    },
    action: {
      type: String
    },
    leftSpan: {
      type: Number,
      default: 0
    }
  },
  data() {
    return {
      data: [],
      pageIndex: 1,
      pageSize: 20,
      totalCount: 0,
      dialogVisible: false,
      confirmDialogVisible: false,
      innerModel: this.model,
      initialModel: this.model,
      innerAction: this.action, // add | edit
      modelChanged: false,
      innerPage: {}
    }
  },
  computed: {
    title() {
      let actionText = ''
      switch (this.innerAction) {
        case 'add':
          actionText = '新增'
          break
        case 'edit':
          actionText = '修改'
          break
        default:
          break
      }
      const star = this.modelChanged ? '*' : ''
      return `${actionText}${this.dialogTitle} ${star}`
    },
    listPageColumns() {
      const buttons = [
        {
          icon: 'el-icon-delete',
          onclick: (index, row) => {
            this.handleDelete(index, row)
          }
        }
      ]
      buttons.push(...this.operations)
      const cols = this.columns
      cols.push({
        type: 'opt',
        label: '操作',
        width: 150,
        buttons: buttons
      })
      return cols
    }
  },
  watch: {
    innerModel: {
      handler: function(newValue) {
        this.$emit('update:model', newValue)
        this.modelChanged = true
      },
      deep: true
    },
    model(newValue) {
      this.innerModel = newValue
    },
    innerPage: {
      handler: function(newValue) {
        this.$emit('update:page', newValue)
      },
      deep: true
    },
    page: {
      handler: function(newValue) {
        this.innerPage = newValue
      },
      deep: true
    },
    innerAction(value) {
      this.$emit('update:action', value)
    },
    action(value) {
      this.innerAction = value
    }
  },
  mounted() {
    if (this.isLoadPage) {
      request({
        url: this.uri + '/_page',
        method: 'get'
      }).then(response => {
        this.innerPage = response.data
      })
    }
    this.query()
  },
  methods: {
    query() {
      const request = Object.assign({}, this.queryParams)
      if (this.isPaging) {
        request.pageIndex = this.pageIndex
        request.pageSize = this.pageSize
      }
      api.queryApi(this.uri, request).then(response => {
        if (this.isPaging) {
          this.data = response.data
          this.totalCount = response.count
        } else {
          this.data = response
        }
      })
    },
    handleAdd() {
      this.innerAction = 'add'
      this.dialogVisible = true
      this.innerModel = Object.assign({}, this.initialModel)
      this.modelChanged = false
    },
    handleEdit(row, column, event) {
      this.innerAction = 'edit'
      this.dialogVisible = true
      api.getApi(this.uri, row[this.pk]).then(response => {
        this.innerModel = response
        this.$nextTick(() => {
          this.modelChanged = false
        })
        this.$emit('model-load', response)
      })
    },
    handleDelete(index, row) {
      this.$confirm('确定要删除吗？', '提示').then(() => {
        api.deleteApi(this.uri, row[this.pk]).then(response => {
          this.$message.success('删除成功')
          this.$emit('on-delete')
          this.query()
        })
      })
    },
    handlePaging() {
      this.query()
    },
    closeDialog() {
      // control dialog visible
      if (this.modelChanged) {
        this.confirmDialogVisible = true
        return
      }
      this.dialogVisible = false
    },
    doSave() {
      this.$refs.modelForm.validate(valid => {
        if (valid) {
          if (!this.modelChanged) {
            this.dialogVisible = false
            return
          }
          if (this.innerAction === 'view') {
            this.dialogVisible = false
            return
          }
          const promise =
            this.innerAction === 'add'
              ? api.postApi(this.uri, this.innerModel)
              : api.putApi(this.uri, this.innerModel)

          promise.then(response => {
            this.$message.success('保存成功')
            this.$emit('on-save')
            this.query()
            this.dialogVisible = false
          })
        }
      })
    },
    dialogClosed() {
      this.$refs.modelForm.resetFields()
    }
  }
}
</script>
<style lang="scss" scoped>
  .el-dialog__body {
    padding-top: 0px;
    padding-bottom: 0px;
  }
  .query-form-inline {
    // 抵消form-item默认的外边距
    margin-bottom: -18px;
  }
</style>
