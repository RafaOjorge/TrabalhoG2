using AluguelQuadras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AluguelQuadrasAPI.Controllers
{
    public class ClienteController : ApiController
    {
        public IEnumerable<Cliente> GetAllFacts()
        {
            Cliente cliente = new Cliente();
            var clientes = cliente.GetClientes();
            return clientes;
        }
    }
}
