DROP TABLE IF EXISTS `item_purchase_price`;

CREATE TABLE `item_purchase_price` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `item_id` VARCHAR(45) NOT NULL COMMENT '商品编码',
    `barcode` VARCHAR(45) NOT NULL COMMENT '条码',
    `branch_id` VARCHAR(45) NOT NULL COMMENT '机构',
    `supplier_id` VARCHAR(45) NOT NULL COMMENT '供应商',
    `item_unit_id` INT NOT NULL COMMENT '包装单位',
    `item_unit_name` VARCHAR(45) NOT NULL,
    `factor_qty` INT NOT NULL COMMENT '包装系数',
    `purchase_price` DECIMAL NOT NULL DEFAULT(0) COMMENT '进价',
    `memo` VARCHAR(100) NOT NULL DEFAULT ('') COMMENT '备注',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '商品进价';
