<template>
  <div>
    <list-page
      uri="/api/a/item"
      dialogTitle="商品"
      dialogWidth="1200px"
      :columns="columns"
      :queryParams.sync="queryParams"
      :model.sync="model"
      :modelRules="modelRules"
      :leftSpan="4"
      :action.sync="action"
      @model-load="modelLoad"
    >
      <template slot="queryForm">
        <el-form-item prop="keyword">
          <el-input v-model="queryParams.keyword" placeholder="编码/国际条码/名称"></el-input>
        </el-form-item>
      </template>
      <template slot="mainLeft">
        <el-select v-model="treeType" @change="treeTypeChange">
          <el-option :value="0" label="供应商" />
          <el-option :value="1" label="商品类别" />
          <el-option :value="2" label="商品品牌" />
        </el-select>
        <el-tree
          :data="treeData"
          @node-click="handleNodeClick"
          default-expand-all
        >
        </el-tree>
      </template>
      <template>
        <el-tabs tab-position="left" style="height: 500px;">
          <el-tab-pane label="基础信息">
            <el-row>
              <el-col :span="8">
                <el-form-item prop="id" label="编码">
                  <el-input v-model="model.id" :disabled="action != 'add'"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="barcode" label="国际条码">
                  <el-input v-model="model.barcode" :disabled="action != 'add'"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="status" label="状态">
                  <!-- TODO  -->
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="8">
                <el-form-item prop="name" label="名称">
                  <el-input v-model="model.name"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="shortName" label="简称">
                  <el-input v-model="model.shortName"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="unitName" label="库存单位">
                  <el-input v-model="model.unitName"></el-input>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="8">
                <el-form-item prop="categoryId" label="类别">
                  <ref-input v-model="model.categoryId" type="category" :label.sync="model.categoryName"></ref-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="itemBrandId" label="品牌">
                  <ref-input v-model="model.itemBrandId" type="itemBrand" :label.sync="model.itemBrandName"></ref-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="itemDepartmentId" label="商品部门">
                  <ref-input v-model="model.itemDepartmentId" type="itemDepartment" :label.sync="model.itemDepartmentName"></ref-input>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="8">
                <el-form-item prop="supplierId" label="主供应商">
                  <ref-input v-model="model.supplierId" type="supplier" :label.sync="model.supplierName"></ref-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="purchasePrice" label="采购价">
                  <el-input v-model="model.purchasePrice"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="isFresh" label="生鲜商品">
                  <el-checkbox v-model="model.isFresh"></el-checkbox>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="8">
                <el-form-item prop="retailPrice" label="零售价">
                  <el-input v-model="model.retailPrice"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="salesPrice" label="批发价">
                  <el-input v-model="model.salesPrice"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="deliveryPrice" label="配送价">
                  <el-input v-model="model.deliveryPrice"></el-input>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="8">
                <el-form-item prop="referProfitRate" label="参考利率">
                  <el-input v-model="model.referProfitRate"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="transportMode" label="物流模式">
                  <el-select v-model="model.transportMode">
                    <el-option
                      v-for="(label,key) in transportMode"
                      :key="key"
                      :value="Number(key)"
                      :label="label"
                    />
                  </el-select>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="size" label="规格">
                  <el-input v-model="model.size"></el-input>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="8">
                <el-form-item prop="leastDeliveryQty" label="最小配送数量">
                  <el-input-number v-model="model.leastDeliveryQty"></el-input-number>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="qualityDays" label="保质天数">
                  <el-input-number v-model="model.qualityDays"></el-input-number>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="warningDays" label="临期预计天数">
                  <el-input-number v-model="model.warningDays"></el-input-number>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="8">
                <el-form-item prop="productionPlace" label="产地">
                  <el-input v-model="model.productionPlace"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="purchaseTaxRate" label="进项税税率">
                  <el-input v-model="model.purchaseTaxRate"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="salesTaxRate" label="销项税税率">
                  <el-input v-model="model.salesTaxRate"></el-input>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="8">
                <el-form-item prop="memo" label="备注">
                  <el-input v-model="model.memo"></el-input>
                </el-form-item>
              </el-col>
            </el-row>
          </el-tab-pane>
          <el-tab-pane label="商品条码">

          </el-tab-pane>
          <el-tab-pane label="大包装">

          </el-tab-pane>
          <el-tab-pane label="子商品">

          </el-tab-pane>
          <el-tab-pane label="图片">

          </el-tab-pane>
        </el-tabs>
      </template>
    </list-page>
  </div>
</template>

