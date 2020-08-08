import request from '@/utils/request'

export function login(data) {
  return request({
    url: '/api/login',
    method: 'post',
    data
  })
}

export function getInfo() {
  return request({
    url: '/api/userinfo',
    method: 'get'
  })
}

export function logout(token) {
  return request({
    url: '/api/logout',
    method: 'post',
    data: {
      token
    }
  })
}

export function getUserRoles(userId) {
  return request({
    url: '/api/s/user/role/' + userId,
    method: 'get'
  })
}

export function updateUserRoles(userId, roleIdList) {
  return request({
    url: '/api/s/user/role',
    data: {
      userId,
      roleIdList
    },
    method: 'put'
  })
}
