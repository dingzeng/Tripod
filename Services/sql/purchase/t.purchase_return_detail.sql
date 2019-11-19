DROP TABLE IF EXISTS `purchase_return_detail`;

CREATE TABLE `purchase_return_detail` (
	`id` BIGINT NOT NULL AUTO_INCREMENT,
	`sheet_id` VARCHAR(45) NOT NULL COMMENT '单据号',
	`item_id` VARCHAR(45) NOT NULL COMMENT '商品编码',
	`item_barcode` VARCHAR(45) NOT NULL COMMENT '商品条码',
	`item_name` VARCHAR(45) NOT NULL COMMENT '商品名称',
	`size` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '规格',
	`purchase_unit` VARCHAR(45) NOT NULL COMMENT '采购单位',
	`qty` DECIMAL NOT NULL COMMENT '数量',
	`price` DECIMAL NOT NULL COMMENT '单价',
	`amount` DECIMAL NOT NULL COMMENT '金额',
	`tax_rate` DECIMAL NOT NULL COMMENT '税率',
	`tax_amount` DECIMAL NOT NULL COMMENT '税额',
	`refer_stock_qty` DECIMAL NOT NULL COMMENT '库存数量',
	`stock_qty` DECIMAL NOT NULL COMMENT '基本数量',
	`stock_unit` VARCHAR(45) NOT NULL COMMENT '库存单位',
	`memo` VARCHAR(100) NOT NULL DEFAULT '' COMMENT '备注',
	PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '采购退货商品明细';