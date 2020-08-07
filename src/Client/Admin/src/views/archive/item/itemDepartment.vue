<template>
  <div>
    <list-page
      uri="/archive/itemDepartment"
      dialog-title="商品部门"
      :columns="columns"
      :model.sync="model"
      :model-rules="modelRules"
    >
      <template>
        <el-row>
          <el-col>
            <el-form-item prop="name" label="名称">
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
  name: 'ItemDepartment',
  components: { ListPage },
  data() {
    return {
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
