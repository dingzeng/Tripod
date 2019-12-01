DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `id` BIGINT NOT NULL AUTO_INCREMENT COMMENT '自增编码',
  `branch_id` VARCHAR(8) NOT NULL COMMENT '所属机构编码',
  `branch_name` VARCHAR(45) NOT NULL COMMENT '所属机构名称',
  `username` VARCHAR(45) NOT NULL COMMENT '用户名',
  `password` VARCHAR(45) NOT NULL COMMENT '登录密码',
  `name` VARCHAR(45) NOT NULL COMMENT '姓名',
  `mobile` VARCHAR(45) NOT NULL COMMENT '手机号',
  `status` TINYINT NOT NULL DEFAULT 1 COMMENT '状态 0-禁用、1-启用',
  `item_department_permission_flag` TINYINT NOT NULL DEFAULT 0 COMMENT '商品部门权限标记 0-授权全部、1-指定授权',
  `supplier_permission_flag` TINYINT NOT NULL DEFAULT 0 COMMENT '供应商权限标记 0-授权全部、1-指定授权',
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

INSERT INTO `user`(branch_id,branch_name,username,`password`,`name`,mobile,`status`,item_department_permission_flag,supplier_permission_flag) 
values('00','总部','admin','123456','管理员','15812345678',1,0,0);