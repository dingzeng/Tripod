# 基于Grpc的服务项目创建步骤：

> 目前直接使用`dotnet new grpc`方式创建的项目，在调用时会报错[#15623](https://github.com/grpc/grpc/issues/15623)

## 1.创建项目
```
dotnet new console --name Tripod.Service.[Name] --output src/Tripod.Service.[Name]
dotnet sln add src/[Name]/[Name].csproj
```

## 2.添加Grpc的引用
```
cd src/Tripod.Service.[Name]

dotnet add package Google.Protobuf --version 3.10.1
dotnet add package Grpc --version 2.25.0
dotnet add package Grpc.Tools --version 2.25.0
```

## 3.添加proto文件并在项目文件中引用
```bash
cd ../../
touch [name].proto
```
```xml
<ItemGroup>
    <Protobuf Include="../../protos/[project name].proto" />
</ItemGroup>
```
> [重要]这样在构建项目(dotnet build)时会自动生成Grpc要使用的代码文件，存放在bin目录下

## 4.实现服务
```csharp
public class UserService : Users.UsersBase
{
    public override Task<User> GetUserByUsername(GetUserByUsernameRequest request, ServerCallContext context)
    {
        return Task.FromResult(new User{ Username = "admin" });
    }
}
```

## 5.main函数中启动服务监听
```csharp
static void Main(string[] args)
{ 
    const int Port = 50051;
    Server server = new Server
    {
        Services = { Users.BindService(new UserService()) },
        Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
    };
    server.Start();

    Console.WriteLine("Greeter server listening on port " + Port);
    Console.WriteLine("Press any key to stop the server...");
    Console.ReadKey();

    server.ShutdownAsync().Wait();
}
```

# 项目结构
