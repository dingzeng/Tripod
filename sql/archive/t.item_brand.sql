DROP TABLE IF EXISTS `item_brand`;

CREATE TABLE `item_brand` (
    `id` VARCHAR(45) NOT NULL COMMENT '编码',
    `name` VARCHAR(45) NOT NULL COMMENT '名称',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '商品品牌';
