using System;
using System.Collections.Generic;
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
	}
}