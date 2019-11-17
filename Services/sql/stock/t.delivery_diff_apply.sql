DROP TABLE IF EXISTS `delivery_diff_apply`;

CREATE TABLE `delivery_diff_apply` (
    `sheet_id` VARCHAR(45) NOT NULL COMMENT '单据号',
    `ref_sheet_id` VARCHAR(45) NOT NULL COMMENT '引用配送出库单号',
    `branch_id` VARCHAR(45) NOT NULL COMMENT '申请机构',
    `store_id` VARCHAR(45) NOT NULL COMMENT '出库仓库',
    `diff_reason` VARCHAR(45) NOT NULL COMMENT '差异原因',
	`total_amount` DECIMAL NOT NULL COMMENT '单据金额',
	`approve_status` INT NOT NULL DEFAULT 0 COMMENT '审核状态（0-草稿、1-为审核、2-审核通过、3-已驳回）',
	`create_oper_id` INT NOT NULL COMMENT '制单人',
	`create_oper_name` VARCHAR(45) NOT NULL,
	`create_time` DATETIME NOT NULL COMMENT '制单时间',
	`approve_oper_id` INT NOT NULL COMMENT '审核人',
	`approve_oper_name` VARCHAR(45) NOT NULL,
	`approve_time` DATETIME NOT NULL COMMENT '审核时间',
	`memo` VARCHAR(100) NOT NULL DEFAULT ('') COMMENT '备注',
    PRIMARY KEY (`sheet_id`))
ENGINE = InnoDB
COMMENT = '配送差异申请单';
