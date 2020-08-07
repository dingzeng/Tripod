import ListDialog from './base'
export default {
  components: { ListDialog },
  data() {
    return {
      innerQueryParams: this.queryParams
    }
  },
  props: {
    queryParams: {
      type: Object,
      default: () => {}
    }
  },
  methods: {

  },
  watch: {
    queryParams: {
      handler: function(newValue) {
        this.innerQueryParams = newValue
      },
      deep: true
    },
    innerQueryParams: {
      handler: function(newValue) {
        this.$emit('update:queryParams', newValue)
      },
      deep: true
    }
  }
}
