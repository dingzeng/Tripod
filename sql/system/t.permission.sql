DROP TABLE IF EXISTS `permission`;

CREATE TABLE `permission` (
  `code` VARCHAR(45) NOT NULL,
  `menu_code` VARCHAR(45) NOT NULL COMMENT '所属菜单',
  `type` TINYINT NOT NULL COMMENT '权限类型 0-查看、1-新增、2-修改、3-删除、4-审核、9-其它',
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`code`))
ENGINE = InnoDB
COMMENT = '操作权限';

-- BranchGroup
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('BRANCH_GROUP_VIEW','010101',0,'查看机构组');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('BRANCH_GROUP_CREATE','010101',1,'新增机构组');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('BRANCH_GROUP_UPDATE','010101',2,'修改机构组');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('BRANCH_GROUP_DELETE','010101',3,'删除机构组');

-- Branch
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('BRANCH_VIEW','010102',0,'查看机构');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('BRANCH_CREATE','010102',1,'新增机构');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('BRANCH_UPDATE','010102',2,'修改机构');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('BRANCH_DELETE','010102',3,'删除机构');

-- SupplierRegion
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('SUPPLIER_REGION_VIEW','010201',0,'查看供应商区域');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('SUPPLIER_REGION_CREATE','010201',1,'新增供应商区域');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('SUPPLIER_REGION_UPDATE','010201',2,'修改供应商区域');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('SUPPLIER_REGION_DELETE','010201',3,'删除供应商区域');

-- Supplier
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('SUPPLIER_VIEW','010202',0,'查看供应商');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('SUPPLIER_CREATE','010202',1,'新增供应商');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('SUPPLIER_UPDATE','010202',2,'修改供应商');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('SUPPLIER_DELETE','010202',3,'删除供应商');

-- Role
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('ROLE_VIEW','090101',0,'查看角色');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('ROLE_CREATE','090101',1,'新增角色');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('ROLE_UPDATE','090101',2,'修改角色');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('ROLE_DELETE','090101',3,'删除角色');

-- User
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('USER_VIEW','090102',0,'查看用户');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('USER_CREATE','090102',1,'新增用户');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('USER_UPDATE','090102',2,'修改用户');
INSERT INTO `permission`(`code`,menu_code,`type`,`name`) VALUES('USER_DELETE','090102',3,'删除用户');
