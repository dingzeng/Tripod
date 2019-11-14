DROP TABLE IF EXISTS `branch_group`;

CREATE TABLE `branch_group` (
    `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '自增编码',
    `name` VARCHAR(45) NOT NULL COMMENT '名称',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '店组';
