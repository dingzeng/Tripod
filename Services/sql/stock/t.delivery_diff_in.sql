DROP TABLE IF EXISTS `delivery_diff_in`;

CREATE TABLE `delivery_diff_in` (
    `sheet_id` VARCHAR(45) NOT NULL COMMENT '单据号',
    `ref_delivery_sheet_id` VARCHAR(45) NULL COMMENT '引用配送单号',
    `ref_delivery_diff_apply_sheet_id` VARCHAR(45) NULL COMMENT '引用配送差异申请单',
    `branch_id` VARCHAR(45) NOT NULL COMMENT '入库机构',
    `store_id` VARCHAR(45) NOT NULL COMMENT '入库仓库',
	`total_amount` DECIMAL NOT NULL COMMENT '单据金额',
	`approve_status` INT NOT NULL DEFAULT 0 COMMENT '审核状态（0-草稿、1-为审核、2-审核通过、3-已驳回）',
	`create_oper` VARCHAR(45) NOT NULL COMMENT '制单人',
	`create_time` DATETIME NOT NULL COMMENT '制单时间',
	`approve_oper` VARCHAR(45) NOT NULL COMMENT '审核人',
	`approve_time` DATETIME NOT NULL COMMENT '审核时间',
	`memo` VARCHAR(100) NULL COMMENT '备注',
    PRIMARY KEY (`sheet_id`))
ENGINE = InnoDB
COMMENT = '配送差异入库单';
