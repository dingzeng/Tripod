<template>
  <div>
    <table-header></table-header>
    <table-body></table-body>
    <table-footer></table-footer>
  </div>
</template>

<script>
import TableHeader from './table-header'
import TableBody from './table-body'
import TableFooter from './table-footer'
export default {
  name: 'EditTable',
  components: {
    TableHeader,
    TableBody,
    TableFooter
  },
  data() {
    return {
      data: this.value
    }
  },
  props: {
    value: {
      type: Array,
      default: () => []
    },
    columns: {
      type: Array,
      default: () => []
    }
  }
}
</script>
