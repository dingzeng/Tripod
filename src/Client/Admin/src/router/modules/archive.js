import Layout from '@/layout'
export default {
  path: '/archive',
  component: Layout,
  children: [
    {
      path: 'branch-group',
      component: () => import('@/views/archive/branch/branchGroup'),
      name: 'ArchiveBranchGroup',
      meta: { title: '机构组' }
    },
    {
      path: 'branch',
      component: () => import('@/views/archive/branch/branch'),
      name: 'ArchiveBranch',
      meta: { title: '机构档案' }
    },
    {
      path: 'supplier-region',
      component: () => import('@/views/archive/supplier/supplierRegion'),
      name: 'ArchiveSupplierRegion',
      meta: { title: '供应商区域' }
    },
    {
      path: 'supplier',
      component: () => import('@/views/archive/supplier/supplier'),
      name: 'ArchiveSupplier',
      meta: { title: '供应商' }
    },
    {
      path: 'item-cls',
      component: () => import('@/views/archive/item/itemCls'),
      name: 'ArchiveItemCls',
      meta: { title: '商品类别' }
    },
    {
      path: 'item-brand',
      component: () => import('@/views/archive/item/itemBrand'),
      name: 'ArchiveItemBrand',
      meta: { title: '商品品牌' }
    },
    {
      path: 'item-department',
      component: () => import('@/views/archive/item/itemDepartment'),
      name: 'ArchiveItemDepartment',
      meta: { title: '商品部门' }
    },
    {
      path: 'itemUnit',
      component: () => import('@/views/archive/item/itemUnit'),
      name: 'ArchiveItemUnit',
      meta: { title: '商品单位' }
    },
    {
      path: 'item',
      component: () => import('@/views/archive/item/item'),
      name: 'ArchiveItem',
      meta: { title: '商品' }
    }
  ]
}
