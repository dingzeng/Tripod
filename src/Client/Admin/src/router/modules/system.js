import Layout from '@/layout'
export default {
  path: '/system',
  component: Layout,
  children: [
    {
      path: 'role',
      component: () => import('@/views/system/role/index'),
      name: 'SystemRole',
      meta: { title: '系统角色', icon: 'bug' }
    },
    {
      path: 'user',
      component: () => import('@/views/system/user/index'),
      name: 'SystemUser',
      meta: { title: '用户', icon: 'bug' }
    }
  ]
}
