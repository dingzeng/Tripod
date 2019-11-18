var axios = require('axios');
var instance = axios.create({
    baseURL: 'http://localhost:7001',
    timeout: 2000
});

instance.interceptors.response.use(function(data){
    return data;
},function(error){
    console.log(error);
})

export default instance;