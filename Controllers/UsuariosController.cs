using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sistemanovo.Models;
using Microsoft.AspNetCore.Http;

namespace sistemanovo.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Cadastro()
        {
             if (HttpContext.Session.GetInt32("id_usuario") == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuarios usu)
        {
             if (HttpContext.Session.GetInt32("id_usuario") == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            UsuariosRepository us = new UsuariosRepository();
            us.Inserir(usu);
            ViewBag.Mensagem = "Cadastro realizado!";
            return View();
        }

        public IActionResult Lista(Usuarios usu)
        {
            UsuariosRepository us = new UsuariosRepository();
            Usuarios usuarioEncontrado = us.ValidarLogin(usu);

            if (HttpContext.Session.GetInt32("id_usuario") == null)
            {
               return RedirectToAction("Login", "Usuarios");
            }
            else
            {
                List<Usuarios> listaUsuarios = us.Listar();
                return View(listaUsuarios);
            }
        }

        // A variável daqui tem que ser igual a que se encontra na Lista.cshtml
        public IActionResult Remover(int Id)
        {
            UsuariosRepository us = new UsuariosRepository();
            Usuarios usuariolocalizado = us.BuscarPorId(Id);
            us.Excluir(usuariolocalizado);
            return RedirectToAction("Lista", "Usuarios");
        }
        public IActionResult Editar(int Id)
        {
             if (HttpContext.Session.GetInt32("id_usuario") == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            UsuariosRepository us = new UsuariosRepository();
            Usuarios usuarioLocalizado = us.BuscarPorId(Id);
            return View(usuarioLocalizado);
        }

        [HttpPost]
        public IActionResult Editar(Usuarios usu)
        {
             if (HttpContext.Session.GetInt32("id_usuario") == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            UsuariosRepository us = new UsuariosRepository();
            us.Alterar(usu);
            return RedirectToAction("Lista", "Usuarios");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(Usuarios usu)
        {
            UsuariosRepository us = new UsuariosRepository();
            Usuarios usuarioEncontrado = us.ValidarLogin(usu);

            if (usuarioEncontrado == null)
            {
                ViewBag.Mensagem = "Código de barras ou senha inválidos!!!";
                return View();
            }
            else
            {
                // HttpContext.Session.SetString("bar_code", usuarioEncontrado.bar_code);
                HttpContext.Session.SetInt32("id_usuario", usuarioEncontrado.id_usuario);
                // HttpContext.Session.SetString("senha", usuarioEncontrado.senha);
                HttpContext.Session.SetString("nome_usuario", usuarioEncontrado.nome_usuario);

                return RedirectToAction("Lista", "Usuarios");
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

    }
}