using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.ProjetoR
{
	public class Cliente
	{
		public int Id { get; set; }
		public int MesaId { get; set; }

		public Cliente(int Id_, int MesaId_)
		{
			this.Id = Id_;
			this.MesaId = MesaId_;
		}

		public List<Pedido> CarregarPedidos()
        {
			return BancoDeDados.CarregarLista(new SqlCommand(
				"SELECT * FROM Pedido WHERE ClienteId = "+Id),Pedido.CarregarPedido);
        }

		public static Cliente CarregarCliente(SqlDataReader reader, bool readed)
		{
			if (!readed)
				if (!reader.Read())
					throw new NotImplementedException();
			return new Cliente((int)reader["Id"], (int)reader["MesaId"]);
        }

		public static Cliente CarregarCliente(int id)
        {
			return BancoDeDados.Carregar(id,CarregarCliente);
        }

		public static Cliente CriarCliente(int mesaId)
        {
			if (Mesa.CarregarMesa(mesaId).Ocupada)
				throw new NotImplementedException();
			return new Cliente(BancoDeDados.InserirEscalar<Cliente>(new List<object> { mesaId }), mesaId);
        }
	}
}