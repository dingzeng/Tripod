# EditTable

## 特性

- 可编辑
- 自动索引
- 自定义工具栏
- 数据验证
- 行删除&自定义行操作

## TODO
- 选择填充
- 搜索填充
- 合计
- 排序
- 列设置（列顺序、列宽度拖拽）
- 固定列
- 滚动加载（大数据量性能优化）
- 可多选
- 导入/导出

## 表格属性

|参数|类型|默认值|可选值|说明|
|---|---|---|---|---|
|value|Array|-|-|绑定到表格的数据|
|columns|Array|-|-|表格的列配置，见下面表格|
|index|Boolean|false|-|是否显示索引列|
|multi-selectable|Boolean|false|-|是否支持多选|

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
|type|String|string|见下表|列的数据类型|
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

### 列类型（type）

|类型|说明|渲染类型|
|---|---|---|
|boolean|布尔|Switch|
|enum|枚举|Select|
|date|日期|DatePicker|
|string|字符串|Input|
|number|数值|Input|
|integer|整形数值|Input|
|float|浮点数|Input|


### 验证属性

|参数|类型|默认值|说明|
|---|---|---|---|
|required|Boolean|false|是否必填|
|pattern|String、Regxp|-|正则表达式|
|min|Number|-|type为string时，长度不得小于min;type为数值时，数值不得小于min|
|max|Number|-|type为string时，长度不得大于max;type为数值时，数值不得大于max|
|len|Number|-|字符串固定长度验证|
|enum|Array|-|枚举类型可选值|
|validator|Function|-|自定义验证函数，参数value,row|
|asyncValidator|Function|-|自定义异步验证，参数value,row,callback|

**1.自定义同步验证**
```
validator(value, row) {
  if(value < 100) {
    return new Error('太低了吧')
  }
  return true
}
```

**2.自定义异步验证**
```
asyncValidator(value, row, callback) {
    setTimeout(() => {
        if(value < 100) {
            callback(new Error('涅球少?'))
        }else {
            callback()
        }
    }, 1000)
}
```