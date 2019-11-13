DROP TABLE IF EXISTS `purchase_order_branch`;

CREATE TABLE `purchase_order_branch` (
	`id` BIGINT NOT NULL AUTO_INCREMENT,
	`sheet_id` VARCHAR(45) NOT NULL COMMENT '单据号',
	`branch_id` VARCHAR(45) NOT NULL COMMENT '机构',
	PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '采购订单收货机构';