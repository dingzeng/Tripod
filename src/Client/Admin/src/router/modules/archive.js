import Layout from '@/layout'
export default {
  path: '/archive',
  component: Layout,
  children: [
    {
      path: '/branch-group',
      component: () => import('@/views/archive/branch/branchGroup'),
      name: 'ArchiveBranchGroup',
      meta: { title: '机构组' }
    },
    {
      path: '/branch',
      component: () => import('@/views/archive/branch/branch'),
      name: 'ArchiveBranch',
      meta: { title: '机构档案' }
    },
    {
      path: '/category',
      component: () => import('@/views/archive/item/category'),
      name: 'ArchiveItemCls',
      meta: { title: '商品类别' }
    },
    {
      path: '/brand',
      component: () => import('@/views/archive/item/brand'),
      name: 'ArchiveItemBrand',
      meta: { title: '商品品牌' }
    },
    {
      path: '/department',
      component: () => import('@/views/archive/item/department'),
      name: 'ArchiveItemDepartment',
      meta: { title: '商品部门' }
    },
    {
      path: '/item',
      component: () => import('@/views/archive/item/item'),
      name: 'ArchiveItem',
      meta: { title: '商品' }
    }
  ]
}
