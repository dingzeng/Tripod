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
      :action.sync="action"
      @model-load="modelLoad"
    >
      <template slot="queryForm">
        <el-form-item prop="keyword">
          <el-input v-model="queryParams.keyword" placeholder="编码/国际条码/名称"></el-input>
        </el-form-item>
        <el-form-item prop="categoryId">
          <ref-input type="category" placeholder="类别" @selected="queryParams.categoryId = $event.id"></ref-input>
        </el-form-item>
        <el-form-item prop="brandId">
          <ref-input type="brand" placeholder="品牌" @selected="queryParams.brandId = $event.id"></ref-input>
        </el-form-item>
        <el-form-item prop="departmentId">
          <ref-input type="department" placeholder="商品部门" @selected="queryParams.departmentId = $event.id"></ref-input>
        </el-form-item>
      </template>

      <template>
        <el-tabs tab-position="left" style="height: 500px;">
          <el-tab-pane label="基础信息">
            <el-row>
              <el-col :span="8">
                <el-form-item prop="id" label="编码" required>
                  <el-input v-model="model.id" :disabled="action != 'add'"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="barcode" label="国际条码" required>
                  <el-input v-model="model.barcode" :disabled="action != 'add'"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="status" label="状态">
                  <el-switch v-model="model.status" active-text="启用" inactive-text="禁用" :active-value="0" :inactive-value="9"></el-switch>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="8">
                <el-form-item prop="name" label="名称" required>
                  <el-input v-model="model.name"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="shortName" label="简称" required>
                  <el-input v-model="model.shortName"></el-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="unitName" label="库存单位" required>
                  <el-input v-model="model.unitName"></el-input>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="8">
                <el-form-item prop="category3" label="类别" required>
                  <ref-input v-model="model.category3" type="category"></ref-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="brand" label="品牌" required>
                  <ref-input v-model="model.brand" type="brand"></ref-input>
                </el-form-item>
              </el-col>
              <el-col :span="8">
                <el-form-item prop="department" label="商品部门" required>
                  <ref-input v-model="model.department" type="department"></ref-input>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="8">
                <el-form-item prop="supplier" label="主供应商" required>
                  <ref-input v-model="model.supplier" type="supplier"></ref-input>
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
                <el-form-item prop="retailPrice" label="零售价" required>
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
                <el-form-item prop="transportMode" label="物流模式" required>
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
            <edit-table v-model="model.barcodes" :columns="barcodesColumns"></edit-table>
          </el-tab-pane>
          <el-tab-pane label="大包装">
            <edit-table v-model="model.packages" :columns="packagesColumns"></edit-table>
          </el-tab-pane>
        </el-tabs>
      </template>
    </list-page>
  </div>
</template>

<script>
import EditTable from '@/views/components/edit-table'
import request from '@/utils/request'
import { transportMode } from '@/utils/enum'
export default {
  name: 'Item',
  components: { EditTable },
  data() {
    return {
      columns: [],
      barcodesColumns: [],
      packagesColumns: [],
      queryParams: {},
      model: {
        barcodes: [],
        packages: []
      },
      action: '',
      transportMode: transportMode,
      originalId: '',
      originalBarcode: ''
    }
  },
  methods: {
    modelLoad(model) {
      this.originalId = model.id
      this.originalBarcode = model.barcode
    }
  },
  mounted() {

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
          category: [
            { required: true, message: '必填', trigger: 'blur' }
          ],
          brand: [
            { required: true, message: '必填', trigger: 'blur' }
          ],
          department: [
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
        prop: 'category3.name',
        width: 100,
        label: '商品类别'
      },
      {
        prop: 'brand.name',
        width: 100,
        label: '商品品牌'
      },
      {
        prop: 'department.name',
        width: 100,
        label: '商品部门'
      },
      {
        prop: 'unitName',
        width: 100,
        label: '包装单位'
      },
      {
        prop: 'supplierName',
        width: 150,
        label: '主供应商'
      },
      {
        prop: 'status',
        type: 'tag',
        label: '状态',
        tagTypes: {
          0: 'success',
          9: 'info'
        },
        tagLabels: {
          0: '启用',
          9: '禁用'
        }
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
        prop: 'transportMode',
        width: 100,
        label: '物流模式',
        type: 'enum',
        enums: transportMode
      }
    ]

    this.barcodesColumns = [
      {
        prop: 'Barcode',
        width: 200,
        label: '条码',
        editable: true
      },
      {
        prop: 'memo',
        label: '备注',
        editable: true
      }
    ]

    this.packagesColumns = [
      {
        prop: 'barcode',
        width: 200,
        label: '条码',
        editable: true
      },
      {
        prop: 'unitName',
        width: 100,
        label: '单位',
        editable: true
      },
      {
        prop: 'factorQty',
        width: 100,
        label: '包装系数',
        editable: true
      },
      {
        prop: 'purchasePrice',
        width: 150,
        label: '采购价',
        editable: true
      },
      {
        prop: 'deliveryPrice',
        width: 150,
        label: '配送价',
        editable: true
      },
      {
        prop: 'salesPrice',
        width: 150,
        label: '批发价',
        editable: true
      },
      {
        prop: 'retailPrice',
        width: 150,
        label: '零售价',
        editable: true
      },
      {
        prop: 'isDefaultPurchaseUnit',
        width: 150,
        type: 'checkbox',
        label: '默认采购单位',
        editable: true
      },
      {
        prop: 'isDefaultDeliveryUnit',
        width: 150,
        type: 'checkbox',
        label: '默认配送单位',
        editable: true
      },
      {
        prop: 'memo',
        width: 150,
        label: '备注',
        editable: true
      }
    ]
  }
}
</script>
