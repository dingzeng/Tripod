'use strict';

const BaseController = require('./base');

class TestController extends BaseController {
  async test() {
    this.ctx.body = await this.service.system.getUserByUsername('admin');
  }
}

module.exports = TestController;
