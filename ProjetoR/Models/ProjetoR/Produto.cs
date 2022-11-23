using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.ProjetoR
{
	public class Produto
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public int Categoria { get; set; }
		public decimal Preco { get; set; }

		public Produto(int Id_, string Nome_, string Descricao_, int Categoria_, decimal Preco_)
		{
			this.Id = Id_;
			this.Nome = Nome_;
			this.Descricao = Descricao_;
			this.Categoria = Categoria_;
			this.Preco = Preco_;
		}
	}
}