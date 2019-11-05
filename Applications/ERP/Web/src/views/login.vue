<template>
    <div>
        <el-form>
            <el-form-item label="用户名">
                <el-input></el-input>
            </el-form-item>
            <el-form-item label="密码">
                <el-input></el-input>
            </el-form-item>
            <el-button>登 录</el-button>
        </el-form>
    </div>
</template>

<script>
export default {
    name: 'login',
    data() {
        return {
            message: 'i am login page'
        }
    }
}
</script>