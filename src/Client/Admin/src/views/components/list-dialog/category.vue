<template>
  <div>
    <list-dialog
      ref="list"
      :uri="uri"
      :columns="columns"
      :query-params="innerQueryParams"
      dialog-title="选择商品类别"
    >
      <template slot="queryForm">
        <el-form-item>
          <el-input v-model="innerQueryParams.keyword" placeholder="类别编码、名称"></el-input>
        </el-form-item>
      </template>
    </list-dialog>
  </div>
</template>

<script>
import mixin from './mixin'
export default {
  name: 'CategoryListDialog',
  data() {
    return {
      uri: '/api/a/category',
      columns: [],
      innerQueryParams: {}
    }
  },
  mixins: [mixin],
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

