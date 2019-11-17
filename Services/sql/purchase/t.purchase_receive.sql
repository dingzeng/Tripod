DROP TABLE IF EXISTS `purchase_receive`;

CREATE TABLE `purchase_receive` (
	`sheet_id` VARCHAR(45) NOT NULL COMMENT '单据号',
	`ref_sheet_id` VARCHAR(45) NOT NULL COMMENT '引用采购订单单据号',
	`approve_status` INT NOT NULL DEFAULT 0 COMMENT '审核状态（0-草稿、1-为审核、2-审核通过、3-已驳回）',
	`settle_status` INT NOT NULL DEFAULT 0 COMMENT '结算状态（0-未结算、1-已结算）',
	`supplier_id` VARCHAR(45) NOT NULL COMMENT '供应商',
	`receive_branch` VARCHAR(45) NOT NULL COMMENT '收货机构',
	`receive_store_id` VARCHAR(45) NOT NULL COMMENT '收货仓库',
	`total_amount` DECIMAL NOT NULL COMMENT '订货金额',
	`purchase_oper` VARCHAR(45) NOT NULL COMMENT '采购员',
	`receive_time` DATETIME NOT NULL COMMENT '收货时间',
	`create_oper` VARCHAR(45) NOT NULL COMMENT '制单人',
	`create_time` DATETIME NOT NULL COMMENT '制单时间',
	`approve_oper` VARCHAR(45) NOT NULL COMMENT '审核人',
	`approve_time` DATETIME NOT NULL COMMENT '审核时间',
	`memo` VARCHAR(100) NOT NULL DEFAULT ('') COMMENT '备注',
  	PRIMARY KEY (`sheet_id`))
ENGINE = InnoDB
COMMENT = '采购收货单';
