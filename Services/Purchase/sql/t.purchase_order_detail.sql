DROP TABLE IF EXISTS `purchase_order_detail`;

CREATE TABLE `purchase_order_detail` (
	`id` BIGINT NOT NULL AUTO_INCREMENT,
	`sheet_id` VARCHAR(45) NOT NULL COMMENT '单据号',
	`item_id` VARCHAR(45) NOT NULL COMMENT '商品编码',
	`item_barcode` VARCHAR(45) NOT NULL COMMENT '商品条码',
	`item_name` VARCHAR(45) NOT NULL COMMENT '商品名称',
	`gift_flag` TINYINT NOT NULL DEFAULT 0 COMMENT '赠品标志',
	`size` VARCHAR(45) NULL COMMENT '规格',
	`purchase_unit` VARCHAR(45) NOT NULL COMMENT '采购单位',
	`refer_purchase_price` DECIMAL NOT NULL COMMENT '参考进价'
	`qty` DECIMAL NOT NULL COMMENT '数量',
	`purchase_price` DECIMAL NOT NULL COMMENT '进价',
	`amount` DECIMAL NOT NULL COMMENT '金额',
	`tax_rate` DECIMAL NOT NULL COMMENT '税率',
	`tax_amount` DECIMAL NOT NULL COMMENT '税额',
	`refer_stock_qty` DECIMAL NOT NULL COMMENT '库存数量',
	`stock_qty` DECIMAL NOT NULL COMMENT '基本数量',
	`stock_unit` VARCHAR(45) NOT NULL COMMENT '库存单位',
	`retail_price` DECIMAL NOT NULL COMMENT '零售价',
	`received_qty` DECIMAL NOT NULL COMMENT '到货数量',
	`memo` VARCHAR(100) NULL COMMENT '备注',
	PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '采购订单商品明细';
