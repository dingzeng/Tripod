import request from '@/utils/request'
import qs from 'qs'

const api = {}

api.queryApi = (uri, data) => {
  const querystring = qs.stringify(data)
  return request({
    url: uri + '?' + querystring,
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
