using Grpc.Core;
using Saludo;

namespace Servidor
{
    class Program
    {
        const int Port = 50051;
        static void Main(string[] args)
        {
            Grpc.Core.Server server = null;

            try
            {
                server = new Grpc.Core.Server()
                {
                    Services = {
                        SaludoService.BindService(
                            new SaludoServiceImpl()),
                    },
                    Ports = { new ServerPort("localhost",Port, ServerCredentials.Insecure)}
                };

                server.Start();
                Console.WriteLine("Servidor C# escuchando en el puerto: "+Port);
                Console.ReadKey();
            }
            catch (IOException ex) { 
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(server != null)
                {
                    server.ShutdownAsync().Wait();
                }
            }

        }
    }
}
