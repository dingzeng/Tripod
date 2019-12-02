DROP TABLE IF EXISTS `role_permission`;

CREATE TABLE `role_permission` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `role_id` INT NOT NULL,
  `permission_code` VARCHAR(45)  NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'BRANCH_GROUP_VIEW');
INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'BRANCH_GROUP_CREATE');
INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'BRANCH_GROUP_UPDATE');
INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'BRANCH_GROUP_DELETE');

INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'BRANCH_VIEW');
INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'BRANCH_CREATE');
INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'BRANCH_UPDATE');
INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'BRANCH_DELETE');

INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'ROLE_VIEW');
INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'ROLE_CREATE');
INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'ROLE_UPDATE');
INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'ROLE_DELETE');

INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'USER_VIEW');
INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'USER_CREATE');
INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'USER_UPDATE');
INSERT INTO `role_permission`(role_id,permission_code) VALUES(3,'USER_DELETE');