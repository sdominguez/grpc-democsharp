using Grpc.Core;
using Saludo;

namespace Cliente
{ 
class Program
{
        const string target = "127.0.0.1:50051";

        static async Task Main(string[] args)
        {
            Channel channel = new Channel("localhost", 50051, ChannelCredentials.Insecure);

            await channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("Cliente conectado OK");
            });

            var client = new SaludoService.SaludoServiceClient(channel);

            saludar(client);

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }

        public static void saludar(SaludoService.SaludoServiceClient client)
        {
            var request = new SaludoRequest()
            {
                Nombre = "Saul"
            };

            var response = client.saludo(request);

            Console.WriteLine(response.Result);
        }
}

}
