using System.Threading.Tasks;
using EnvoyGrpcService;
using Grpc.Core;
using static EnvoyGrpcService.HelloWorldService;
using System;

namespace Envoy_GRPC_CSharp
{
    public class HelloWorldServiceImpl : HelloWorldServiceBase
    {
        public override Task<HelloWorldResponse> SayHelloWorld(HelloWorldRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloWorldResponse
            {
                Message = $"Hello World from GRPC! Hostname: {Environment.MachineName}"
            });
        }
    }
}
