using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AluguelQuadras.Models;

namespace AluguelQuadras.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Aluguel aluguel = new Aluguel();
            var alugueis = aluguel.GetAlugueis();

            return View(alugueis);
        }

        public ActionResult NovoAluguel()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult NovoAluguel(Aluguel aluguel)
        {
            ViewBag.Message = "Your application description page.";

            if (ModelState.IsValid)
            {
                Aluguel novo = new Aluguel();

                novo.Novo(aluguel);

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Cliente()
        {
            Cliente cliente = new Cliente();
            var clientes = cliente.GetClientes();

            return View(clientes);
        }

        public ActionResult NovoCliente()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult NovoCliente(Cliente cliente)
        {
            ViewBag.Message = "Your application description page.";

            if (ModelState.IsValid)
            {
                Cliente novo = new Cliente();

                novo.Novo(cliente);

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}