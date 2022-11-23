using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.ProjetoR
{
	public class Pedido
	{
		public int Id { get; set; }
		public Guid ClienteId { get; set; }
		public decimal PrecoProdutos { get; set; }
		public decimal PrecoTaxaServico { get; set; }
		public DateTime Emissao { get; set; }

		public Pedido(int Id_, Guid ClienteId_, decimal PrecoProdutos_, decimal PrecoTaxaServico_, DateTime Emissao_)
		{
			this.Id = Id_;
			this.ClienteId = ClienteId_;
			this.PrecoProdutos = PrecoProdutos_;
			this.PrecoTaxaServico = PrecoTaxaServico_;
			this.Emissao = Emissao_;
		}
	}
}