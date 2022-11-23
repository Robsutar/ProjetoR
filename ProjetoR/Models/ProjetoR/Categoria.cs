using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.ProjetoR
{
	public class Categoria
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public bool Imediato { get; set; }

		public Categoria(int Id_, string Nome_, string Descricao_, bool Imediato_)
		{
			this.Id = Id_;
			this.Nome = Nome_;
			this.Descricao = Descricao_;
			this.Imediato = Imediato_;
		}
	}
}