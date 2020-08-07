<template>
  <div>
    <list-page
      uri="/archive/itemBrand"
      dialog-title="商品品牌"
      :columns="columns"
      :query-params.sync="queryParams"
      :model.sync="model"
      :model-rules="modelRules"
      :action.sync="action"
      @model-load="modelLoad"
    >
      <template slot="queryForm">
        <el-form-item prop="keyword">
          <el-input v-model="queryParams.keyword" placeholder="编码/名称" />
        </el-form-item>
      </template>
      <template>
        <el-row>
          <el-col>
            <el-form-item prop="id" label="编码">
              <el-input v-model="model.id" :disabled="action != 'add'"></el-input>
            </el-form-item>
          </el-col>
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
import request from '@/utils/request'
import ListPage from '@/views/components/list-page/index'
export default {
  name: 'ItemBrand',
  components: { ListPage },
  data() {
    return {
      queryParams: {},
      columns: [],
      model: {},
      originalId: '',
      action: ''
    }
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
  },
  methods: {
    modelLoad(model) {
      this.originalId = model.id
    }
  },
  computed: {
    modelRules() {
      const vm = this
      return {
        id: [
          { required: true, message: '必填', trigger: 'blur' },
          { type: 'string', pattern: /^[0-9]{2}$/, message: '编码只能输入两位数字字符', trigger: 'blur' },
          {
            validator(rule, value, callback) {
              request({
                url: '/archive/itemBrand/exists/?id=' + value,
                method: 'get'
              }).then(response => {
                if (response.data && vm.originalId !== value) {
                  callback(new Error('编码已存在'))
                } else {
                  callback()
                }
              })
            }
          }
        ],
        name: [
          { required: true, message: '必填', trigger: 'blur' },
          { type: 'string', max: 10, trigger: 'blur' }
        ]
      }
    }
  }
}
</script>
