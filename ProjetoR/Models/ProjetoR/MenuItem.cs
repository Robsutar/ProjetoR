using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.ProjetoR
{
	public class MenuItem
	{
		public int Id { get; set; }
		public string MenuNome { get; set; }
		public int ProdutoId { get; set; }

		public MenuItem(int Id_, string MenuNome_, int ProdutoId_)
		{
			this.Id = Id_;
			this.MenuNome = MenuNome_;
			this.ProdutoId = ProdutoId_;
		}
		public static MenuItem CarregarMenuItem(SqlDataReader reader,bool readed)
        {
			if (!readed)
				if (!reader.Read())
					throw new NotImplementedException();
			return new MenuItem((int)reader["Id"], 
				(string)reader["MenuNome"], (int)reader["ProdutoId"]);
        }

        public static void RemoverVazios()
        {
			List<Produto> produtos = Produto.CarregarProdutos();
			foreach(MenuItem i in BancoDeDados.CarregarLista(CarregarMenuItem))
            {
				foreach(Produto p in produtos)
                {
					if (i.ProdutoId == p.Id)
						goto l1;
                }
				BancoDeDados.Deletar<MenuItem>(i.Id);
				l1: { }
            }
        }
    }
}