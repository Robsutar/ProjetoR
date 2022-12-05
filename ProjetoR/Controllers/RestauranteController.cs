using ProjetoR.Models.ProjetoR;
using ProjetoR.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;

namespace ProjetoR.Controllers
{
    public class RestauranteController : Controller
    {
        public static Menu MenuAtivo = new Menu("Menu Completo");
        // GET: Restaurante
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Menu()
        {
            return View();
        }

        #region Usuario Login
        public ActionResult Sair()
        {
            Usuario.TornarUsuario(Usuario.CarregarUsuario(Request));
            return RedirectToAction("Index");
        }
        public ActionResult TornarGerente()
        {
            Usuario.Gerente.TornarGerente(Usuario.CarregarUsuario(Request));
            return RedirectToAction("Index");
        }
        public ActionResult TornarCozinha()
        {
            Usuario.Cozinha.TornarCozinha(Usuario.CarregarUsuario(Request));
            return RedirectToAction("Index");
        }
        public ActionResult TornarCliente()
        {
            Mesa mesa = Mesa.CarregarMesa(1);
            Usuario.Cliente.TornarCliente(Usuario.CarregarUsuario(Request),
                Cliente.CriarCliente(mesa.Id));
            mesa.AtualizarOcupacao(true);
            return RedirectToAction("Index");
        }
        #endregion
    }
}