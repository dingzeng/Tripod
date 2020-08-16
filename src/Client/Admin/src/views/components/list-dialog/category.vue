<template>
  <div>
    <list-dialog
      ref="list"
      :uri="uri"
      :columns="columns"
      :query-params="innerQueryParams"
      :left-span="6"
      dialog-title="选择商品类别"
    >
      <template slot="queryForm">
        <el-form-item>
          <el-input v-model="innerQueryParams.keyword" placeholder="类别编码、名称"></el-input>
        </el-form-item>
      </template>
      <template slot="mainLeft">
        <el-tree
          ref="categoryTree"
          class="filter-tree"
          default-expand-all
          :expand-on-click-node="false"
          :data="categoryTreeData"
          @node-click="handleNodeClick"
        />
      </template>
    </list-dialog>
  </div>
</template>

<script>
import request from '@/utils/request'
import mixin from './mixin'
export default {
  name: 'CategoryListDialog',
  data() {
    return {
      uri: '/api/a/category',
      columns: [],
      innerQueryParams: {},
      categoryTreeData: []
    }
  },
  mixins: [mixin],
  methods: {
    handleNodeClick(data) {
      this.innerQueryParams.ancestorId = data.id
      this.$refs.list.query()
    }
  },
  mounted() {
    request({
      url: '/api/a/category/tree',
      method: 'GET'
    }).then(response => {
      this.categoryTreeData = response
    })
  },
  created() {
    this.columns = [
      {
        prop: 'id',
        width: 100,
        label: '编码'
      },
      {
        prop: 'name',
        label: '名称'
      }
    ]
  }
}
</script>

