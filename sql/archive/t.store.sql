DROP TABLE IF EXISTS `store`;

CREATE TABLE `store` (
    `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '自增编码',
    `branch_id` VARCHAR(45) NOT NULL COMMENT '所属机构编码',
    `name` VARCHAR(45) NOT NULL COMMENT '仓库名称',
    `is_usable` TINYINT NOT NULL DEFAULT 1 COMMENT '是否可用',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '仓库';
