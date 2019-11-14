DROP TABLE IF EXISTS `item_delivery_price`;

CREATE TABLE `item_delivery_price` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `item_id` VARCHAR(45) NOT NULL COMMENT '商品编码',
    `branch_id` VARCHAR(45) NOT NULL COMMENT '机构',
    `delivery_price` DECIMAL NOT NULL DEFAULT(0) COMMENT '配送价',
    `memo` VARCHAR(100) NULL COMMENT '备注',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '商品配送价';
