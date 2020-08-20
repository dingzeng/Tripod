<template>
  <div>

  </div>
</template>

<script>
export default {
  name: 'EditTableColumn',
  data() {
    return {

    }
  },
  props: {
    label: {
      type: String,
      required: true
    },
    prop: {
      type: String,
      required: true
    },
    type: {
      type: String,
      default: 'text'
    },
    width: {
      type: Number
    },
    editable: {
      type: Boolean,
      default: false
    },
    fixed: {
      type: String,
      validator: function(value) {
        return ['left', 'right'].indexOf(value) !== -1
      }
    },
    sortable: {
      type: Boolean,
      default: false
    },
    align: {
      type: String,
      default: 'left',
      validator: function(value) {
        return ['left', 'center', 'right'].indexOf(value) !== -1
      }
    },
    format: {
      type: Function,
      default: () => ''
    },
    total: {
      type: Boolean,
      default: false
    }
  }
}
</script>
