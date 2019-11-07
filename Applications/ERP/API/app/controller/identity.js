'use strict';

const Controller = require('egg').Controller;

class IdentityController extends Controller {
  async login() {
    const model = this.ctx.request.body;
    const user = this.service.system.getUserByUsername(model.Username);
    this.ctx.body = user;
  }

  async logout() {
      
  }
}

module.exports = IdentityController;
