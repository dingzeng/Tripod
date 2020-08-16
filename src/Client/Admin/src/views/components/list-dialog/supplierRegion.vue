<template>
  <div>
    <list-dialog
      ref="list"
      :uri="uri"
      :columns="columns"
      :query-params="innerQueryParams"
      :is-paging="false"
      dialog-title="选择供应商区域"
    >
    </list-dialog>
  </div>
</template>

<script>
import mixin from './mixin'
export default {
  name: 'SupplierRegionListDialog',
  data() {
    return {
      uri: '/api/p/supplier-region',
      columns: [],
      innerQueryParams: {
        keyword: ''
      }
    }
  },
  mixins: [mixin],
  created() {
    this.columns = [
      {
        prop: 'name',
        label: '名称'
      }
    ]
  }
}
</script>

