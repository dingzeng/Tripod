
# API

## 身份认证

- POST  /login
- POST  /logout

## 系统模块

### 菜单数据

- GET   /system/menus

### 角色管理

- GET   /system/roles
- GET   /system/role/{id}
- POST  /system/role
- PUT   /system/role
- DEL   /system/role/{id}
- GET   /system/role/{id}/permissions
- PUT   /system/role/{id}/permissions

### 用户管理

- GET   /system/users
- GET   /system/user/{id}
- POST  /system/user
- PUT   /system/user/info
- PUT   /system/user/permission
- PUT   /system/user/roles
- PUT   /system/user/password

