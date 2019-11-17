'use strict';

const protoFilePath = __dirname + '/../../../../../Services/protos/archive.proto';
const packageName = 'Archive';
const serviceName = 'BranchSrv';
const address = '127.0.0.1:80051';
const client = require('../grpcLoader')(protoFilePath, packageName, serviceName, address);

const Service = require('egg').Service;

class BranchService extends Service {
  async getBranchGroups() {
    return new Promise(function(resolve, reject){
      client.GetBranchGroups({}, function(error, feature){
        if(error){
          reject(error)
        }else{
          resolve(feature)
        }
      });
    })
  }

  async getBranchGroup(id) {
    return new Promise(function(resolve, reject){
      client.GetBranchGroup({ Body: id }, function(error, feature){
        if(error){
          reject(error)
        }else{
          resolve(feature)
        }
      });
    })
  }

  async createBranchGroup(branchGroup) {
    return new Promise(function(resolve, reject){
      client.CreateBranchGroup(branchGroup, function(error, feature){
        if(error){
          reject(error)
        }else{
          resolve(feature)
        }
      });
    })
  }

  async updateBranchGroup(branchGroup) {
    return new Promise(function(resolve, reject){
      client.UpdateBranchGroup(branchGroup, function(error, feature){
        if(error){
          resolve(false)
        }else{
          resolve(feature.Body)
        }
      });
    })
  }

  async deleteBranchGroup(id) {
    return new Promise(function(resolve, reject){
      client.DeleteBranchGroup({ Body: id }, function(error, feature){
        if(error){
          resolve(false)
        }else{
          resolve(feature.Body)
        }
      });
    })
  }

  async getBranchGroupBranchs(branchGroupId) {
    return new Promise(function(resolve, reject){
      client.GetBranchGroupBranchs({ Body: branchGroupId }, function(error, feature){
        if(error){
          reject(error)
        }else{
          resolve(feature)
        }
      });
    })
  }

  async deleteBranchGroupBranchs(branchGroupId, branchIdList) {
    return new Promise(function(resolve, reject){
      client.DeleteBranchGroupBranchs({ BranchGroupId: branchGroupId, BranchIdList: branchIdList }, function(error, feature){
        if(error){
          resolve(false)
        }else{
          resolve(feature.Body)
        }
      });
    })
  }

  async addBranchGroupBranchs(branchGroupId, branchIdList) {
    return new Promise(function(resolve, reject){
      client.AddBranchGroupBranchs({ BranchGroupId: branchGroupId, BranchIdList: branchIdList }, function(error, feature){
        if(error){
          resolve(false)
        }else{
          resolve(feature.Body)
        }
      });
    })
  }
}

module.exports = BranchService;
