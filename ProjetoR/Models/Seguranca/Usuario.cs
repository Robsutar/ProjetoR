using ProjetoR.Models.ProjetoR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.Seguranca
{
    public class Usuario
    {
        public static List<Usuario> usuariosAtivos = new List<Usuario>();

        public string Identifier { get; }
        public DateTime UltimaAtividade { get; private set; }
        protected Usuario(string identifier)
        {
            Identifier = identifier;
            UltimaAtividade = DateTime.Now;
        }
        public void MarcarAtividade()
        {
            UltimaAtividade = DateTime.Now;
        }
        public static Usuario CarregarUsuario(HttpRequestBase request)
        {
            string identifier = request.Headers["User-Agent"]+request.Headers["Accept"];

            foreach(Usuario u in usuariosAtivos)
            {
                if (identifier == u.Identifier)
                    return u;
            }
            return new Usuario(identifier);
        }
        public static void RemoverUsuariosInativos()
        {
            DateTime now = DateTime.Now;
            foreach (Usuario u in new List<Usuario>(usuariosAtivos))
            {
                if (now.Subtract(u.UltimaAtividade).TotalMinutes > 10)
                    usuariosAtivos.Remove(u);
            }
        }
        public static Usuario TornarUsuario(Usuario u)
        {
            usuariosAtivos.Remove(u);
            Usuario g = new Usuario(u.Identifier);
            usuariosAtivos.Add(g);
            return g;
        }
        public class Gerente : Usuario
        {
            protected Gerente(string identifier) : base(identifier)
            {
            }

            public static Gerente TornarGerente(Usuario u)
            {
                usuariosAtivos.Remove(u);
                Gerente g = new Gerente(u.Identifier);
                usuariosAtivos.Add(g);
                return g;
            }
        }
        public class Cozinha : Usuario
        {
            protected Cozinha(string identifier) : base(identifier)
            {
            }

            public static Cozinha TornarCozinha(Usuario u)
            {
                usuariosAtivos.Remove(u);
                Cozinha g = new Cozinha(u.Identifier);
                usuariosAtivos.Add(g);
                return g;
            }

            public static List<Pedido> CarregarPedidos()
            {
                return BancoDeDados.CarregarLista(Pedido.CarregarPedido);
            }
        }
        public class Cliente : Usuario
        {
            public List<Produto> Carrinho = new List<Produto>();
            public ProjetoR.Cliente ClienteBd{ get; }
            protected Cliente(string identifier,ProjetoR.Cliente cliente) : base(identifier)
            {
                ClienteBd = cliente;
            }

            public static Cliente TornarCliente(Usuario u,ProjetoR.Cliente cliente)
            {
                usuariosAtivos.Remove(u);
                Cliente g = new Cliente(u.Identifier,cliente);
                usuariosAtivos.Add(g);
                return g;
            }

            public override string ToString()
            {
                return "Cliente ("+ClienteBd.Id+") - Mesa: "+ClienteBd.MesaId;
            }
        }

    }
}