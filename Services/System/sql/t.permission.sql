CREATE TABLE IF NOT EXISTS `permission` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `menu_id` INT NOT NULL COMMENT '所属菜单',
  `type` TINYINT NOT NULL COMMENT '权限类型 0-查看、1-新增、2-编辑、3-删除、4-审核、9-其它',
  `name` VARCHAR(45) NOT NULL,
  `url` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '操作权限';