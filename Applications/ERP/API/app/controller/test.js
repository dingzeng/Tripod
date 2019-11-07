'use strict';

const Controller = require('egg').Controller;

class TestController extends Controller {
  async test() {
    this.ctx.body = await this.service.system.getUserByUsername('admin');
  }
}

module.exports = TestController;
