<template>
  <div>
    <el-input
      v-model="innerLabel"
      clearable
      :placeholder="placeholder"
      :disabled="disabled"
      @blur="inputBlur"
      @clear="inputClear"
    >
      <el-button slot="append" icon="el-icon-menu" @click="clickMore"></el-button>
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
      innerLabel: this.label,
      innerQueryParams: this.queryParams
    }
  },
  props: {
    value: {
      type: [String, Number],
      default: () => ''
    },
    label: String,
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
    valueKey: {
      type: String,
      default: 'id'
    },
    labelKey: {
      type: String,
      default: 'name'
    }
  },
  methods: {
    inputBlur() {
      // TODO auto search ,if not exist only one then show the list dialog.
    },
    inputClear() {
      this.innerValue = ''
      this.innerLabel = ''
    },
    setCurrentData(data) {
      // NOTE 使用ListDialog的ref-input只支持单选
      if (Array.isArray(data)) {
        data = data[0]
      }
      this.innerValue = data[this.valueKey]
      this.innerLabel = data[this.labelKey]
      this.$nextTick(() => {
        this.dispatch('ElFormItem', 'el.form.blur', [data[this.valueKey]])
      })
    },
    clickMore() {
      this.$refs.dialog.$refs.list.show()
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
      if (!newValue) {
        this.innerLabel = ''
      }
    },
    innerLabel(newValue) {
      this.$emit('update:label', newValue)
    },
    label(newValue) {
      this.innerLabel = newValue
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
