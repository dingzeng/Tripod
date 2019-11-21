DROP TABLE IF EXISTS `branch_group_branch`;

CREATE TABLE `branch_group_branch` (
    `id` INT NOT NULL AUTO_INCREMENT COMMENT '自增编码',
    `branch_group_id` INT NOT NULL COMMENT '机构组id',
    `branch_id` VARCHAR(45) NOT NULL COMMENT '机构编码',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '机构组机构关系';
