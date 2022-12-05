using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.ProjetoR
{
	public class Pedido
	{
		public int Id { get; set; }
		public int ClienteId { get; set; }
		public decimal PrecoProdutos { get; set; }
		public DateTime Emissao { get; set; }
		public int Status { get; set; }

		public Pedido(int Id_, int ClienteId_, decimal PrecoProdutos_, DateTime Emissao_,int Status_)
		{
			this.Id = Id_;
			this.ClienteId = ClienteId_;
			this.PrecoProdutos = PrecoProdutos_;
			this.Emissao = Emissao_;
			this.Status = Status_;
		}

		public Cliente CarregarCliente()
        {
			return Cliente.CarregarCliente(ClienteId);
        }

		public List<PedidoItem> CarregarItems()
        {
			return BancoDeDados.CarregarLista(new SqlCommand(
				"SELECT * FROM PedidoItem WHERE PedidoId = " + Id), PedidoItem.CarregarPedido);
        }

        public static Pedido CarregarPedido(SqlDataReader reader, bool readed)
		{
			if (!readed)
				if (!reader.Read())
					throw new NotImplementedException();
			return new Pedido((int)reader["Id"],(int)reader["ClienteId"],
				(decimal)reader["PrecoProdutos"], (DateTime)reader["Emissao"],(int)reader["Status"]);
		}

        public static void RealizarPedido(int clienteId, List<Produto> carrinho)
        {
			decimal total = 0;
			foreach(Produto p in carrinho)
            {
				total += p.Preco;
            }
			int pedidoId = BancoDeDados.InserirEscalar<Pedido>(new List<object>() 
			{ clienteId, total, DateTime.Now, 0 });
			foreach (Produto p in carrinho)
			{
				BancoDeDados.Inserir<PedidoItem>(new List<object>() { pedidoId,p.Id,"Sem observações"});
			}
		}
    }
}