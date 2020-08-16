<template>
  <div>
    <list-dialog
      ref="list"
      :uri="uri"
      :columns="columns"
      :query-params="innerQueryParams"
      :left-span="6"
      dialog-title="选择机构"
    >
      <template slot="queryForm">
        <el-form-item>
          <el-input v-model="innerQueryParams.keyword" placeholder="机构编码、名称"></el-input>
        </el-form-item>
      </template>
      <template slot="mainLeft">
        <el-tree
          ref="branchTree"
          class="filter-tree"
          default-expand-all
          :expand-on-click-node="false"
          :data="branchTreeData"
          @node-click="handleNodeClick"
        />
      </template>
    </list-dialog>
  </div>
</template>

<script>
import mixin from './mixin'
import { loadBranchTreeData } from '@/api/branch'
import { branchType } from '@/utils/enum'
export default {
  name: 'BranchListDialog',
  data() {
    return {
      uri: '/api/a/branch',
      columns: [],
      innerQueryParams: {
        keyword: '',
        ancestorId: ''
      },
      branchTreeData: [],
      branchType
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
    loadBranchTreeData().then(response => {
      this.branchTreeData = response
    })
  },
  created() {
    this.columns = [
      {
        prop: 'id',
        label: '机构编码',
        width: 100
      },
      {
        prop: 'name',
        label: '机构名称'
      },
      {
        prop: 'type',
        type: 'enum',
        label: '机构类型',
        width: 100,
        enums: branchType
      },
      {
        prop: 'contactsName',
        label: '联系人',
        width: 100
      }
    ]
  }
}
</script>

