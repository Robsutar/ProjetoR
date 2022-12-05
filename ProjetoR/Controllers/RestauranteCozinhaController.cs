using ProjetoR.Models.ProjetoR;
using ProjetoR.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoR.Controllers
{
    public class RestauranteCozinhaController : Controller
    {
        // GET: RestauranteCozinha
        public ActionResult Index()
        {
            if (Usuario.CarregarUsuario(Request) is Usuario.Cozinha)
                return View();
            return RedirectToAction("Index", "Home");
        }
        
        private ActionResult IndexLink()
        {
            return RedirectToAction("Index","RestauranteCozinha");
        }

        [HttpPost]
        public ActionResult AlterarStatus(string id, string status)
        {
            if (!(Usuario.CarregarUsuario(Request) is Usuario.Cozinha))
                return IndexLink();

            var dict = new Dictionary<string, object>();
            dict.Add("Status", int.Parse(status));
            BancoDeDados.Atualizar<Pedido>(int.Parse(id), dict);

            return IndexLink();
        }
    }
}