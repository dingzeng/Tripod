import request from '@/utils/request'

const api = {}

api.queryApi = (uri, data) => {
  return request({
    url: uri,
    data: data,
    method: 'get'
  })
}

api.getApi = (uri, id) => {
  return request({
    url: uri + '/' + id,
    method: 'get'
  })
}

api.postApi = (uri, data) => {
  return request({
    url: uri,
    method: 'post',
    data: data
  })
}

api.putApi = (uri, data) => {
  return request({
    url: uri,
    method: 'put',
    data: data
  })
}

api.deleteApi = (uri, id) => {
  return request({
    url: uri + '/' + id,
    method: 'delete'
  })
}

export default api
