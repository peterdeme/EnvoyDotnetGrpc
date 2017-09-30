using Grpc.Core;
using System;
using static EnvoyGrpcService.HelloWorldService;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = new HelloWorldServiceClient(new Channel("127.0.0.1", 9211, ChannelCredentials.Insecure));

                var response = client.SayHelloWorld(new EnvoyGrpcService.HelloWorldRequest());

                Console.WriteLine(response.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Done. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
