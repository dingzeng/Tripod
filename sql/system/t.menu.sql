DROP TABLE IF EXISTS `menu`;

CREATE TABLE `menu` (
  `code` VARCHAR(45) NOT NULL COMMENT '编码',
  `parent_code` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '父级编码',
  `path` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '菜单路径',
  `name` VARCHAR(45) NOT NULL COMMENT '菜单名称',
  `icon` VARCHAR(45) NOT NULL DEFAULT '' COMMENT '图标',
  `is_leaf` TINYINT NOT NULL COMMENT '是否是叶子节点',
  PRIMARY KEY (`code`))
ENGINE = InnoDB;

-- 基础档案
INSERT INTO `menu`(code,`name`,`icon`,is_leaf) VALUES('01','基础档案','el-icon-document', 0);
INSERT INTO `menu`(code,parent_code,`name`,is_leaf) VALUES('0101','01','机构档案', 0);
INSERT INTO `menu`(code,parent_code,`path`,`name`,is_leaf) VALUES('010101','0101','/archive/branchGroup','机构组', 1);
INSERT INTO `menu`(code,parent_code,`path`,`name`,is_leaf) VALUES('010102','0101','/archive/branch','机构', 1);
INSERT INTO `menu`(code,parent_code,`name`,is_leaf) VALUES('0102','01','供应商档案', 0);
INSERT INTO `menu`(code,parent_code,`path`,`name`,is_leaf) VALUES('010201','0102','/archive/supplierRegion','供应商区域', 1);
INSERT INTO `menu`(code,parent_code,`path`,`name`,is_leaf) VALUES('010202','0102','/archive/supplier','供应商', 1);
INSERT INTO `menu`(code,parent_code,`name`,is_leaf) VALUES('0103','01','商品档案', 0);
INSERT INTO `menu`(code,parent_code,`path`,`name`,is_leaf) VALUES('010301','0103','/archive/itemCls','商品类别', 1);
INSERT INTO `menu`(code,parent_code,`path`,`name`,is_leaf) VALUES('010302','0103','/archive/itemBrand','商品品牌', 1);
INSERT INTO `menu`(code,parent_code,`path`,`name`,is_leaf) VALUES('010303','0103','/archive/itemDepartment','商品部门', 1);
INSERT INTO `menu`(code,parent_code,`path`,`name`,is_leaf) VALUES('010304','0103','/archive/itemUnit','商品单位', 1);
INSERT INTO `menu`(code,parent_code,`path`,`name`,is_leaf) VALUES('010305','0103','/archive/item','商品', 1);

INSERT INTO `menu`(code,`name`,`icon`,is_leaf) VALUES('02','采购业务','el-icon-s-order', 0);
INSERT INTO `menu`(code,`name`,`icon`,is_leaf) VALUES('03','零售业务','el-icon-s-shop', 0);
INSERT INTO `menu`(code,`name`,`icon`,is_leaf) VALUES('04','批发业务','el-icon-s-custom', 0);
INSERT INTO `menu`(code,`name`,`icon`,is_leaf) VALUES('08','财务管理','el-icon-s-finance', 0);

-- 系统管理
INSERT INTO `menu`(code,`name`,`icon`,is_leaf) VALUES('09','系统管理','el-icon-setting', 0);
INSERT INTO `menu`(code,parent_code,`name`,is_leaf) VALUES('0901','09','用户管理', 0);
INSERT INTO `menu`(code,parent_code,`path`,`name`,is_leaf) VALUES('090101','0901','/system/role','角色管理', 1);
INSERT INTO `menu`(code,parent_code,`path`,`name`,is_leaf) VALUES('090102','0901','/system/user','用户管理', 1);
