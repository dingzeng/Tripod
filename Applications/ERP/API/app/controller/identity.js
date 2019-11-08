'use strict';

const BaseController = require('./base');

class IdentityController extends BaseController {
  async login() {
    const rules = {
      Username: { type: 'string' },
      Password: { type: 'string' }
    }
    this.ctx.validate(rules);
    const model = this.ctx.request.body;
    const user = await this.service.system.getUserByUsername(model.Username);

    if(!user){
      this.ctx.body = { status: 1, message: '用户名或密码错误' }
    } else {
      this.ctx.body = {
        status: 0,
        menus: []
      };
    }
  }

  async logout() {
      
  }
}

module.exports = IdentityController;
