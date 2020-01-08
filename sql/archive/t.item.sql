DROP TABLE IF EXISTS `item`;

CREATE TABLE `item` (
    `id` VARCHAR(45) NOT NULL COMMENT '商品编码',
    `barcode` VARCHAR(45) NOT NULL COMMENT '条码',
    `name` VARCHAR(45) NOT NULL COMMENT '商品名称',
    `short_name` VARCHAR(45) NOT NULL COMMENT '简称',
    `item_cls_id` VARCHAR(45) NOT NULL COMMENT '商品类别',
    `item_cls_name` VARCHAR(45) NOT NULL,
    `item_brand_id` VARCHAR(45) NOT NULL COMMENT '商品品牌',
    `item_brand_name` VARCHAR(45) NOT NULL,
    `item_department_id` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '商品部门',
    `item_department_name` VARCHAR(45) NOT NULL DEFAULT '',
    `item_unit_id` INT NOT NULL COMMENT '库存单位',
    `item_unit_name` VARCHAR(45) NOT NULL,
    `primary_supplier_id` VARCHAR(45) NOT NULL COMMENT '主供应商',
    `primary_supplier_name` VARCHAR(45) NOT NULL,
    `status` INT NOT NULL DEFAULT 0 COMMENT '状态 0-正常、9-停用',
    `is_fresh` INT NOT NULL DEFAULT 0 COMMENT '生鲜标志 0-非生鲜商品、1-生鲜商品',
    `retail_price` DECIMAL NOT NULL DEFAULT 0 COMMENT '零售价',
    `purchase_price` DECIMAL NOT NULL DEFAULT 0 COMMENT '进货价',
    `sales_price` DECIMAL NOT NULL DEFAULT 0 COMMENT '批发价',
    `delivery_price` DECIMAL NOT NULL DEFAULT 0 COMMENT '配送价',
    `refer_profit_rate` DECIMAL NOT NULL DEFAULT 0 COMMENT '参考毛利率',
    `size` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '规格',
    `transport_mode` INT NOT NULL DEFAULT 0 COMMENT '物流模式 0-统配、1-直配、2-自采、3-越库',
    `quality_days` INT NULL COMMENT '保质天数',
    `warning_days` INT NULL COMMENT '临期预计天数',
    `least_delivery_qty` INT NULL COMMENT '最小配送数量',
    `production_place` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '产地',
    `purchase_tax_rate` DECIMAL NULL COMMENT '进项税',
    `sales_tax_rate` DECIMAL NULL COMMENT '销项税',
    `memo` VARCHAR(100) NOT NULL DEFAULT '' COMMENT '备注',
    `create_oper_id` BIGINT NOT NULL COMMENT '创建人',
	`create_oper_name` VARCHAR(45) NOT NULL,
	`create_time` DATETIME NOT NULL COMMENT '创建时间',
    `last_update_oper_id` BIGINT NOT NULL COMMENT '最后修改人',
	`last_update_oper_name` VARCHAR(45) NOT NULL,
	`last_update_time` DATETIME NOT NULL COMMENT '最后修改时间',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '商品';
