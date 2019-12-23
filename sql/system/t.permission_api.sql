DROP TABLE IF EXISTS `permission_api`;

CREATE TABLE `permission_api` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `permission_code` VARCHAR(45) NOT NULL COMMENT '所属权限',
  `url` VARCHAR(45) NOT NULL COMMENT 'URL',
  `method` VARCHAR(45) NOT NULL COMMENT 'HTTP请求方式：GET、POST、PUT、DELETE',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '权限对应接口';

-- BranchGroup
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('BRANCH_GROUP_VIEW','/archive/branchGroups','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('BRANCH_GROUP_VIEW','/archive/branchGroup/?','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('BRANCH_GROUP_CREATE','/archive/branchGroup','POST');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('BRANCH_GROUP_UPDATE','/archive/branchGroup','PUT');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('BRANCH_GROUP_DELETE','/archive/branchGroup','DELETE');

-- Branch
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('BRANCH_VIEW','/archive/branchs','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('BRANCH_VIEW','/archive/branch/?','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('BRANCH_CREATE','/archive/branch','POST');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('BRANCH_UPDATE','/archive/branch','PUT');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('BRANCH_DELETE','/archive/branch','DELETE');

-- SupplierRegion
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('SUPPLIER_REGION_VIEW','/archive/supplierRegion','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('SUPPLIER_REGION_VIEW','/archive/supplierRegion/?','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('SUPPLIER_REGION_CREATE','/archive/supplierRegion','POST');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('SUPPLIER_REGION_UPDATE','/archive/supplierRegion','PUT');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('SUPPLIER_REGION_DELETE','/archive/supplierRegion','DELETE');

-- Supplier
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('SUPPLIER_VIEW','/archive/supplier','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('SUPPLIER_VIEW','/archive/supplier/?','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('SUPPLIER_CREATE','/archive/supplier','POST');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('SUPPLIER_UPDATE','/archive/supplier','PUT');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('SUPPLIER_DELETE','/archive/supplier','DELETE');

-- Role
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('ROLE_VIEW','/system/roles','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('ROLE_VIEW','/system/role/?','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('ROLE_VIEW','/system/role/?/permissions','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('ROLE_CREATE','/system/role','POST');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('ROLE_UPDATE','/system/role','PUT');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('ROLE_UPDATE','/system/role/?/permissions','PUT');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('ROLE_DELETE','/system/role','DELETE');

-- User
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('USER_VIEW','/system/users','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('USER_VIEW','/system/user/?','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('USER_CREATE','/system/user','POST');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('USER_UPDATE','/system/user/info','PUT');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('USER_UPDATE','/system/user/permission','PUT');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('USER_UPDATE','/system/user/roles','PUT');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('USER_UPDATE','/system/user/password','PUT');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('USER_DELETE','/system/user/?','DELETE');

