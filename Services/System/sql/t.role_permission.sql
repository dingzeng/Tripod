CREATE TABLE IF NOT EXISTS `role_permission` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `role_id` INT NOT NULL,
  `permission_id` INT NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;