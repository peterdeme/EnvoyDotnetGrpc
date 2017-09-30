dotnet publish ..\Envoy-GRPC-CSharp.csproj --output bin\Output

Push-Location ..

docker-compose up --build

Pop-Location