import request from '@/utils/request'
import qs from 'qs'

export function query(params) {
  return request({
    url: '/archive/branch?' + qs.stringify(params),
    method: 'get'
  })
}

export function loadBranchTreeData() {
  return request({
    url: '/archive/branch/tree',
    method: 'get'
  })
}

export function getBranchGroupBranchs(branchGroupId) {
  return request({
    url: '/archive/branchGroup/branch/' + branchGroupId,
    method: 'get'
  })
}

export function updateBranchGroupBranchs(branchGroupId, branchIdList) {
  return request({
    url: '/archive/branchGroup/branch/',
    method: 'put',
    data: {
      branchGroupId,
      branchIdList
    }
  })
}
