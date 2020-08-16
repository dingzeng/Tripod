import request from '@/utils/request'
import qs from 'qs'

export function query(params) {
  return request({
    url: '/api/a/branch?' + qs.stringify(params),
    method: 'get'
  })
}

export function loadBranchTreeData() {
  return request({
    url: '/api/a/branch/tree',
    method: 'get'
  })
}

export function getBranchGroupBranchs(branchGroupId) {
  return request({
    url: `/api/a/branch-group/${branchGroupId}/branch/`,
    method: 'get'
  })
}

export function updateBranchGroupBranchs(branchGroupId, branchIdList) {
  return request({
    url: `/api/a/branch-group/${branchGroupId}/branch/`,
    method: 'put',
    data: branchIdList
  })
}
