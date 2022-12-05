using ProjetoR.Models.ProjetoR;
using ProjetoR.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjetoR
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //Restaurante Controller
            routes.MapRoute(
                name: "Restaurante",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Restaurante", action = "Menu", id = UrlParameter.Optional }
            );

            //RestauranteGerente Controller
            routes.MapRoute(
                name: "RestauranteGerente",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "RestauranteGerente", action = "Index", id = UrlParameter.Optional }
            );
            //RestauranteCozinha Controller
            routes.MapRoute(
                name: "RestauranteCozinha",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "RestauranteCozinha", action = "Index", id = UrlParameter.Optional }
            );
            //RestauranteCliente Controller
            routes.MapRoute(
                name: "RestauranteCliente",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "RestauranteCliente", action = "Index", id = UrlParameter.Optional }
            );
            Iniciar();
        }
        private static void Iniciar()
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += delegate (object sender, ElapsedEventArgs e)
            {
                Usuario.RemoverUsuariosInativos();
            };
            timer.Start();

            Mesa.Recriar(12);
            MenuItem.RemoverVazios();
            BancoDeDados.DeletarTudo<Cliente>();
            BancoDeDados.DeletarTudo<Pedido>();
            BancoDeDados.DeletarTudo<PedidoItem>();
        }
    }
}
