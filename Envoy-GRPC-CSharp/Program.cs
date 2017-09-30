using System;
using Grpc.Core;
using System.Threading.Tasks;
using System.Threading;

namespace Envoy_GRPC_CSharp
{
    class Program
    {
        private static readonly AutoResetEvent _closing = new AutoResetEvent(false);

        static void Main(string[] args)
        {

            Server server = new Server
            {
                Services = {
                                EnvoyGrpcService.HelloWorldService.BindService(new HelloWorldServiceImpl())
                           },
                Ports = { { "0.0.0.0", 5000, ServerCredentials.Insecure } }
            };

            server.Start();

            Console.WriteLine("Started...");

            // In Docker, a simple Console.ReadLine won't work if you wanna block the thread
            var waitForStop = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            waitForStop.Task.Wait();
        }
    }
}
