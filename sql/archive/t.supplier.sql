DROP TABLE IF EXISTS `supplier`;

CREATE TABLE `supplier` (
    `id` VARCHAR(45) NOT NULL COMMENT '供应商编码',
    `name` VARCHAR(45) NOT NULL COMMENT '供应商名称',
    `region_id` VARCHAR(45) NOT NULL COMMENT '所属区域id',
    `sell_way` INT NOT NULL DEFAULT 0 COMMENT '经营方式（0-购销、1-联营、2-代销、3-租赁）',
    `settle_way` INT NOT NULL DEFAULT 0 COMMENT '结算方式（0-临时指定、1-货到付款、2-指定账期、3-指定日期）',
    `settle_days` INT NULL COMMENT '结算周期天数',
    `settle_date` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '结算日期',
    `status` INT NOT NULL DEFAULT 0 COMMENT '状态（0-正常、9-停用）',
    `contacts_name` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '联系人',
    `contacts_mobile` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '移动电话',
    `contacts_tel` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '固定电话',
    `contacts_email` VARCHAR(45) NOT NULL DEFAULT '' COMMENT 'Email',
    `account_bank` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '开户行',
    `account_no` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '账号',
    `tax_registration_no` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '税务登记号',
    `business_license_no` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '营业执照号',
    `memo` VARCHAR(100) NOT NULL DEFAULT '' COMMENT '备注',
    `create_oper_id` BIGINT NOT NULL COMMENT '创建人',
	`create_oper_name` VARCHAR(45) NOT NULL,
	`create_time` DATETIME NOT NULL COMMENT '创建时间',
    `last_update_oper_id` BIGINT NOT NULL COMMENT '最后修改人',
	`last_update_oper_name` VARCHAR(45) NOT NULL,
	`last_update_time` DATETIME NOT NULL COMMENT '最后修改时间',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '供应商';
