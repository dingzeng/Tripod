'use strict';

const PROTO_PATH = __dirname + '/../../../../../Services/System/protos/users.proto';
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

var Users = grpc.loadPackageDefinition(packageDefinition).Users;
var client = new Users.Users('127.0.0.1:50051', grpc.credentials.createInsecure());    

const Service = require('egg').Service;

class UsersService extends Service {
  async getUserByUsername() {
    return new Promise(function(resolve, reject){
      client.GetUserByUsername({
        Username: '123'
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

module.exports = UsersService;
