<style>
    .login {
        width: 400px;
        margin: 0 auto;
    }
    .login h2 {
        margin-bottom: 10px;
    }
    .login .login-copyright {
        margin-top: 300px;
        color: #888;
        font-size: 14px;
        text-align: center;
    }
    .login-logo {
        height: 200px;
    }
    .login-btn {
        width: 100%;
    }
</style>
<template>
    <div>
        <div class="login">
            <div class="login-logo">
                <!-- TODO 放个logo图片这里 -->
            </div>
            <h2>登录</h2>
            <el-form>
                <el-form-item label="用户名">
                    <el-input v-model="username"></el-input>
                </el-form-item>
                <el-form-item label="密码">
                    <el-input v-model="password" type="password"></el-input>
                </el-form-item>
                <el-form-item label="">
                    <el-checkbox v-model="isRememberPassword">记住密码</el-checkbox>
                </el-form-item>
                <el-button type="primary" @click="login" class="login-btn">登 录</el-button>
            </el-form>
            <p class="login-copyright">Copyright © {{new Date().getFullYear()}} — Tripod</p>
        </div>
    </div>
</template>

<script>
import http from '../util/httpClient'
export default {
    name: 'login',
    data() {
        return {
            username: '',
            password: '',
            isRememberPassword: false,
            // backgroundImageUrl: require('../assets/login_bg.jpg')
        }
    },
    methods: {
        login() {
            http.post('/login',{
                Username: this.username,
                Password: this.password
            }).then(response => {
                if(response.data.status != 0){
                    this.$alert(response.data.message)
                }else{
                    this.$router.push('/')
                }
            })
        }
    }
}
</script>