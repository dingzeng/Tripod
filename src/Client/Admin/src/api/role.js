import request from '@/utils/request'

export function getRoles() {
  return request({
    url: '/system/role',
    method: 'get'
  })
}

export function getRole(id) {
  return request({
    url: '/system/role/' + id,
    method: 'get'
  })
}

export function addRole(data) {
  return request({
    url: '/role',
    method: 'post',
    data
  })
}

export function updateRole(id, data) {
  return request({
    url: `/role/${id}`,
    method: 'put',
    data
  })
}

export function deleteRole(id) {
  return request({
    url: `/role/${id}`,
    method: 'delete'
  })
}
