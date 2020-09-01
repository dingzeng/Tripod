# EditTable

## 特性

- 可编辑
- 列排序
- 固定列
- 滚动加载
- 列设置
- 关键字录入
- 自定义工具栏
- 数据验证

## 表格属性

|参数|类型|默认值|可选值|说明|
|---|---|---|---|---|
|value|Array|-|-|绑定到表格的数据|
|columns|Array|-|-|表格的列配置，见下面表格|

## 表格方法

- clearSelection


## 表格事件
- selection-change
- row-click
- row-dblclick



## 表格列配置

|参数|类型|默认值|可选值|说明|
|---|---|---|---|---|
|label|String|-|-|列标题|
|prop|String|-|-|列的键|
|type|String|text|index/text/select/checkbox/hander|列类型|
|width|Number|-|-|列宽|
|editable|Boolean|false|-|是否可编辑|
|placeholder|String|-|-||
|fixed|String|-|left/right|固定列|
|sortable|Boolean|false|-|是否可排序|
|align|String|left|left/center/right|对齐方式|
|theadAlign|String|left|left/center/right|标题对齐方式|
|format|Function|-|-|格式化，参数：row, column, cellValue, index|
|total|Boolean|false|-|是否进行列的合计|
|options|Array|-|-|type为select时指定的下拉选项数据,eg:[{value: 1, label: '未付款'}]|

## 列类型
|类型|是否可编辑|说明|编辑组件|
|---|---|---|---|
|index|-|索引|-|
|text|true|文本类型|input|
|checkbox|true|复选框|checkbox|
|select|true|下拉框|select|
|date|true|日期选择框|-|
|hander|false|操作处理|-|

## TODO
- 列排序
- 列设置
- 大数据量性能优化
- 选择带入
- 录入搜索带入
- 固定列
- 合计
- 数据验证
- 行删除&自定义行操作

