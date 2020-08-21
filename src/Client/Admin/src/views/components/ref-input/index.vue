<template>
  <div>
    <el-input
      clearable
      :value="text"
      :placeholder="placeholder"
      :disabled="disabled"
      @blur="inputBlur"
      @clear="inputClear"
    >
      <el-button slot="append" icon="el-icon-menu" @click="showDialog"></el-button>
    </el-input>
    <component
      :is="type"
      ref="dialog"
      :query-params.sync="innerQueryParams"
      @on-ok="setCurrentData"
    >
    </component>
  </div>
</template>

<script>
import ListDialogs from '@/views/components/list-dialog'
import emitter from 'element-ui/src/mixins/emitter'
export default {
  name: 'RefInput',
  mixins: [emitter],
  components: {
    ...ListDialogs
  },
  data() {
    return {
      innerValue: this.value,
      innerQueryParams: this.queryParams
    }
  },
  props: {
    value: {
      type: [Object, Array]
    },
    type: {
      type: String,
      required: true
    },
    placeholder: {
      type: String,
      default: () => '请选择'
    },
    disabled: {
      type: Boolean,
      default: () => false
    },
    queryParams: {
      type: Object,
      default: () => {}
    },
    format: {
      type: String,
      default: '{name}'
    }
  },
  methods: {
    inputBlur() {
      // TODO auto search ,if not exist only one then show the list dialog.
    },
    inputClear() {
      this.innerValue = null
    },
    setCurrentData(data) {
      this.$emit('selected', data)
      this.innerValue = data
      // this.$nextTick(() => {
      //   this.dispatch('ElFormItem', 'el.form.blur', [data])
      // })
    },
    showDialog() {
      this.$refs.dialog.$refs.list.show()
    }
  },
  computed: {
    text() {
      // TODO from format
      const formatText = (format, obj) => {
        var reg = /\{[a-zA-Z0-9_]*\}/g
        var arr = [...(format.matchAll(reg))]
        arr.forEach(item => {
          const key = item[0].substring(1, item[0].length - 1)
          format = format.replace(item[0], obj[key])
        })
        return format
      }
      if (!this.innerValue || this.innerValue.length === 0) return ''
      if (Array.isArray(this.innerValue)) {
        return this.innerValue.map(obj => formatText(this.format, obj)).join(';')
      } else {
        return formatText(this.format, this.innerValue)
      }
    }
  },
  watch: {
    innerValue(newValue) {
      this.$emit('input', newValue)
    },
    value(newValue) {
      this.innerValue = newValue

      // HACK fixbug:form组件的 resetFields方法对ref-input组件绑定的label属性不会重置
      // （只重置在form-item上写了prop的数据）
      // if (!newValue) {
      //   this.innerLabel = ''
      // }
    },
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
</script>
