DROP TABLE IF EXISTS `branch`;

CREATE TABLE `branch` (
    `id` VARCHAR(45) NOT NULL COMMENT '机构编码',
    `parent_id` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '上级机构编码',
    `name` VARCHAR(45) NOT NULL COMMENT '机构名称',
    `short_name` VARCHAR(45) NOT NULL COMMENT '机构简称',
    `type` INT NOT NULL COMMENT '机构类型（0-总部、1-区域中心、2-配送中心、3-自营店、4-加盟店）',
    `contacts_name` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '联系人',
    `contacts_mobile` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '移动电话',
    `contacts_tel` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '固定电话',
    `contacts_email` VARCHAR(45) NOT NULL DEFAULT '' COMMENT 'Email',
    `address` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '地址',
    `gift_store_id` INT NULL COMMENT '默认赠送仓库',
    `return_store_id` INT NULL COMMENT '默认退货仓库',
    `purchase_store_id` INT NULL COMMENT '默认进货仓库',
    `memo` VARCHAR(100) NOT NULL DEFAULT '' COMMENT '备注',
    `create_oper_id` INT NOT NULL COMMENT '创建人',
	`create_oper_name` VARCHAR(45) NOT NULL,
	`create_time` DATETIME NOT NULL COMMENT '创建时间',
    `last_update_oper_id` INT NOT NULL COMMENT '最后修改人',
	`last_update_oper_name` VARCHAR(45) NOT NULL,
	`last_update_time` DATETIME NOT NULL COMMENT '最后修改时间',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '机构';

INSERT INTO `db_tripod_archive`.`branch` (`id`, `parent_id`, `name`, `short_name`, `type`, `contacts_name`, `contacts_mobile`, `contacts_tel`, `contacts_email`, `address`, `gift_store_id`, `return_store_id`, `purchase_store_id`, `create_oper_id`, `create_oper_name`, `create_time`, `last_update_oper_id`, `last_update_oper_name`, `last_update_time`) 
VALUES ('00', '', '总部', '总部', '0', '曾鼎', '15874564512', '0712-8820550', '66666@qq.com', '湖北省汉川市韩集乡金光村', '1', '1', '1', '9001', '9001', '2019-12-02 14:57:26', '9001', '9001', '2019-12-02 14:57:35');

