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
            <el-form-item prop="parentId" label="上级类别">
              <ref-input
                v-model="model.parentId"
                type="category"
                :label.sync="model.parentName"
                :disabled="action != 'add'"
                :queryParams="{level: 2}"
              >
              </ref-input>
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
import ListPage from '@/views/components/list-page/index'

export default {
  name: 'Category',
  components: { ListPage },
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
