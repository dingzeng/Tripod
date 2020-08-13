<template>
  <div>
    <list-page
      uri="/api/a/branch-group"
      dialog-title="店组管理"
      :query-params="queryParams"
      :columns="columns"
      :model-rules="modelRules"
      :model.sync="model"
      :operations="operations"
    >
      <template slot="queryForm">
        <el-form-item prop="keyword">
          <el-input v-model="queryParams.keyword" placeholder="编码/名称" />
        </el-form-item>
      </template>
      <template>
        <el-form-item prop="name" label="店组名称">
          <el-input v-model="model.name" />
        </el-form-item>
      </template>
    </list-page>
    <el-dialog title="关联机构" :visible.sync="relateBranchDialogVisible" width="650px" :close-on-click-modal="false">
      <el-transfer v-model="relateModel.branchIdList" :data="allBranchs" :titles="['未关联机构','关联机构']" />
      <template slot="footer">
        <el-button size="small" @click="relateBranchDialogVisible = false">取 消</el-button>
        <el-button type="primary" size="small" @click="confirmRelation">确 定</el-button>
      </template>
    </el-dialog>
  </div>
</template>

<script>
import ListPage from '@/views/components/list-page/index'
import { query, getBranchGroupBranchs, updateBranchGroupBranchs } from '@/api/branch'
export default {
  name: 'ArchiveBranchGroup',
  components: { ListPage },
  data() {
    return {
      queryParams: { },
      columns: [],
      model: {},
      modelRules: {
        name: [
          { required: true, message: '请输入店组名称', trigger: 'blur' }
        ]
      },
      operations: [
        {
          icon: 'el-icon-link',
          onclick: (index, row) => {
            this.relateBranchDialogVisible = true
            getBranchGroupBranchs(row.id).then(response => {
              this.relateModel.branchGroupId = row.id
              this.relateModel.branchIdList = response.data.map(b => b.id)
            })
          }
        }
      ],
      relateBranchDialogVisible: false,
      relateModel: {
        branchGroupId: '',
        branchIdList: []
      },
      allBranchs: []
    }
  },
  mounted() {
    query({ pageSize: 10000 }).then(response => {
      this.allBranchs = response.data.list.map(b => {
        return {
          key: b.id,
          label: `[${b.id}]${b.name}`
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
        prop: 'name',
        label: '店组名称'
      }
    ]
  },
  methods: {
    confirmRelation() {
      updateBranchGroupBranchs(this.relateModel.branchGroupId, this.relateModel.branchIdList).then(response => {
        if (!response.data) {
          this.$message.error('修改失败')
        } else {
          this.$message.success('修改成功')
          this.relateBranchDialogVisible = false
        }
      })
    }
  }
}
</script>
