import Layout from '@/layout'
export default {
  path: '/purchase',
  component: Layout,
  children: [
    {
      path: '/supplier-region',
      component: () => import('@/views/purchase/supplier/supplierRegion'),
      name: 'ArchiveSupplierRegion',
      meta: { title: '供应商区域' }
    },
    {
      path: '/supplier',
      component: () => import('@/views/purchase/supplier/supplier'),
      name: 'ArchiveSupplier',
      meta: { title: '供应商' }
    }
  ]
}
