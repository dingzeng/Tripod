<template>
  <div>
    <list-page
      uri="/archive/itemUnit"
      dialog-title="商品单位"
      :columns="columns"
      :model.sync="model"
      :model-rules="modelRules"
      :query-params.sync="queryParams"
    >
      <template slot="queryForm">
        <el-form-item prop="keyword">
          <el-input v-model="queryParams.keyword" placeholder="编码/名称" />
        </el-form-item>
      </template>
      <template>
        <el-row>
          <el-col>
            <el-form-item label="名称" required>
              <el-input v-model="model.name"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
      </template>
    </list-page>
  </div>
</template>

<script>
import ListPage from '@/views/components/list-page/index'
export default {
  name: 'ItemUnit',
  components: { ListPage },
  data() {
    return {
      queryParams: {},
      columns: [],
      model: {},
      modelRules: {
        name: [
          { required: true, message: '必填', trigger: 'blur' }
        ]
      }
    }
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
