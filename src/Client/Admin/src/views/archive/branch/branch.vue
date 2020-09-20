<template>
  <div>
    <list-page
      ref="listpage"
      uri="/api/a/branch"
      dialog-title="机构"
      show-data-maintain
      :query-params="queryParams"
      :columns="columns"
      :model-rules="modelRules"
      :model.sync="model"
      :action.sync="action"
      :left-span="4"
      @on-save="refreshTree"
      @on-delete="refreshTree"
    >
      <template slot="queryForm">
        <el-form-item prop="keyword">
          <el-input v-model="queryParams.keyword" placeholder="编码/名称" />
        </el-form-item>
      </template>

      <template slot="mainLeft">
        <el-tree
          default-expand-all
          :expand-on-click-node="false"
          :data="branchTreeData"
          @node-click="handleNodeClick"
        />
      </template>

      <template>
        <el-divider></el-divider>
        <el-row>
          <el-col :span="8">
            <el-form-item prop="parent" label="上级机构">
              <picker
                type="branch"
                v-model="model.parentId"
                :label.sync="model.parentName"
                :query-params="parentBranchQueryParams"
                :disabled="model.type == 0"
                @selected="branchSelected"
              />
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item prop="id" label="机构编码">
              <el-input v-model="model.id" :disabled="action != 'add'" />
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item prop="type" label="机构类型">
              <el-select v-model="model.type" :disabled="!model.parent || !model.parent.id">
                <el-option
                  v-for="(label,key) in branchType"
                  :key="key"
                  :value="Number(key)"
                  :label="label"
                  :disabled="branchTypeDisabled(key)"
                />
              </el-select>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="8">
            <el-form-item prop="name" label="机构名称">
              <el-input v-model="model.name" />
            </el-form-item>
          </el-col>
          <el-col :span="8">
            <el-form-item prop="shortName" required label="机构简称">
              <el-input v-model="model.shortName" />
            </el-form-item>
          </el-col>
        </el-row>

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
          <el-col :span="8">
            <el-form-item prop="address" label="地址">
              <el-input v-model="model.address" />
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
import request from '@/utils/request'
import { branchType } from '@/utils/enum'
import { loadBranchTreeData } from '@/api/branch'
export default {
  name: 'ArchiveBranch',
  data() {
    return {
      queryParams: {
        parentId: ''
      },
      columns: [],
      model: { },
      branchType,
      branchTreeData: [],
      action: ''
    }
  },
  computed: {
    parentBranchQueryParams() {
      return {
        typeList: [0, 1]
      }
    },
    modelRules() {
      const vm = this
      return {
        'parent': [
          { required: vm.model.type !== 0, message: '上级机构必填', trigger: 'blur' }
        ],
        id: [
          { required: true, message: '编码必填', trigger: 'blur' },
          { type: 'string', pattern: /^[0-9]{2}$/, message: '编码只能输入两位数字字符', trigger: 'blur' },
          {
            validator(rule, value, callback) {
              if (vm.action === 'add') {
                request({
                  url: `/api/a/branch/${value}/_exists`,
                  method: 'get'
                }).then(response => {
                  if (response) {
                    callback(new Error('编码已存在'))
                  } else {
                    callback()
                  }
                })
              } else {
                callback()
              }
            }
          }
        ],
        type: [
          { required: true, message: '机构类型必填' }
        ],
        name: [
          { required: true, message: '机构名称必填', trigger: 'blur' },
          { type: 'string', max: 20, message: '长度不能操作20个字符', trigger: 'blur' }
        ],
        shortName: [
          { required: true, message: '机构简称必填', trigger: 'blur' },
          { type: 'string', max: 10, message: '长度不能操作10个字符', trigger: 'blur' }
        ],
        contactsEmail: [
          { type: 'email', message: '邮箱格式错误', trigger: 'blur' }
        ]
      }
    }
  },
  methods: {
    handleNodeClick(data) {
      this.queryParams.ancestorId = data.id
      this.$refs.listpage.query()
    },
    refreshTree() {
      loadBranchTreeData().then(response => {
        this.branchTreeData = response
      })
    },
    branchTypeDisabled(key) {
      return key === 0
    },
    branchSelected(data) {
      this.model.parent.type = data.type
    }
  },
  mounted() {
    this.refreshTree()
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
        label: '机构名称',
        width: 150
      },
      {
        prop: 'type',
        type: 'enum',
        label: '机构类型',
        width: 100,
        enums: branchType
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
        prop: 'address',
        label: '地址'
      }
    ]
  }
}
</script>
