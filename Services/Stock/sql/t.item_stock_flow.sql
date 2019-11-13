DROP TABLE IF EXISTS `item_stock_flow`;

CREATE TABLE `item_stock_flow` (
    `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '自增编码',
    `item_id` VARCHAR(45) NOT NULL COMMENT '商品编码',
    `sheet_id` VARCHAR(45) NOT NULL COMMENT '单据号',
    `barcode` VARCHAR(45) NOT NULL COMMENT '商品条码',
    `branch_id` VARCHAR(45) NOT NULL COMMENT '机构',
    `qty` DECIMAL NOT NULL COMMENT '库存数量',
    `price` DECIMAL NOT NULL COMMENT '出入库价格',
    `amount` DECIMAL NOT NULL COMMENT '出入库金额',
    `create_time` DATETIME NOT NULL COMMENT '创建时间'
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '商品库存流水';