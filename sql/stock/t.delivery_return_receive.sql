DROP TABLE IF EXISTS `delivery_return_receive`;

CREATE TABLE `delivery_return_receive` (
    `sheet_id` VARCHAR(45) NOT NULL COMMENT '单据号',
    `ref_delivery_return_sheet_id` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '引用配退单号',
    `branch_id` VARCHAR(45) NOT NULL COMMENT '配退机构',
    `delivery_branch_id` VARCHAR(45) NOT NULL COMMENT '配送中心',
    `store_id` VARCHAR(45) NOT NULL COMMENT '入库仓库',
	`total_amount` DECIMAL NOT NULL COMMENT '单据金额',
	`approve_status` INT NOT NULL DEFAULT 0 COMMENT '审核状态（0-草稿、1-为审核、2-审核通过、3-已驳回）',
	`create_oper_id` INT NOT NULL COMMENT '制单人',
	`create_oper_name` VARCHAR(45) NOT NULL,
	`create_time` DATETIME NOT NULL COMMENT '制单时间',
	`approve_oper_id` INT NOT NULL COMMENT '审核人',
	`approve_oper_name` VARCHAR(45) NOT NULL,
	`approve_time` DATETIME NOT NULL COMMENT '审核时间',
	`memo` VARCHAR(100) NOT NULL DEFAULT '' COMMENT '备注',
    PRIMARY KEY (`sheet_id`))
ENGINE = InnoDB
COMMENT = '配退收货单';