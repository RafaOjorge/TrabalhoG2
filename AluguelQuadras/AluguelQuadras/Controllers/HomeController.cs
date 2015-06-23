using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AluguelQuadras.Models;
using AluguelQuadras.Models.Entity;
using AluguelQuadras.Models.Repository;

namespace AluguelQuadras.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AluguelRepository aluguel = new AluguelRepository();
            var alugueis = aluguel.GetAlugueis();

            return View(alugueis);
        }

        public ActionResult NovoAluguel()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.ListaClientes = new SelectList
            (
                new ClienteRepository().GetClientes(), "NomeCliente", "NomeCliente"
            );

            ViewBag.ListaQuadras = new SelectList
            (
                new QuadraRepository().GetQuadras(), "NomeQuadra", "NomeQuadra"
            );
            return View();
        }

        [HttpPost]
        public ActionResult NovoAluguel(Aluguel aluguel)
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.ListaClientes = new SelectList
            (
                new ClienteRepository().GetClientes(), "NomeCliente", "NomeCliente"
            );

            ViewBag.ListaQuadras = new SelectList
            (
                new QuadraRepository().GetQuadras(), "NomeQuadra", "NomeQuadra"
            );

            if (ModelState.IsValid)
            {
                AluguelRepository novo = new AluguelRepository();

                novo.Novo(aluguel);

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ClienteFiltro(string nomeCliente)
        {
            ClienteRepository cliente = new ClienteRepository();
            var clientes = cliente.GetClientesPorNome(nomeCliente);

            return View(clientes);
        }

        public ActionResult Cliente()
        {
            ClienteRepository cliente = new ClienteRepository();
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
                ClienteRepository novo = new ClienteRepository();

                novo.Novo(cliente);

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult QuadraFiltro(string nomeQuadra)
        {
            QuadraRepository quadra = new QuadraRepository();
            var quadras = quadra.GetQuadrasPorNome(nomeQuadra);

            return View(quadras);
        }

        public ActionResult Quadra()
        {
            QuadraRepository quadra = new QuadraRepository();
            var quadras = quadra.GetQuadras();

            return View(quadras);
        }

        public ActionResult NovaQuadra()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult NovaQuadra(Quadra quadra)
        {
            ViewBag.Message = "Your application description page.";

            if (ModelState.IsValid)
            {
                QuadraRepository novo = new QuadraRepository();

                novo.Novo(quadra);

                return RedirectToAction("Index");
            }
            return View();
        }

    }
}