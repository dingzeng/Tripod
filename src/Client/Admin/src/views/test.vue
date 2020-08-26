<template>
  <div>
    <edit-table v-model="data" :columns="columns" style="width: 600px;margin-left: 10px;"></edit-table>
    <button @click="logData">Log Data</button>
  </div>
</template>

<script>
import EditTable from './components/edit-table'
export default {
  name: 'Test',
  data() {
    return {
      data: [],
      columns: []
    }
  },
  components: {
    EditTable
  },
  methods: {
    logData() {
      console.log(this.data)
    }
  },
  created() {
    this.columns = [
      {
        type: 'index',
        label: '序号',
        width: 100
      },
      {
        prop: 'id',
        label: '编号',
        width: 200
      },
      {
        prop: 'gender',
        label: '性别',
        type: 'select',
        options: {
          0: '女',
          1: '男'
        },
        editable: true,
        width: 100
      },
      {
        prop: 'name',
        label: '名称',
        editable: true
      }
    ]
  },
  mounted() {
    this.data = [
      {
        id: '001',
        name: '科比',
        gender: 1
      },
      {
        id: '002',
        name: '勒布朗',
        gender: 1
      }
    ]
  }
}
</script>
