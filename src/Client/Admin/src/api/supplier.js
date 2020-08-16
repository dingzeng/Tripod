import request from '@/utils/request'

export function loadSupplierRegionTreeData() {
  return request({
    url: '/api/p/supplierRegion/tree',
    method: 'get'
  })
}
