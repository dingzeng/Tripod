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
|type|String|text|index/text/select|列类型|
|width|Number|-|-|列宽|
|editable|Boolean|false|-|是否可编辑|
|fixed|String|-|left/right|固定列|
|sortable|Boolean|false|-|是否可排序|
|align|String|left|left/center/right|对齐方式|
|format|Function|-|-|格式化，参数：row, column, cellValue, index|
|total|Boolean|false|-|是否进行列的合计|
|options|Object|-|-|type为select时指定的下拉选项数据|

## 列类型
|类型|是否可编辑|说明|编辑组件|
|---|---|---|---|
|index|-|索引|-|
|text|true|文本类型|input|
|checkbox|true|复选框|checkbox|
|select|true|下拉框|select|
|date|true|日期选择框|-|

## TODO
- 美化表格样式
- 点击单元格时自动聚焦当前单元格中的输入框

