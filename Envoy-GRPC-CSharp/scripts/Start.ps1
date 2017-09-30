dotnet publish ..\Envoy-GRPC-CSharp.csproj --output bin\Output

Push-Location ..

docker-compose up -d --build

Pop-Location