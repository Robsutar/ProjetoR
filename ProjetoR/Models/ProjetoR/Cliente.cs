using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.ProjetoR
{
	public class Cliente
	{
		public Guid DispositivoId { get; set; }
		public int MesaId { get; set; }

		public Cliente(Guid DispositivoId_, int MesaId_)
		{
			this.DispositivoId = DispositivoId_;
			this.MesaId = MesaId_;
		}
	}
}