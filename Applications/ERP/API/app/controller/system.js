'use strict';

const BaseController = require('./base');

class SystemController extends BaseController {
    async getMenus() {
        
    }

    async getAllRoles() {
        const roles = await this.service.system.getAllRoles()
        this.ctx.body = roles
    }
  
    async getRole() {
      
    }
  
    async createRole() {
      
    }
  
    async updateRole() {
      
    }
  
    async deleteRole() {
      
    }
  
    async getRolePermissions() {
      
    }
  
    async updateRolePermissions() {
      
    }

    async getUsers() {
    
    }
  
    async getUser() {
      
    }
  
    async createUser() {
      
    }
  
    async updateUserInfo() {
      
    }
  
    async updateUserPermission() {
      
    }
  
    async updateUserRoles() {
      
    }
  
    async updateUserPassword() {
      
    }

    async deleteUser() {
        
    }
}

module.exports = SystemController;
