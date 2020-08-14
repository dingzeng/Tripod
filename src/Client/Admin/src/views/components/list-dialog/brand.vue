<template>
  <div>
    <list-dialog
      ref="list"
      :uri="uri"
      :columns="columns"
      :query-params="innerQueryParams"
      dialog-title="选择商品品牌"
    >
    </list-dialog>
  </div>
</template>

<script>
import mixin from './mixin'
export default {
  name: 'BrandListDialog',
  data() {
    return {
      uri: '/api/a/brand',
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

