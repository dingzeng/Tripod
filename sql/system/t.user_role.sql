DROP TABLE IF EXISTS `user_role`;

CREATE TABLE `user_role` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `user_id` INT NOT NULL,
  `role_id` INT NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

INSERT INTO user_role(user_id,role_id) VALUES(1,3);