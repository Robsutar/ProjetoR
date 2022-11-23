using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.ProjetoR
{
	public class Mesa
	{
		public int Id { get; set; }
		public bool Ocupada { get; set; }

		public Mesa(int Id_, bool Ocupada_)
		{
			this.Id = Id_;
			this.Ocupada = Ocupada_;
		}
	}
}