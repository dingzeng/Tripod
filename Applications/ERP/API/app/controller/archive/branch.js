'use strict';

const BaseController = require('../base');

class BranchController extends BaseController {
    async getBranchs() {
        this.ctx.body = "getBranchs";
    }

    async getBranch() {
        this.ctx.body = "getBranch";
    }

    async createBranch() {
        this.ctx.body = "createBranch";
    }

    async updateBranch() {
        this.ctx.body = "updateBranch";
    }

    async deleteBranch() {
        this.ctx.body = "deleteBranch";
    }

    async getBranchStores() {
        this.ctx.body = "getBranchStores";
    }
    async updateBranchStores() {
        this.ctx.body = "updateBranchStores";
    }
}

module.exports = BranchController;
