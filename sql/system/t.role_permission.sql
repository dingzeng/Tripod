DROP TABLE IF EXISTS `role_permission`;

CREATE TABLE `role_permission` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `role_id` INT NOT NULL,
  `permission_code` VARCHAR(45)  NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

/* 为角色1分配所有操作权限 */
INSERT INTO role_permission(role_id, permission_code) SELECT 1, `code` FROM permission;