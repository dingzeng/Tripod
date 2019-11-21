DROP TABLE IF EXISTS `role`;

CREATE TABLE `role` (
  `id` INT NOT NULL AUTO_INCREMENT COMMENT '自增长编码',
  `name` VARCHAR(45) NOT NULL COMMENT '名称',
  `memo` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '备注',
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

INSERT INTO `role`(`name`,memo) VALUES('部门主管','部门主管');
INSERT INTO `role`(`name`,memo) VALUES('录单员','录单员');
INSERT INTO `role`(`name`,memo) VALUES('系统管理员','系统管理员');