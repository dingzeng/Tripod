DROP TABLE IF EXISTS `delivery`;

CREATE TABLE `delivery` (
    `sheet_id` VARCHAR(45) NOT NULL COMMENT '单据号',
    `delivery_branch_id` VARCHAR(45) NOT NULL COMMENT '配送中心',
    `store_id` VARCHAR(45) NOT NULL COMMENT '出库仓库',
    `receive_branch_id` VARCHAR(45) NOT NULL COMMENT '收货机构',
	`total_amount` DECIMAL NOT NULL COMMENT '单据金额',
	`receive_status` INT NOT NULL DEFAULT 0 COMMENT '收货状态（0-未收货、1-部分收货、2-已收货）',
	`approve_status` INT NOT NULL DEFAULT 0 COMMENT '审核状态（0-草稿、1-为审核、2-审核通过、3-已驳回）',
	`create_oper` VARCHAR(45) NOT NULL COMMENT '制单人',
	`create_time` DATETIME NOT NULL COMMENT '制单时间',
	`approve_oper` VARCHAR(45) NOT NULL COMMENT '审核人',
	`approve_time` DATETIME NOT NULL COMMENT '审核时间',
	`memo` VARCHAR(100) NULL COMMENT '备注',
    PRIMARY KEY (`sheet_id`))
ENGINE = InnoDB
COMMENT = '配送出库单';
