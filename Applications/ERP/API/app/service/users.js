'use strict';

const PROTO_PATH = __dirname + '/../../../../../Services/System/src/Tripod.Service.System/Protos/users.proto';
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

const Service = require('egg').Service;

class UsersService extends Service {
  async getUserByUsername() {

    var users = grpc.loadPackageDefinition(packageDefinition).Users;
    var client = new users.Users('192.168.215.31:5002', grpc.credentials.createInsecure());
    
    return client.GetUserByUsername({
      Username: '123'
    }, function(error, feature){
      console.log(error, feature)
    });
  }
}

module.exports = UsersService;
