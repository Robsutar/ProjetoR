using System;
using System.Collections.Generic;
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
	}
}