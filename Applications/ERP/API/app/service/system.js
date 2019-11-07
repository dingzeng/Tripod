'use strict';

const PROTO_PATH = __dirname + '/../../../../../Services/System/protos/service.proto';
var grpc = require('grpc');
var protoLoader = require('@grpc/proto-loader');
var packageDefinition = protoLoader.loadSync(
    PROTO_PATH,
    {
        keepCase: true,
        longs: String,
        enums: String,
        defaults: true,
        oneofs: true
    });

var System = grpc.loadPackageDefinition(packageDefinition).System;
var client = new System.SystemSrv('127.0.0.1:50051', grpc.credentials.createInsecure());    

const Service = require('egg').Service;

class SystemService extends Service {
  async getUserByUsername(username) {
    return new Promise(function(resolve, reject){
      client.GetUserByUsername({
        Username: username
      }, function(error, feature){
        if(error){
          reject(error)
        }else{
          resolve(feature)
        }
      });
    })
  }
}

module.exports = SystemService;
