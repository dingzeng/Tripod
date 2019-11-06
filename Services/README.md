# 基于Grpc的服务项目创建步骤：

> 目前直接使用`dotnet new grpc`方式创建的项目，在调用时会报错[#15623](https://github.com/grpc/grpc/issues/15623)

## 1.创建项目
```
dotnet new console --name Tripod.Service.[ProjectName]
```

## 2.添加Grpc的引用
```
dotnet add package Google.Protobuf
dotnet add package Google
dotnet add package Google.Tools
```

## 3.添加proto文件并在项目文件中引用
```xml
<ItemGroup>
    <Protobuf Include="helloworld.proto" />
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