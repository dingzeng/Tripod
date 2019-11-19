DROP TABLE IF EXISTS `item_sub`;

CREATE TABLE `item_sub` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `item_id` VARCHAR(45) NOT NULL COMMENT '商品编码',
    `barcode` VARCHAR(45) NOT NULL COMMENT '条码',
    `name` VARCHAR(45) NOT NULL COMMENT '子商品名称',
    `retail_price` DECIMAL NOT NULL DEFAULT 0 COMMENT '零售价',
    `sales_price` DECIMAL NOT NULL DEFAULT 0 COMMENT '批发价',
    `memo` VARCHAR(100) NOT NULL DEFAULT '' COMMENT '备注',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '子商品';
