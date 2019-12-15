dotnet build

cd .\src\Tripod.Application.AdminApi\
@start dotnet run --no-build

cd ..\Tripod.Service.Archive\
@start dotnet run --no-build

cd ..\Tripod.Service.System\
@start dotnet run --no-build