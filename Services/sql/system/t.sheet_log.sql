DROP TABLE IF EXISTS `sheet_log`;

CREATE TABLE `sheet_log` (
    `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '子增长编码',
    `sheet_type` CHAR(2) NOT NULL COMMENT '单据类型',
    `sheet_id` VARCHAR(45) NOT NULL COMMENT '单据编号',
    `action` VARCHAR(45) NOT NULL COMMENT '操作 create、commit、approve、reject、cancel',
    `oper_name` VARCHAR(45) NOT NULL COMMENT '操作人',
    `create_time` DATETIME NOT NULL COMMENT '操作时间',
    PRIMARY KEY (`id`))
ENGINE = InnoDB;
