<template>
  <div>
    <list-dialog
      ref="list"
      :uri="uri"
      :columns="columns"
      :query-params="innerQueryParams"
      :left-span="6"
      dialog-title="选择供应商"
    >
      <template slot="queryForm">
        <el-form-item>
          <el-input v-model="innerQueryParams.keyword" placeholder="供应商编码、名称"></el-input>
        </el-form-item>
      </template>
      <template slot="mainLeft">
        <el-tree
          ref="tree"
          class="filter-tree"
          default-expand-all
          :expand-on-click-node="false"
          :data="treeData"
          @node-click="handleNodeClick"
        />
      </template>
    </list-dialog>
  </div>
</template>

<script>
import request from '@/utils/request'
import mixin from './mixin'
import { supplierType, settlementMode } from '@/utils/enum'
export default {
  name: 'SupplierListDialog',
  data() {
    return {
      uri: '/api/p/supplier',
      columns: [],
      innerQueryParams: {
        keyword: '',
        regionId: ''
      },
      treeData: [],
      supplierType: supplierType,
      settlementMode: settlementMode
    }
  },
  mixins: [mixin],
  methods: {
    handleNodeClick(data) {
      this.innerQueryParams.regionId = data.id
      this.$refs.list.query()
    }
  },
  mounted() {
    request({
      url: '/api/p/supplier-region',
      method: 'get'
    }).then(response => {
      this.treeData = response.map(i => {
        return {
          id: i.id,
          label: i.name,
          children: [],
          level: 1
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
        label: '名称'
      },
      {
        prop: 'regionName',
        label: '所属区域',
        width: 100
      },
      {
        prop: 'type',
        type: 'enum',
        label: '经营方式',
        width: 100,
        enums: supplierType
      },
      {
        prop: 'settlementMode',
        type: 'enum',
        label: '结算方式',
        width: 100,
        enums: settlementMode
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

