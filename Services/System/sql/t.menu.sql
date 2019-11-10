DROP TABLE IF EXISTS `menu`;

CREATE TABLE `menu` (
  `code` VARCHAR(45) NOT NULL,
  `parent_code` VARCHAR(45) NOT NULL DEFAULT '',
  `path` VARCHAR(45) NOT NULL DEFAULT '',
  `name` VARCHAR(45) NOT NULL,
  `is_leaf` TINYINT NOT NULL,
  PRIMARY KEY (`code`))
ENGINE = InnoDB;

INSERT INTO `menu`(code,`name`,is_leaf) VALUES('01','基础档案', 0);
INSERT INTO `menu`(code,`name`,is_leaf) VALUES('02','采购业务', 0);
INSERT INTO `menu`(code,`name`,is_leaf) VALUES('03','零售业务', 0);
INSERT INTO `menu`(code,`name`,is_leaf) VALUES('04','批发业务', 0);
INSERT INTO `menu`(code,`name`,is_leaf) VALUES('08','财务管理', 0);

-- 系统管理
INSERT INTO `menu`(code,`name`,is_leaf) VALUES('09','系统管理', 0);
INSERT INTO `menu`(code,parent_code,`name`,is_leaf) VALUES('0901','09','用户管理', 0);
INSERT INTO `menu`(code,parent_code,`path`,`name`,is_leaf) VALUES('090101','0901','/system/role','角色管理', 1);
INSERT INTO `menu`(code,parent_code,`path`,`name`,is_leaf) VALUES('090102','0901','/system/user','用户管理', 1);
