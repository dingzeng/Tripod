DROP TABLE IF EXISTS `item_batch_stock`;

CREATE TABLE `item_batch_stock` (
    `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '自增编码',
    `item_id` VARCHAR(45) NOT NULL COMMENT '商品编码',
    `batch_id` VARCHAR(45) NOT NULL COMMENT '批次号',
    `barcode` VARCHAR(45) NOT NULL COMMENT '商品条码',
    `branch_id` VARCHAR(45) NOT NULL COMMENT '机构',
    `store_id` VARCHAR(45) NOT NULL COMMENT '仓库',
    `qty` DECIMAL NOT NULL COMMENT '库存数量',
    `cost_price` DECIMAL NOT NULL COMMENT '成本价',
    `cost_amount` DECIMAL NOT NULL COMMENT '成本金额',
    `expire_date` DATETIME NOT NULL COMMENT '过期日期',
    `create_time` DATETIME NOT NULL COMMENT '创建时间',
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '商品批次库存';