using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AluguelQuadras.Models;
using System.IO;

namespace AluguelQuadras.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string usuario, string senha)
        {
            Autenticacao autentica = new Autenticacao();
            var isValido = autentica.isValido(usuario, senha);
            if (isValido == true)
            {
                @TempData["Logado"] = "true";
                return RedirectToAction("Aluguel");
            }
            ViewBag.MensagemDeErro = "Usuário ou senha inválidos";
            @TempData["Logado"] = "false";
            return View();
        }

        public ActionResult Aluguel()
        {
            if (@TempData["Logado"].Equals("true"))
            {
                Aluguel aluguel = new Aluguel();
                var alugueis = aluguel.GetAlugueis();
                @TempData["Logado"] = "true";
                return View(alugueis);
            }
            return View();
        }

        public ActionResult NovoAluguel()
        {
            if (@TempData["Logado"].Equals("true"))
            {
                @TempData["Logado"] = "true";
                ViewBag.ListaClientes = new SelectList
                (
                    new Cliente().GetClientes(), "NomeCliente", "NomeCliente"
                );

                ViewBag.ListaQuadras = new SelectList
                (
                    new Quadra().GetQuadras(), "NomeQuadra", "NomeQuadra"
                );
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult NovoAluguel(Aluguel aluguel)
        {
            if (@TempData["Logado"].Equals("true"))
            {
                @TempData["Logado"] = "true";
                ViewBag.ListaClientes = new SelectList
                (
                    new Cliente().GetClientes(), "NomeCliente", "NomeCliente"
                );

                ViewBag.ListaQuadras = new SelectList
                (
                    new Quadra().GetQuadras(), "NomeQuadra", "NomeQuadra"
                );

                if (ModelState.IsValid)
                {
                    Aluguel novo = new Aluguel();

                    novo.Novo(aluguel);

                    return RedirectToAction("Aluguel");
                }
                return View();
            }
            return View();
        }

        public ActionResult EditaAluguel(int id)
        {
            ViewBag.TextoId = id;
            TempData["id"] = id;
            ViewBag.ListaClientes = new SelectList
            (
                new Cliente().GetClientes(), "NomeCliente", "NomeCliente"
            );

            ViewBag.ListaQuadras = new SelectList
            (
                new Quadra().GetQuadras(), "NomeQuadra", "NomeQuadra"
            );
            return View();
        }

        [HttpPost]
        public ActionResult EditaAluguel(Aluguel pAluguel)
        {
            pAluguel.IdAluguel = (int)TempData["id"];
            Aluguel nova = new Aluguel();

            nova.Editar(pAluguel);

            return RedirectToAction("Aluguel");
        }

        public ActionResult DeleteAluguel(int id)
        {
            Aluguel nova = new Aluguel();

            nova.Delete(id);

            return RedirectToAction("Aluguel");
        }

        [HttpGet]
        public ActionResult ClienteFiltro(string nomeCliente)
        {
            if (@TempData["Logado"].Equals("true"))
            {
                @TempData["Logado"] = "true";
                Cliente cliente = new Cliente();
                var clientes = cliente.GetClientesPorNome(nomeCliente);
                return View(clientes);
            }
            return View();
        }

        public ActionResult Cliente()
        {
            if (@TempData["Logado"].Equals("true"))
            {
                @TempData["Logado"] = "true";
                Cliente cliente = new Cliente();
                var clientes = cliente.GetClientes();
                return View(clientes);
            }
            return View();
        }

        public ActionResult NovoCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovoCliente(Cliente cliente)
        {
            if (@TempData["Logado"].Equals("true"))
            {
                @TempData["Logado"] = "true";
                if (ModelState.IsValid)
                {
                    Cliente novo = new Cliente();

                    novo.Novo(cliente);

                    return RedirectToAction("Cliente");
                }
                return View();
            }
            return View();
        }

        public ActionResult EditaCliente(int id)
        {
            ViewBag.TextoId = id;
            TempData["id"] = id;

            return View();
        }

        [HttpPost]
        public ActionResult EditaCliente(Cliente pCliente)
        {
            pCliente.IdCliente = (int)TempData["id"];
            Cliente nova = new Cliente();

            nova.Editar(pCliente);

            return RedirectToAction("Cliente");
        }

        public ActionResult DeleteCliente(int id)
        {
            Cliente nova = new Cliente();

            nova.Delete(id);

            return RedirectToAction("Cliente");
        }

        [HttpGet]
        public ActionResult QuadraFiltro(string nomeQuadra)
        {
            if (@TempData["Logado"].Equals("true"))
            {
                @TempData["Logado"] = "true";
                Quadra quadra = new Quadra();
                var quadras = quadra.GetQuadrasPorNome(nomeQuadra);
                return View(quadras);
            }
            return View();
        }

        public ActionResult Quadra()
        {
            if (@TempData["Logado"].Equals("true"))
            {
                @TempData["Logado"] = "true";
                Quadra quadra = new Quadra();
                var quadras = quadra.GetQuadras();
                return View(quadras);
            }
            return View();
        }

        public ActionResult NovaQuadra()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovaQuadra(Quadra quadra)
        {
            if (@TempData["Logado"].Equals("true"))
            {
                @TempData["Logado"] = "true";
                if (ModelState.IsValid)
                {
                    Quadra novo = new Quadra();

                    novo.Novo(quadra);

                    return RedirectToAction("Quadra");
                }
                return View();
            }
            return View();
        }

        public ActionResult EditaQuadra(int id)
        {
            ViewBag.TextoId = id;
            TempData["id"] = id;

            return View();
        }

        [HttpPost]
        public ActionResult EditaQuadra(Quadra pQuadra)
        {
            pQuadra.IdQuadra = (int)TempData["id"];
            Quadra nova = new Quadra();

            nova.Editar(pQuadra);

            return RedirectToAction("Quadra");
        }

        public ActionResult DeleteQuadra(int id)
        {
            Quadra nova = new Quadra();

            nova.Delete(id);

            return RedirectToAction("Quadra");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}