<script>
import request from '@/utils/request'
import { transportMode } from '@/utils/enum'
export default {
  name: 'Item',
  data() {
    return {
      columns: [],
      queryParams: {},
      model: {
        item: {
          transportMode: 0
        }
      },
      treeType: 0,
      treeData: [],
      action: '',
      transportMode: transportMode,
      originalId: '',
      originalBarcode: ''
    }
  },
  methods: {
    handleNodeClick(data) {
      if (this.treeType === 0) {
        this.queryParams.primarySupplierId = data.id
      } else if (this.treeType === 1) {
        this.queryParams.categoryId = data.id
      } else if (this.treeType === 2) {
        this.queryParams.itemBrandId = data.id
      }
      this.$refs.listpage.query()
    },
    modelLoad(model) {
      this.originalId = model.id
      this.originalBarcode = model.barcode
    },
    loadTreeData() {
      let url = ''
      if (this.treeType === 0) {
        url = '/api/p/supplier/tree'
      } else if (this.treeType === 1) {
        url = '/api/a/category/tree'
      } else if (this.treeType === 2) {
        url = '/api/a/brand/tree'
      }
      request({
        url,
        method: 'get'
      }).then(response => {
        this.treeData = response
      })
    },
    treeTypeChange(type) {
      this.treeType = type
      this.loadTreeData()
    }
  },
  created() {
    this.columns = [
      {
        prop: 'id',
        width: 100,
        label: '编码'
      },
      {
        prop: 'barcode',
        width: 100,
        label: '国际条码'
      },
      {
        prop: 'name',
        label: '名称'
      },
      {
        prop: 'categoryName',
        width: 100,
        label: '商品类别'
      },
      {
        prop: 'itemBrandName',
        width: 100,
        label: '商品品牌'
      },
      {
        prop: 'itemDepartmentName',
        width: 100,
        label: '商品部门'
      },
      {
        prop: 'itemUnitName',
        width: 100,
        label: '包装单位'
      },
      {
        prop: 'primary_supplier_name',
        width: 150,
        label: '主供应商'
      },
      {
        prop: 'status',
        width: 100,
        label: '状态'
      },
      {
        prop: 'retailPrice',
        width: 100,
        label: '零售价'
      },
      {
        prop: 'purchasePrice',
        width: 100,
        label: '采购价'
      },
      {
        prop: 'salesPrice',
        width: 100,
        label: '批发价'
      },
      {
        prop: 'deliveryPrice',
        width: 100,
        label: '配送价'
      },
      {
        prop: 'referProfitRate',
        width: 100,
        label: '参考利率'
      },
      {
        prop: 'size',
        width: 100,
        label: '规格'
      },
      {
        prop: 'transportMode',
        width: 100,
        label: '物流模式'
      }
    ]
  },
  mounted() {
    this.loadTreeData()
  },
  computed: {
    modelRules() {
      const vm = this
      return {
        item: {
          id: [
            { required: true, message: '必填', trigger: 'blur' },
            { type: 'string', pattern: /^[0-9]{5,20}$/, message: '必须为5~20位数字字符', trigger: 'blur' },
            {
              validator(rule, value, callback) {
                request({
                  url: '/archive/item/exists/id/' + value,
                  method: 'get'
                }).then(response => {
                  if (response && vm.originalId !== value) {
                    callback(new Error('编码已存在'))
                  } else {
                    callback()
                  }
                })
              }
            }
          ],
          barcode: [
            { required: true, message: '必填', trigger: 'blur' },
            { type: 'string', pattern: /^[0-9]{5,20}$/, message: '必须为5~20位数字字符', trigger: 'blur' },
            {
              validator(rule, value, callback) {
                request({
                  url: '/archive/item/exists/barcode/' + value,
                  method: 'get'
                }).then(response => {
                  if (response && vm.originalBarcode !== value) {
                    callback(new Error('国际条码已存在'))
                  } else {
                    callback()
                  }
                })
              }
            }
          ],
          name: [
            { required: true, message: '必填', trigger: 'blur' },
            { type: 'string', max: 20, message: '长度不能超过20位字符', trigger: 'blur' }
          ],
          shortName: [
            { required: true, message: '必填', trigger: 'blur' },
            { type: 'string', max: 10, message: '长度不能超过10位字符', trigger: 'blur' }
          ],
          itemUnitId: [
            { required: true, message: '必填', trigger: 'blur' }
          ],
          categoryId: [
            { required: true, message: '必填', trigger: 'blur' }
          ],
          itemBrandId: [
            { required: true, message: '必填', trigger: 'blur' }
          ],
          itemDepartmentId: [
            { required: true, message: '必填', trigger: 'blur' }
          ],
          supplierId: [
            { required: true, message: '必填', trigger: 'blur' }
          ],
          purchasePrice: [
            { pattern: /^-?\d+\.?\d*$/, message: '只能为数值', trigger: 'blur' }
          ],
          retailPrice: [
            { pattern: /^-?\d+\.?\d*$/, message: '只能为数值', trigger: 'blur' }
          ],
          salesPrice: [
            { pattern: /^-?\d+\.?\d*$/, message: '只能为数值', trigger: 'blur' }
          ],
          deliveryPrice: [
            { pattern: /^-?\d+\.?\d*$/, message: '只能为数值', trigger: 'blur' }
          ],
          referProfitRate: [
            { type: 'float', message: '格式错误', trigger: 'blur' },
            { type: 'float', range: [0, 1], message: '必须为0~1之间的小数', trigger: 'blur' }
          ],
          transportMode: [
            { required: true, message: '必填', trigger: 'blur' }
          ],
          leastDeliveryQty: [
            { type: 'integer', min: 1, message: '必须为正整数', trigger: 'blur' }
          ],
          qualityDays: [
            { type: 'integer', min: 1, message: '必须为正整数', trigger: 'blur' }
          ],
          warningDays: [
            { type: 'integer', min: 1, message: '必须为正整数', trigger: 'blur' }
          ],
          purchaseTaxRate: [
            { type: 'float', message: '格式错误', trigger: 'blur' },
            { type: 'float', range: [0, 1], message: '必须为0~1之间的小数', trigger: 'blur' }
          ],
          salesTaxRate: [
            { type: 'float', message: '格式错误', trigger: 'blur' },
            { type: 'float', range: [0, 1], message: '必须为0~1之间的小数', trigger: 'blur' }
          ],
          memo: [
            { type: 'string', max: 100, message: '长度不能超过100个字符', trigger: 'blur' }
          ]
        }
      }
    }
  }
}
</script>
