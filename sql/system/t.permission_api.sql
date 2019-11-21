DROP TABLE IF EXISTS `permission_api`;

CREATE TABLE `permission_api` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `permission_code` VARCHAR(45) NOT NULL COMMENT '所属权限',
  `url` VARCHAR(45) NOT NULL COMMENT 'URL',
  `method` VARCHAR(45) NOT NULL COMMENT 'HTTP请求方式：GET、POST、PUT、DELETE',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '权限对应接口';

-- Role
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('ROLE_VIEW','/system/roles','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('ROLE_VIEW','/system/role/?','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('ROLE_VIEW','/system/role/?/permissions','GET');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('ROLE_CREATE','/system/role','POST');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('ROLE_UPDATE','/system/role','PUT');
INSERT INTO `permission_api`(permission_code,`url`,method) VALUES('ROLE_UPDATE','system/role/?/permissions','PUT');
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

