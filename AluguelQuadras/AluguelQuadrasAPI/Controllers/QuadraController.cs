using AluguelQuadras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AluguelQuadrasAPI.Controllers
{
    public class QuadraController : ApiController
    {
        public IEnumerable<Quadra> GetAllFacts()
        {
            Quadra quadra = new Quadra();
            var quadras = quadra.GetQuadras();
            return quadras;
        }
    }
}
