DROP TABLE IF EXISTS `item_cls`;

CREATE TABLE `item_cls` (
    `id` VARCHAR(45) NOT NULL COMMENT '编码',
    `parent_id` VARCHAR(45) NULL COMMENT '上级类别编码',
    `name` VARCHAR(45) NOT NULL COMMENT '名称',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '商品类别';
