DROP TABLE IF EXISTS `supplier_region`;

CREATE TABLE `supplier_region` (
    `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '自增编码',
    `name` VARCHAR(45) NOT NULL COMMENT '名称',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '供应商区域';
