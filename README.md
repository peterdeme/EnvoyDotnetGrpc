# A simple C# app with Envoy as a reverse proxy
The app runs GRPC and Kestrel server as well. Envoy will decide which endpoint to forward the message to based on its routing settings.

# Prerequisites
- VS2017
- Docker
- .NET Core 2

# How to run

In Powershell:
```powershell
git clone https://github.com/peterdeme/EnvoyDotnetGrpc.git
cd .\Envoy-GRPC-CSharp\Envoy-GRPC-CSharp\scripts\
.\Start.ps1
```
Now, Envoy is listening on localhost:9211.

How to test with the client app:
```powershell
cd .\Envoy-GRPC-CSharp\Client
dotnet run
```
