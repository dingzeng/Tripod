import request from '@/utils/request'

export function loadSupplierRegionTreeData() {
  return request({
    url: '/archive/supplierRegion/tree',
    method: 'get'
  })
}
