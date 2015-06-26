using AluguelQuadras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AluguelQuadrasAPI.Controllers
{
    public class AluguelController : ApiController
    {
        public IEnumerable<Aluguel> GetAllFacts()
        {
            Aluguel aluguel = new Aluguel();
            var alugueis = aluguel.GetAlugueis();
            return alugueis;
        }
    }
}
