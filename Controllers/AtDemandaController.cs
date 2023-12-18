using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sistemanovo.Models;

namespace sistemanovo.Controllers
{
    public class AtDemandaController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(AtDemanda atd)
        {
            AtDemandaRepository us = new AtDemandaRepository();
            // AtDemanda novaDemanda = new AtDemanda();
            DateTime now = DateTime.Now;
            // var DataHora = now;

            us.Inserir(atd);
            ViewBag.Mensagem = "Demanda inserida!";
            return View();
        }

        public IActionResult Lista(AtDemanda atd)
        {
            AtDemandaRepository at = new AtDemandaRepository();
            // AtAssunto usuarioEncontrado = us.ValidarLogin(usu);

            if (HttpContext.Session.GetInt32("id_usuario") == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }
            else
            {
                List<AtDemanda> listaDemanda = at.Listar();
                return View(listaDemanda);
            }
        }

        // A variável daqui tem que ser igual a que se encontra na Lista.cshtml
        public IActionResult Remover(int Id)
        {
            AtDemandaRepository at = new AtDemandaRepository();
            AtDemanda demandalocalizada = at.BuscarPorId(Id);
            at.Excluir(demandalocalizada);
            return RedirectToAction("Lista", "AtDemanda");
        }
        public IActionResult Editar(int Id)
        {
            AtDemandaRepository at = new AtDemandaRepository();
            AtDemanda demandaLocalizada = at.BuscarPorId(Id);
            return View(demandaLocalizada);
        }

        [HttpPost]
        public IActionResult Editar(AtDemanda ata)
        {
            AtDemandaRepository at = new AtDemandaRepository();
            at.Alterar(ata);
            return RedirectToAction("Lista", "AtDemanda");
        }

    }
}