using System;
using Grpc.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore;

namespace Envoy_GRPC_CSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            KickOffGrpc();
            KickOffKestrel();

            // If you don't use Kestrel, here's how you can block the thread from exiting in Docker:

            // var waitForStop = new TaskCompletionSource<object>();
            // waitForStop.Task.Wait();
        }

        private static void KickOffGrpc()
        {
            Server server = new Server
            {
                Services = {
                                EnvoyGrpcService.HelloWorldService.BindService(new HelloWorldServiceImpl())
                           },
                Ports = { { "0.0.0.0", 5000, ServerCredentials.Insecure } }
            };

            server.Start();

            Console.WriteLine("Started GRPC server...");
        }

        private static void KickOffKestrel()
        {
            WebHost.CreateDefaultBuilder()
                            .UseKestrel(options =>
                            {
                                options.Listen(IPAddress.Parse("0.0.0.0"), 5001);
                            })
                            .Configure(appBuilder =>
                            {
                                appBuilder.Use((context, next) =>
                                    context.Response.WriteAsync($"Hello World from Kestrel! Hostname: {Environment.MachineName}"));
                            })
                            .Build()
                            .Run();
        }
    }
}
