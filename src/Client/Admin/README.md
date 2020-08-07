# Tripod.AdminUI

## TODOLIST

- ref-input失去焦点后不会触发验证
- list-dialog只有点击查询时才调用接口

## Form Validate

> [https://github.com/yiminghe/async-validator](https://github.com/yiminghe/async-validator)

常用验证规则：
- type
  - string
  - number、integer、float
  - boolean
  - array
  - object
  - enum
  - date
  - url
  - email
- required
- pattern
- min、max
- len
- enum
- whitespace ?
- fields
- transform
- message
- asyncValidator: Function(rule, value, callback)
- validator: Function(rule, value, callback)

## Features
- Print
- Column Setting
- Import & Export
- Custom Data Filter
- Custom Sort

## Edit Table
- Column Setting
- Repeat Check
- Import
- Cell Validate & Row Validate


## 模块&菜单

- 基础档案
  - 机构档案
    - 机构组
    - 机构
  - 供应商档案
    - 供应商区域
    - 供应商
  - 商品档案
    - 商品类别
    - 商品品牌
    - 商品部门
    - 商品单位
    - 商品
  - 商品价格管理
    - 调进货价单
    - 调配送价单
    - 调批发价单
    - 调零售价单
    - 调会员价单
    - 综合调价单
  - 经营范围管理
    - 经营范围群组
    - 经营范围查询
  - 配送范围管理
    - 配送范围管理
  - 供货关系管理
    - 供货资格变更单
    - 供货资格查询
- 采购业务
  - 采购单据
    - 采购订单
    - 直配订单
    - 越库订单
    - 永续订单
  - 验收入库
    - 采购收货单(I)
    - 采购赠品收货单(I)
  - 采购退货
    - 采购退货单(O)
- 配送调拨
  - 配送
    - 配送申请单
    - 配送单(O)
    - 配送收货单(I)
    - 配送差异申请单
    - 配送差异入库单(I)
    - 配送差异出库单(O)
    - 配退申请单
    - 配退单(O)
    - 配退收货单(I)
  - 调拨
- 库管业务
  - 盘点
    - 预盘单
    - 盘点计划
  - 库存查询
    - 出入库明细
    - 商品库存结余
- 批发业务
  - 客户档案
    - 客户区域
    - 客户
- 零售业务
  - 会员档案
    - 会员
  - 促销
    - 促销单
- 财务模块
  - 收费项目
  - 采购合同
- 系统维护
  - 授权管理
    - 角色
    - 用户