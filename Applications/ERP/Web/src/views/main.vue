<style scoped>
    .el-header { 
        background-color: rgb(0, 120, 215); 
        color: white;
        line-height: 60px;
    }
    .el-aside {  }
    .el-main { }
</style>

<template>
    <div>
        <el-container>
            <el-header>
                <el-row type="flex" class="row-bg" justify="space-between">
                    <el-col :span="6">
                        <h4>零售云SAAS</h4>
                    </el-col>
                    <el-col :span="6">
                    </el-col>
                    <el-col :span="6">
                        
                    </el-col>
                </el-row>
            </el-header>
            <el-container style="height: calc(100vh - 48px)">
                <el-aside width="200px">
                    <el-menu
                        default-active="1"
                        class="el-menu-vertical-demo"
                        background-color="#545c64"
                        text-color="#fff"
                        active-text-color="#ffd04b">
                        <el-submenu index="1">
                            <template slot="title">
                                <i class="el-icon-document"></i>
                                <span>基础档案</span>
                            </template>
                            <el-menu-item-group>
                                <template slot="title">商品相关</template>
                                <el-menu-item index="1-11">
                                    <router-link to="/archive/itemcls">商品类别</router-link>
                                </el-menu-item>
                                <el-menu-item index="1-12">
                                    <router-link to="/archive/itembrand">商品品牌</router-link>
                                </el-menu-item>
                                <el-menu-item index="1-13">
                                    <router-link to="/archive/item">商品档案</router-link>
                                </el-menu-item>
                                <el-menu-item index="1-14">
                                    <router-link to="/archive/unit">包装单位</router-link>
                                </el-menu-item>
                            </el-menu-item-group>
                            <el-menu-item-group title="供应商">
                                <el-menu-item index="1-21">供应商区域</el-menu-item>
                                <el-menu-item index="1-22">供应商档案</el-menu-item>
                                <el-menu-item index="1-23">合同管理</el-menu-item>
                            </el-menu-item-group>
                            <el-menu-item-group title="机构">
                                <el-menu-item index="1-31">机构区域</el-menu-item>
                                <el-menu-item index="1-32">机构信息</el-menu-item>
                                <el-menu-item index="1-33">机构组</el-menu-item>
                            </el-menu-item-group>
                            <el-menu-item-group title="客户">
                                <el-menu-item index="1-41">客户区域</el-menu-item>
                                <el-menu-item index="1-42">客户档案</el-menu-item>
                            </el-menu-item-group>
                        </el-submenu>
                        <el-menu-item index="2">
                            <i class="el-icon-s-opportunity"></i>
                            <span slot="title">采购业务</span>
                        </el-menu-item>
                        <el-menu-item index="3">
                            <i class="el-icon-document"></i>
                            <span slot="title">零售业务</span>
                        </el-menu-item>
                        <el-menu-item index="4">
                            <i class="el-icon-s-home"></i>
                            <span slot="title">批发业务</span>
                        </el-menu-item>
                        <el-menu-item index="5">
                            <i class="el-icon-s-finance"></i>
                            <span slot="title">财务管理</span>
                        </el-menu-item>
                        <el-menu-item index="10">
                            <i class="el-icon-setting"></i>
                            <span slot="title">系统管理</span>
                        </el-menu-item>
                    </el-menu>
                </el-aside>
                <el-main>
                    <router-view></router-view>
                </el-main>
            </el-container>
        </el-container>
    </div>
</template>

<script>
export default {
    name: 'container',
    data() {
        return {

        }
    }
}
</script>