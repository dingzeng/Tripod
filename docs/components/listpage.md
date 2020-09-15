# ListPage

列表页面

## Props

|属性|说明|类型|是否必填|默认值|是否双向绑定|
|---|---|---|---|---|---|
|uri|资源地址|String|是|-|-|
|pk|主键名|String|-|id|-|
|columns|列配置|Array|是|-|-|
|queryParams|查询参数|object|-|`{}`|-|
|paramsRules|查询参数验证规则|Object|-|`{}`|-|
|isPaging|是否分页|Boolean|-|`true`|-|
|model|详情数据|Object|是|`{}`|是|
|modelRules|详情数据验证规则|Object|-|`{}`|-|
|dialogTitle|详情对话框标题|String|-|-|-|
|dialogWidth|详情对话框宽度|String|-|50%|-|
|dialogFullscreen|详情对话框是否全屏显示|Boolean|-|`false`|-|
|isLoadPage|是否需要调用_page接口|Boolean|-|`false`|-|
|operations|列表行操作配置|Array|-|`[]`|-|
|page|页面初始数据|Object|-|`{}`|是|
|showDataMaintain|详情对话框是否显示数据维护信息|Boolean|-|`false`|-|
|action|详情对话框动作类型(add/edit )|String|-|-|是|
|leftSpan|列表左侧插槽区域宽度|Number|-|0|-|

## Events

|事件|说明|参数|
|---|---|---|
|model-load|加载||
|on-delete|删除||
|on-save|保存||

## Slots

|插槽|说明|
|---|---|
|queryForm|列表查询表单插槽|
|mainLeft|列表表格左侧区域插槽|
|-|默认插槽，详情表单插槽|

## Methods

|方法|说明|参数|
|---|---|---|
|query|列表查询|-|
