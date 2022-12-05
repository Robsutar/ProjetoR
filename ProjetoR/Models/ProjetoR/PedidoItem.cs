using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.ProjetoR
{
	public class PedidoItem
	{
		public int Id { get; set; }
		public int PedidoId { get; set; }
		public int ProdutoId { get; set; }
		public string Observacoes { get; set; }

		public PedidoItem(int Id_, int PedidoId_, int ProdutoId_, string Observacoes_)
		{
			this.Id = Id_;
			this.PedidoId = PedidoId_;
			this.ProdutoId = ProdutoId_;
			this.Observacoes = Observacoes_;
		}

        public static PedidoItem CarregarPedido(SqlDataReader reader, bool readed)
		{
			if (!readed)
				if (!reader.Read())
					throw new NotImplementedException();
			return new PedidoItem((int)reader["Id"], (int)reader["PedidoId"],
				(int)reader["ProdutoId"], (string)reader["Observacoes"]);
        }

		public Produto CarregarProduto()
        {
			return Produto.CarregarProduto(ProdutoId);
        }
    }
}