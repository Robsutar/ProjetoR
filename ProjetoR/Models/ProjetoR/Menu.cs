using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.ProjetoR
{
	public class Menu
	{
		public string Nome { get; set; }

		public Menu(string Nome_)
		{
			this.Nome = Nome_;
		}
	}
}