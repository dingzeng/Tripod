<template>
  <div>
    <el-divider content-position="left">维护信息</el-divider>
    <el-row>
      <el-col :span="8">
        <el-form-item label="创建人">
          {{ value.createOperName }}
        </el-form-item>
      </el-col>
      <el-col :span="8">
        <el-form-item label="创建时间">
          {{ value.createTime }}
        </el-form-item>
      </el-col>
      <el-col :span="8">
        <el-form-item label="最后修改人">
          {{ value.lastUpdateOperName }}
        </el-form-item>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="8">
        <el-form-item label="最后修改时间">
          {{ value.lastUpdateTime }}
        </el-form-item>
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  name: 'DataMaintain',
  data() {
    return {

    }
  },
  props: {
    value: {
      type: Object,
      default: () => {}
    }
  }
}
</script>
