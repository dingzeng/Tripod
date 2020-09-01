<template>
  <div>
    <edit-table v-model="data" :columns="columns"></edit-table>
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
    },
    randomData() {
      let data = []
      const count = 10
      for (let index = 0; index < count; index++) {
        let row = {}
        row.id = 'A00' + index
        row.name = 'aaa' + index
        row.gender = index % 2
        row.birthday = new Date()
        row.isAdult = index % 2 === 1
        data.push(row)
      }
      return data
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
        prop: 'name',
        label: '名称',
        editable: true
      },
      {
        prop: 'gender',
        label: '性别',
        type: 'select',
        options: [
          { value: 0, label: '女' },
          { value: 1, label: '男' }
        ],
        editable: true,
        width: 100
      },
      {
        prop: 'birthday',
        label: '生日',
        type: 'date',
        width: 220,
        editable: true
      },
      {
        prop: 'isAdult',
        label: '已成年',
        type: 'checkbox',
        width: 150,
        editable: true
      },
      {
        label: '操作',
        type: 'handler',
        width: 100,
        actions: [
          'delete',
          {
            type: 'text',
            label: '查看',
            icon: 'el-icon-view',
            visible: function(row) {
              return row.gender === 0
            },
            click: function(row) {
              console.log(row)
            }
          }
        ]
      }
    ]
  },
  mounted() {
    this.data = this.randomData()
  }
}
</script>
