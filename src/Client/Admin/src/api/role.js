import request from '@/utils/request'

export function getRoles() {
  return request({
    url: '/api/s/role',
    method: 'get'
  })
}

export function getRole(id) {
  return request({
    url: '/api/s/role/' + id,
    method: 'get'
  })
}

export function addRole(data) {
  return request({
    url: '/api/s/role',
    method: 'post',
    data
  })
}

export function updateRole(id, data) {
  return request({
    url: `/api/s/role/${id}`,
    method: 'put',
    data
  })
}

export function deleteRole(id) {
  return request({
    url: `/api/s/role/${id}`,
    method: 'delete'
  })
}
