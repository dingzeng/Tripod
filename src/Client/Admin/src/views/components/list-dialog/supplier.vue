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
import { sellWay, settleWay } from '@/utils/enum'
export default {
  name: 'SupplierListDialog',
  data() {
    return {
      uri: '/archive/supplier',
      columns: [],
      innerQueryParams: {
        keyword: '',
        regionId: ''
      },
      treeData: [],
      sellWay: sellWay,
      settleWay: settleWay
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
      url: '/archive/supplierRegion/tree',
      method: 'get'
    }).then(response => {
      this.treeData = response.data
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
        label: '名称',
        width: 200
      },
      {
        prop: 'regionId',
        label: '所属区域',
        width: 200
      },
      {
        prop: 'sellWay',
        type: 'enum',
        label: '经营方式',
        width: 100,
        enums: sellWay
      },
      {
        prop: 'settleWay',
        type: 'enum',
        label: '结算方式',
        width: 100,
        enums: settleWay
      },
      {
        prop: 'contactsName',
        label: '联系人'
      }
    ]
  }
}
</script>

