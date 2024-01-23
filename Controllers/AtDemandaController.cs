using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sistemanovo.Models;
using sistemanovo.Models.ViewModels;

namespace sistemanovo.Controllers
{
    public class AtDemandaController : Controller
    {
        public IActionResult Cadastro()
        {
             if (HttpContext.Session.GetInt32("id_usuario") == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            AtAssuntoRepository assuntoRepo = new AtAssuntoRepository();
            List<AtAssunto> listaAssuntos = assuntoRepo.Listar();

            CadastroDemandaViewModel cadastroDemandaViewModel = new CadastroDemandaViewModel();
            cadastroDemandaViewModel.ListaAssuntos = listaAssuntos; 

            // a mesma coisa de cima pra usuario            
            List<AtDemanda> listaDemandas = new List<AtDemanda>();
            List<AtAssunto> listadeAssuntos = new List<AtAssunto>();

            cadastroDemandaViewModel.ListaDemandas = listaDemandas;
            cadastroDemandaViewModel.ListaAssuntos = listaAssuntos;
            return View(cadastroDemandaViewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CadastroDemandaViewModel atd)
        {
             if (HttpContext.Session.GetInt32("id_usuario") == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            AtDemandaRepository us = new AtDemandaRepository();

            AtAssunto novoAssunto = new AtAssunto();
            novoAssunto.IdAtAssunto = atd.IdAtAssunto;
          
            AtDemanda novaDemanda = new AtDemanda();
            novaDemanda.IdAtDemanda = atd.IdAtDemanda;
            atd.Demandas.DataHora = DateTime.Now; //21/01/2024 01:37 adicionei essa linha pra ver se consigo atribuir a data e hora ao campo correto
            atd.Demandas.IdUsuario = HttpContext.Session.GetInt32("id_usuario").Value;

            us.Inserir(atd);
            ViewBag.Mensagem = "Demanda inserida!";
           return RedirectToAction("Lista", "AtDemanda");
        }

        public IActionResult Lista(AtDemanda atd)
        {
            AtDemandaRepository at = new AtDemandaRepository();

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

        public IActionResult Lista2(CadastroDemandaViewModel atd)
        {
            AtDemandaRepository at = new AtDemandaRepository();

             AtDemanda novaDemanda = new AtDemanda();
            novaDemanda.IdAtDemanda = atd.IdAtDemanda;

            at.Inserir(atd);

            if (HttpContext.Session.GetInt32("id_usuario") == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }
            else
            {
                CadastroDemandaViewModel viewModel = new CadastroDemandaViewModel();
                viewModel.ListaDemandas = at.Listar();
                List<AtDemanda> listaDemanda = at.Listar();
                return View(listaDemanda);
            }

        }

        // A variável daqui tem que ser igual a que se encontra na Lista.cshtml
        public IActionResult Remover(int Id)
        {
            AtDemandaRepository at = new AtDemandaRepository();
            AtDemanda demandalocalizada = at.BuscarPorId(Id); // 22/01/2024 17:38 coloquei o .Demandas no fim dessa linha
            at.Excluir(demandalocalizada);
            return RedirectToAction("Lista", "AtDemanda");
        }
        public IActionResult Editar(int Id)
        {
             if (HttpContext.Session.GetInt32("id_usuario") == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            AtDemandaRepository at = new AtDemandaRepository();
            CadastroDemandaViewModel cadastroDemandaViewModel = new CadastroDemandaViewModel();

            cadastroDemandaViewModel.Demandas = at.BuscarPorId(Id);
            
            // AtDemanda demandaLocalizada = at.BuscarPorId(Id); // 22/01/2024 17:38 coloquei o .Demandas no fim dessa linha
            cadastroDemandaViewModel.Demandas.IdUsuario = HttpContext.Session.GetInt32("id_usuario").Value;
            return View(cadastroDemandaViewModel);
        }

        [HttpPost]
        public IActionResult Editar(CadastroDemandaViewModel ata)
        {
             if (HttpContext.Session.GetInt32("id_usuario") == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            AtDemandaRepository at = new AtDemandaRepository();
            ata.Demandas.IdUsuario = HttpContext.Session.GetInt32("id_usuario").Value;
            at.Alterar(ata);
            return RedirectToAction("Lista", "AtDemanda");
            
            // vai precisar disso:
        }

    }
}