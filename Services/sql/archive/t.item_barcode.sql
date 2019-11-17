DROP TABLE IF EXISTS `item_barcode`;

CREATE TABLE `item_barcode` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `item_id` VARCHAR(45) NOT NULL COMMENT '商品编码',
    `barcode` VARCHAR(45) NOT NULL COMMENT '条码',
    `memo` VARCHAR(100) NOT NULL DEFAULT ('') COMMENT '备注',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '商品多条码';
