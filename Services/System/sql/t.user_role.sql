CREATE TABLE IF NOT EXISTS `user_role` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `user_id` INT NOT NULL,
  `role_id` INT NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;
