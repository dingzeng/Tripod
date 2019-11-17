DROP TABLE IF EXISTS `purchase_order`;

CREATE TABLE `purchase_order` (
	`sheet_id` VARCHAR(45) NOT NULL COMMENT '单据号',
	`type` INT NOT NULL COMMENT '单据类型（0-采购订单、1-直配订单、2-越库订单、3-永续订单）',
	`receive_status` INT NOT NULL DEFAULT 0 COMMENT '收货状态（0-未收货、1-部分收货、2-已收货）',
	`approve_status` INT NOT NULL DEFAULT 0 COMMENT '审核状态（0-草稿、1-为审核、2-审核通过、3-已驳回）',
	`supplier_id` VARCHAR(45) NOT NULL COMMENT '供应商',
	`order_branch_id` VARCHAR(45) NOT NULL COMMENT '订货机构',
	`receive_expire_date` DATE NOT NULL COMMENT '收货期限',
	`total_amount` DECIMAL NOT NULL COMMENT '订货金额',
	`purchase_oper` VARCHAR(45) NOT NULL COMMENT '采购员',
	`create_oper` VARCHAR(45) NOT NULL COMMENT '制单人',
	`create_time` DATETIME NOT NULL COMMENT '制单时间',
	`approve_oper` VARCHAR(45) NOT NULL COMMENT '审核人',
	`approve_time` DATETIME NOT NULL COMMENT '审核时间',
	`memo` VARCHAR(100) NOT NULL DEFAULT ('') COMMENT '备注',
  	PRIMARY KEY (`sheet_id`))
ENGINE = InnoDB
COMMENT = '采购订单';
