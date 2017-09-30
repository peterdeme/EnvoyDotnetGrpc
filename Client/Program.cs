using Grpc.Core;
using System;
using System.Net.Http;
using static EnvoyGrpcService.HelloWorldService;

namespace Client
{
    class Program
    {
        private static HttpClient _httpClient = new HttpClient();
        private static HelloWorldServiceClient _client = new HelloWorldServiceClient(new Channel("127.0.0.1", 9211, ChannelCredentials.Insecure));

        static void Main(string[] args)
        {

            Console.WriteLine("Contacting GRPC endpoint...");

            var grpcResponse = _client.SayHelloWorld(new EnvoyGrpcService.HelloWorldRequest());

            Console.WriteLine(grpcResponse.Message);

            Console.WriteLine("Contacting REST endpoint...");

            var httpResponse = _httpClient.GetAsync("http://127.0.0.1:9211").Result;

            Console.WriteLine(httpResponse.Content.ReadAsStringAsync().Result);

            Console.WriteLine("Done. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
