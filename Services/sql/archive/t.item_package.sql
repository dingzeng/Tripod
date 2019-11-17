DROP TABLE IF EXISTS `item_package`;

CREATE TABLE `item_package` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `item_id` VARCHAR(45) NOT NULL COMMENT '商品编码',
    `barcode` VARCHAR(45) NOT NULL COMMENT '条码',
    `item_unit_id` INT NOT NULL COMMENT '库存单位',
    `item_unit_name` VARCHAR(45) NOT NULL,
    `factor_qty` INT NOT NULL COMMENT '包装系数',
    `retail_price` DECIMAL NOT NULL DEFAULT(0) COMMENT '零售价',
    `sales_price` DECIMAL NOT NULL DEFAULT(0) COMMENT '批发价',
    `is_default_purchase_unit` TINYINT NOT NULL DEFAULT(0) COMMENT '是否为默认采购单位',
    `is_default_delivery_unit` TINYINT NOT NULL DEFAULT(0) COMMENT '是否为默认配送单位',
    `memo` VARCHAR(100) NOT NULL DEFAULT ('') COMMENT '备注',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '商品多包装';
