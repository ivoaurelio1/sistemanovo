using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sistemanovo.Models;

namespace sistemanovo.Controllers
{
    public class AtAssuntoController : Controller
    {
               public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(AtAssunto ata)
        {
            AtAssuntoRepository us = new AtAssuntoRepository();
            us.Inserir(ata);
            ViewBag.Mensagem = "Cadastro realizado!";
            return View();
        }

        public IActionResult Lista(AtAssunto ata)
        {
            AtAssuntoRepository at = new AtAssuntoRepository();

            if (HttpContext.Session.GetInt32("id_usuario") == null)
            {
               return RedirectToAction("Login", "Usuarios");
            }
            else
            {
                List<AtAssunto> listaAssunto = at.Listar();
                return View(listaAssunto);
            }
        }

        // A variável daqui tem que ser igual a que se encontra na Lista.cshtml
        public IActionResult Remover(int Id)
        {
            AtAssuntoRepository at = new AtAssuntoRepository();
            AtAssunto assuntolocalizado = at.BuscarPorId(Id);
            at.Excluir(assuntolocalizado);
            return RedirectToAction("Lista", "AtAssunto");
        }
        public IActionResult Editar(int Id)
        {
            AtAssuntoRepository at = new AtAssuntoRepository();
            AtAssunto assuntoLocalizado = at.BuscarPorId(Id);
            return View(assuntoLocalizado);
        }

        [HttpPost]
        public IActionResult Editar(AtAssunto ata)
        {
            AtAssuntoRepository at = new AtAssuntoRepository();
            at.Alterar(ata);
            return RedirectToAction("Lista", "AtAssunto");
        }
 
    }
}