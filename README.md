# Tripod

## 服务端口

|Service|http|https|短标识|
|---|---|---|---|
|Web.Bff.Admin|5000|-|-|
|Identity.API|5001|-|i|
|Archive.API|5002|-|a|
|System.API|5003|50030|s|
|Stock.API|5004|-|t|


## 接口规范

|HTTP Status|用途|
|---|---|
|200|正常|
|400|参数验证失败；业务验证失败；|
|404|资源不存在|
|500|异常|

## 菜单结构

- 系统1
- 系统2
    - 模块1
    - 模块2
        - 菜单组1
        - 菜单组2
            - 菜单1
            - 菜单2
    - 模块3
- 系统3

## EntityFramework Mapping
|C# Type|DB Type|可空默认项|
|---|---|---|
|string|nvarchar(max)/nvarchar(450)|null|
|string(Key)|nvarchar(450)|null|
|int|int|not null|
|long|bigint|not null|
|DateTime|datetime2(7)|not null|
|decimal|decimal(18,2)|not null|
|bool|bit|not null|
|可空值类型|-|null|

## TODO
