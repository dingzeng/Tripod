'use strict';

const Controller = require('egg').Controller;

class BranchGroupController extends Controller {
    async getBranchGroups() {
        this.ctx.body = await this.service.branch.getBranchGroups();
    }
    async getBranchGroup() {
        this.ctx.body = 'getBranchGroup'
    }
    async createBranchGroup() {
        this.ctx.body = 'createBranchGroup'
    }
    async updateBranchGroup() {
        this.ctx.body = 'updateBranchGroup'
    }
    async deleteBranchGroup() {
        this.ctx.body = 'deleteBranchGroup'
    }
    async getBranchGroupBranchs() {
        this.ctx.body = 'getBranchGroupBranchs'
    }
    async deleteBranchGroupBranchs() {
        this.ctx.body = 'deleteBranchGroupBranchs'
    }
    async addBranchGroupBranchs() {
        this.ctx.body = 'addBranchGroupBranchs'
    }
}

module.exports = BranchGroupController;
