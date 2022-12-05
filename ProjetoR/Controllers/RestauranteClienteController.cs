using ProjetoR.Models.ProjetoR;
using ProjetoR.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoR.Controllers
{
    public class RestauranteClienteController : Controller
    {
        // GET: RestauranteCliente
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }

        public ActionResult Carrinho()
        {
            if (!(Usuario.CarregarUsuario(Request) is Usuario.Cliente))
                return RedirectToAction("Index");
            return View();
        }
        private ActionResult MenuLink()
        {
            return RedirectToAction("Menu", "Restaurante");
        }
        private ActionResult CarrinhoLink()
        {
            return RedirectToAction("Carrinho", "RestauranteCliente");
        }

        public ActionResult CarrinhoAdicionar(int id)
        {
            if (Usuario.CarregarUsuario(Request) is Usuario.Cliente cliente)
                cliente.Carrinho.Add(Produto.CarregarProduto(id));
            return MenuLink();
        }

        public ActionResult CarrinhoRealizarPedido()
        {
            if (Usuario.CarregarUsuario(Request) is Usuario.Cliente cliente)
            {
                Pedido.RealizarPedido(cliente.ClienteBd.Id, cliente.Carrinho);
                cliente.Carrinho.Clear();
            }
            return CarrinhoLink();
        }
    }
}