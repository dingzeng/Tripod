DROP TABLE IF EXISTS `delivery_detail`;

CREATE TABLE `delivery_detail` (
    `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '自增编码',
    `sheet_id` VARCHAR(45) NOT NULL COMMENT '单据号',
    `item_id` VARCHAR(45) NOT NULL COMMENT '商品编码',
    `item_barcode` VARCHAR(45) NOT NULL COMMENT '商品条码',
    `item_name` VARCHAR(45) NOT NULL COMMENT '商品名称',
    `size` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '规格',
    `delivery_unit` VARCHAR(45) NOT NULL COMMENT '配送单位',
	`qty` DECIMAL NOT NULL COMMENT '数量',
    `price` DECIMAL NOT NULL COMMENT '单价',
    `amount` DECIMAL NOT NULL COMMENT '金额',
    `tax_rate` DECIMAL NOT NULL COMMENT '税率',
    `tax_amount` DECIMAL NOT NULL COMMENT '税额',
    `refer_stock_qty` DECIMAL NOT NULL COMMENT '库存数量',
    `retail_price` DECIMAL NOT NULL COMMENT '零售价',
    `stock_qty` DECIMAL NOT NULL COMMENT '基本数量',
	`stock_unit` VARCHAR(45) NOT NULL COMMENT '库存单位',
	`memo` VARCHAR(100) NOT NULL DEFAULT '' COMMENT '备注',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '配送出库单商品明细';
