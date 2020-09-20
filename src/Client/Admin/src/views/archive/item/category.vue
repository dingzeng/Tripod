<template>
  <div>
    <list-page
      ref="listpage"
      uri="/api/a/category"
      dialog-title="商品类别"
      :action.sync="action"
      :query-params="queryParams"
      :left-span="4"
      :columns="columns"
      :model.sync="model"
      @on-save="refreshTree"
      @on-delete="refreshTree"
    >
      <template slot="queryForm">
        <el-form-item prop="keyword">
          <el-input v-model="queryParams.keyword" placeholder="编码/名称" />
        </el-form-item>
      </template>

      <template slot="mainLeft">
        <el-tree
          default-expand-all
          :expand-on-click-node="false"
          :data="treeData"
          @node-click="handleNodeClick"
        />
      </template>

      <template>
        <el-row>
          <el-col>
            <el-form-item prop="parent" label="上级类别">
              <picker
                v-model="model.parentId"
                :label.sync="model.parentName"
                type="category"
                :disabled="action != 'add'"
                :queryParams="{level: 2}"
              >
              </picker>
            </el-form-item>
          </el-col>
          <el-col>
            <el-form-item prop="id" label="编码" required>
              <el-input v-model="model.id" :disabled="action != 'add'"></el-input>
            </el-form-item>
          </el-col>
          <el-col>
            <el-form-item prop="name" label="名称" required>
              <el-input v-model="model.name"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
      </template>
    </list-page>
  </div>
</template>

<script>
import request from '@/utils/request'
export default {
  name: 'Category',
  data() {
    return {
      action: '',
      queryParams: {},
      columns: [],
      model: { },
      treeData: []
    }
  },
  methods: {
    handleNodeClick(data) {
      this.queryParams.ancestorId = data.id
      this.$refs.listpage.query()
    },
    refreshTree() {
      request({
        url: '/api/a/category/tree',
        method: 'get'
      }).then(response => {
        this.treeData = response
      })
    }
  },
  mounted() {
    this.refreshTree()
  },
  created() {
    this.columns = [
      {
        prop: 'id',
        label: '编码',
        width: 100
      },
      {
        prop: 'name',
        label: '名称'
      }
    ]
  }
}
</script>
