<template>
  <div>
    <edit-table v-model="data" :columns="columns" :actions="actions" indexed>

    </edit-table>
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
      columns: [],
      actions: [
        {
          type: 'text',
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
  },
  components: {
    EditTable
  },
  methods: {
    logData() {
      console.log(this.data)
    },
    randomData() {
      const data = []
      const count = 10
      for (let index = 0; index < count; index++) {
        const row = {}
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
        prop: 'id',
        label: '编号',
        width: 200
      },
      {
        prop: 'name',
        label: '名称',
        type: 'string',
        editable: true,
        required: true
      },
      {
        prop: 'gender',
        label: '性别',
        type: 'enum',
        options: [
          { value: 0, label: '女' },
          { value: 1, label: '男' }
        ],
        editable: true,
        required: true,
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
        type: 'boolean',
        width: 150,
        editable: true
      },
      {
        prop: 'age',
        label: '年龄',
        type: 'integer',
        width: 150,
        editable: true,
        required: true,
        min: 10,
        max: 120
      },
      {
        prop: 'company',
        label: '球队',
        type: 'enum',
        width: 150,
        editable: true,
        options: [
          { value: '1', label: '湖人' },
          { value: '2', label: '火箭' }
        ]
      },
      {
        prop: 'sales',
        label: '薪水',
        type: 'number',
        width: 150,
        editable: true,
        required: true,
        validator(value, row) {
          if (value < 100) {
            return new Error('太低了吧')
          }
          return true
        }
        // asyncValidator(value, row, callback) {
        //   setTimeout(() => {
        //     if(value < 100) {
        //       callback(new Error('涅球少?'))
        //     }else {
        //       callback()
        //     }
        //   }, 1000)
        // }
      }
    ]
  },
  mounted() {
    this.data = this.randomData()
  }
}
</script>
