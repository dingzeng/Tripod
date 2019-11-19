var axios = require('axios');
var cookie = require('js-cookie');

const NO_TOKEN_HEADER = 99;
const TOKEN_EXPIRED = 98;

var instance = axios.create({
    baseURL: 'http://localhost:7001',
    timeout: 2000
});

instance.interceptors.request.use(function(config){
    config.headers.token = cookie.get('token');
    return config;
},function(error){
    return Promise.reject(error);
})

instance.interceptors.response.use(function(response){
    if(response.data.status == NO_TOKEN_HEADER){
        throw new Error(response.data.message)
    }else if(response.data.status == TOKEN_EXPIRED){
        throw new Error(response.data.message)
    }
    return response;
},function(error){
    console.log(error);
})

export default instance;