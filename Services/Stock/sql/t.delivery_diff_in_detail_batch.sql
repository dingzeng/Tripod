DROP TABLE IF EXISTS `delivery_diff_in_detail_batch`;

CREATE TABLE `delivery_diff_in_detail_batch` (
    `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '自增编码',
    `sheet_id` VARCHAR(45) NOT NULL COMMENT '单据号',
    `detail_id` BIGINT NOT NULL COMMENT '单据明细id',
    `batch_id` VARCHAR(45) NOT NULL COMMENT '批次号',
    `refer_batch_qty` DECIMAL NOT NULL COMMENT '剩余库存数量',
	`qty` DECIMAL NOT NULL COMMENT '数量',
    `expire_date` DATE NOT NULL COMMENT '过期日期'
    PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '配送差异入库单商品批次明细';
