DROP TABLE IF EXISTS `purchase_order_detail_branch`;

CREATE TABLE `purchase_order_detail_branch` (
	`id` BIGINT NOT NULL AUTO_INCREMENT,
	`sheet_id` VARCHAR(45) NOT NULL COMMENT '单据号',
	`detail_id` VARCHAR(45) NOT NULL COMMENT '明细id',
	`branch_id` VARCHAR(45) NOT NULL COMMENT '机构',
	`refer_stock_qty` DECIMAL NOT NULL COMMENT '库存数量',
	`qty` DECIMAL NOT NULL COMMENT '数量',
	`memo` VARCHAR(45) NOT NULL COMMENT '备注',
	PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '采购订单分配明细';