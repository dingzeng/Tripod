<template>
  <div>
    <list-page
      ref="listpage"
      uri="/api/p/supplier"
      dialog-title="供应商"
      :query-params="queryParams"
      :columns="columns"
      :model-rules="modelRules"
      :model.sync="model"
      :left-span="4"
      show-data-maintain
      @model-load="modelLoad"
    >
      <template slot="queryForm">
        <el-form-item prop="keyword">
          <el-input v-model="queryParams.keyword" placeholder="编码/名称" />
        </el-form-item>
        <el-form-item prop="type">
          <el-select v-model="queryParams.type" placeholder="经营方式" clearable>
            <el-option v-for="(label,value) in sellWay" :key="value" :label="label" :value="value"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item prop="settlementMode">
          <el-select v-model="queryParams.settlementMode" placeholder="结算方式" clearable>
            <el-option v-for="(label,value) in settleWay" :key="value" :label="label" :value="value"></el-option>
          </el-select>
        </el-form-item>
      </template>
      <template slot="mainLeft">
        <el-tree
          default-expand-all
          :expand-on-click-node="false"
          :data="supplierRegionTreeData"
          @node-click="handleNodeClick"
        />
      </template>
      <template>
        <el-divider content-position="left">基础信息</el-divider>
        <el-row>
          <el-col :span="8">
            <el-form-item prop="id" label="编码">
              <el-input v-model="model.id"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item prop="name" label="名称">
              <el-input v-model="model.name"></el-input>
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item prop="regionId" label="区域">
              <ref-input v-model="model.regionId" type="supplierRegion" :label.sync="model.regionName"></ref-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="8">
            <el-form-item prop="sellWay" label="经营方式" required>
              <el-select v-model="model.sellWay">
                <el-option
                  v-for="(label,key) in sellWay"
                  :key="key"
                  :value="Number(key)"
                  :label="label"
                />
              </el-select>
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item prop="settleWay" label="结算方式" required>
              <el-select v-model="model.settleWay">
                <el-option
                  v-for="(label,key) in settleWay"
                  :key="key"
                  :value="Number(key)"
                  :label="label"
                />
              </el-select>
            </el-form-item>
          </el-col>
          <el-col v-if="model.settleWay == 2" :span="8">
            <el-form-item prop="settleDays" label="结算周期天数">
              <el-input-number v-model="model.settleDays"></el-input-number>
            </el-form-item>
          </el-col>
          <el-col v-if="model.settleWay == 3" :span="8">
            <el-form-item prop="settleDate" label="结算日期">
              <el-input-number v-model="model.settleDate"></el-input-number>
            </el-form-item>
          </el-col>
        </el-row>

        <el-divider content-position="left">通讯信息</el-divider>
        <el-row>
          <el-col :span="8">
            <el-form-item prop="contactsName" label="联系人">
              <el-input v-model="model.contactsName" />
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item prop="contactsMobile" label="手机号">
              <el-input v-model="model.contactsMobile" />
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item prop="contactsTel" label="电话号码">
              <el-input v-model="model.contactsTel" />
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="8">
            <el-form-item prop="contactsEmail" label="邮箱">
              <el-input v-model="model.contactsEmail" />
            </el-form-item>
          </el-col>
        </el-row>

        <el-divider content-position="left">其它信息</el-divider>
        <el-row>
          <el-col :span="8">
            <el-form-item prop="accountBank" label="开户行">
              <el-input v-model="model.contactsName" />
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item prop="accountNo" label="账号">
              <el-input v-model="model.contactsMobile" />
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item prop="taxRegistrationNo" label="税务登记号">
              <el-input v-model="model.taxRegistrationNo" />
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="8">
            <el-form-item prop="businessLicenseNo" label="营业执照号">
              <el-input v-model="model.businessLicenseNo" />
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item prop="memo" label="备注">
              <el-input v-model="model.memo" />
            </el-form-item>
          </el-col>
        </el-row>

      </template>
    </list-page>
  </div>
</template>

<script>
import { sellWay, settleWay } from '@/utils/enum'
import request from '@/utils/request'
import ListPage from '@/views/components/list-page/index'
import RefInput from '@/views/components/ref-input/index'
export default {
  name: 'Supplier',
  components: { ListPage, RefInput },
  data: () => {
    return {
      queryParams: {
        regionId: ''
      },
      columns: [],
      model: {
        sellWay: 0,
        settleWay: 0
      },
      supplierRegionTreeData: [],
      originalId: '',
      sellWay: sellWay,
      settleWay: settleWay
    }
  },
  methods: {
    handleNodeClick(data) {
      this.queryParams.regionId = data.id
      this.$refs.listpage.query()
    },
    modelLoad(model) {
      this.originalId = model.id
    }
  },
  mounted() {
    request({
      url: '/api/p/supplier-region',
      method: 'GET'
    }).then(response => {
      this.supplierRegionTreeData = response.map(s => {
        return {
          id: s.id,
          label: s.name,
          children: [],
          level: 1
        }
      })
    })
  },
  created() {
    this.columns = [
      {
        prop: 'id',
        label: '编码',
        width: 100
      },
      {
        prop: 'name',
        label: '名称',
        width: 150
      },
      {
        prop: 'sellWay',
        label: '经营方式',
        type: 'enum',
        width: 100,
        enums: sellWay
      },
      {
        prop: 'settleWay',
        label: '结算方式',
        type: 'enum',
        width: 100,
        enums: settleWay
      },
      {
        prop: 'status',
        type: 'tag',
        label: '状态',
        tagTypes: {
          0: 'info',
          1: 'success'
        },
        tagLabels: {
          0: '禁用',
          1: '启用'
        }
      },
      {
        prop: 'contactsName',
        label: '联系人',
        width: 100
      },
      {
        prop: 'contactsMobile',
        label: '联系电话',
        width: 100
      },
      {
        prop: 'createOperName',
        label: '创建人',
        width: 100
      },
      {
        prop: 'memo',
        label: '备注'
      }
    ]
  },
  computed: {
    modelRules() {
      const vm = this
      return {
        id: [
          { required: true, message: '编码必填', trigger: 'blur' },
          { type: 'string', pattern: /^[0-9]{3}$/, message: '编码只能输入三位数字字符', trigger: 'blur' },
          {
            validator(rule, value, callback) {
              request({
                url: `/api/p/supplier/${value}/_exists`,
                method: 'get'
              }).then(response => {
                if (response && vm.originalId !== value) {
                  callback(new Error('编码已存在'))
                } else {
                  callback()
                }
              })
            },
            trigger: 'blur'
          }
        ],
        name: [
          { required: true, message: '名称必填', trigger: 'blur' },
          { type: 'string', max: 20, message: '长度不能超过20位字符' }
        ],
        regionId: [
          { required: true, message: '区域不能为空', trigger: 'blur' }
        ],
        sellWay: [
          { required: true, message: '经营方式不能为空', trigger: 'blur' }
        ],
        settleWay: [
          { required: true, message: '结算方式不能为空', trigger: 'blur' }
        ],
        settleDays: [
          { required: vm.model.settleWay === 2, message: '结算周期天数必填', trigger: 'blur' },
          { type: 'integer', min: 1 }
        ],
        settleDate: [
          { required: vm.model.settleWay === 3, message: '结算日期必填', trigger: 'blur' },
          { type: 'integer', min: 1, max: 28 }
        ],
        contactsEmail: [
          { type: 'email', trigger: 'blur' }
        ]
      }
    }
  }
}
</script>
