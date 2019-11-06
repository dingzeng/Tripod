'use strict';

const Controller = require('egg').Controller;

class UserController extends Controller {
  async getUserByUsername() {
    this.ctx.body = await this.service.users.getUserByUsername('admin')
  }
}

module.exports = UserController;
