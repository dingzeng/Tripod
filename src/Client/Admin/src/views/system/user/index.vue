<template>
  <div>
    <list-page
      load-page
      uri="/api/s/user"
      dialog-title="用户"
      dialog-width="500px"
      :columns="columns"
      :model-rules="modelRules"
      :model.sync="model"
      :operations="operations"
    >
      <template slot="queryForm">
        <el-form-item prop="keyword">
          <el-input v-model="queryParams.keyword" placeholder="用户名、手机号、姓名" />
        </el-form-item>
      </template>
      <template>
        <el-form-item prop="branchId" label="所属机构">
          <ref-input v-model="model.branchId" type="branch" :label.sync="model.branchName" />
        </el-form-item>
        <el-form-item prop="username" label="用户名">
          <el-input v-model="model.username" />
        </el-form-item>
        <el-form-item prop="password" label="密码">
          <el-input v-model="model.password" type="password" show-password />
        </el-form-item>
        <el-form-item prop="name" label="姓名">
          <el-input v-model="model.name" />
        </el-form-item>
        <el-form-item prop="mobile" label="手机号">
          <el-input v-model="model.mobile" />
        </el-form-item>
        <el-form-item prop="status" label="状态">
          <el-switch v-model="model.status" :active-value="true" :inactive-value="false" />
        </el-form-item>
      </template>
    </list-page>
    <el-dialog title="关联角色" :visible.sync="relateRoleDialogVisible" width="650px" :close-on-click-modal="false">
      <el-transfer v-model="relateModel.roleIdList" :data="allRoles" :titles="['未关联角色','关联角色']" />
      <template slot="footer">
        <el-button size="small" @click="relateRoleDialogVisible = false">取 消</el-button>
        <el-button type="primary" size="small" @click="confirmRelation">确 定</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script>
import RefInput from '@/views/components/ref-input/index'
import ListPage from '@/views/components/list-page/index'
import { getRoles } from '@/api/role'
import { getUserRoles, updateUserRoles } from '@/api/user'
export default {
  name: 'SystemUser',
  components: { ListPage, RefInput },
  data() {
    return {
      queryParams: {},
      columns: [],
      modelRules: {
        branchId: [
          { required: true, message: '请选择用户所属机构', trigger: 'blur' }
        ],
        username: [
          { required: true, message: '请输入用户名', trigger: 'blur' }
        ],
        password: [{ required: true, message: '请输入密码', trigger: 'blur' }],
        name: [{ required: true, message: '请输入姓名', trigger: 'blur' }]
      },
      model: {},
      operations: [
        {
          icon: 'el-icon-link',
          onclick: (index, row) => {
            this.relateRoleDialogVisible = true
            getUserRoles(row.id).then(response => {
              this.relateModel.userId = row.id
              this.relateModel.roleIdList = response.map(b => b.id)
            })
          }
        }
      ],
      relateRoleDialogVisible: false,
      relateModel: {
        userId: '',
        roleIdList: []
      },
      allRoles: []
    }
  },
  mounted() {
    getRoles().then(response => {
      this.allRoles = response.map(b => {
        return {
          key: b.id,
          label: b.name
        }
      })
    })
  },
  created() {
    this.columns = [
      {
        prop: 'id',
        label: '编码',
        width: 100
      },
      {
        prop: 'username',
        label: '用户名',
        width: 150
      },
      {
        prop: 'name',
        label: '姓名',
        width: 150
      },
      {
        prop: 'mobile',
        label: '手机号',
        width: 200
      },
      {
        prop: 'status',
        type: 'tag',
        label: '状态',
        tagTypes: {
          false: 'info',
          true: 'success'
        },
        tagLabels: {
          false: '禁用',
          true: '启用'
        }
      }
    ]
  },
  methods: {
    confirmRelation() {
      updateUserRoles(this.relateModel.userId, this.relateModel.roleIdList).then(response => {
        this.$message.success('修改成功')
        this.relateRoleDialogVisible = false
      })
    }
  }
}
</script>>
