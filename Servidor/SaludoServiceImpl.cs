using Grpc.Core;
using Saludo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    internal class SaludoServiceImpl : Saludo.SaludoService.SaludoServiceBase
    {
        public override Task<SaludoResponse> saludo(SaludoRequest request, ServerCallContext context)
        {
            string result = String.Format("Hola {0} desde C#",
                request.Nombre);

            return Task.FromResult(new SaludoResponse()
            {
                Result = result
            }); ;
        }
    }
}
