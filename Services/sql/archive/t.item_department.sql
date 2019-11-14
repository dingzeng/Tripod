DROP TABLE IF EXISTS `item_department`;

CREATE TABLE `item_department` (
    `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '自增编码',
    `name` VARCHAR(45) NOT NULL COMMENT '名称',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '商品部门';
