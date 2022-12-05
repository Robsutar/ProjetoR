using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.ProjetoR
{
	public class Produto : IEquatable<Produto>
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

        public static List<Produto> CarregarProdutos()
        {
			return BancoDeDados.CarregarLista(CarregarProduto);
        }

        public static Produto CarregarProduto(SqlDataReader reader, bool readed)
		{
			if (!readed)
				if (!reader.Read())
					throw new NotImplementedException();
			return new Produto((int)reader["Id"], (string)reader["Nome"],
                        (string)reader["Descricao"], (int)reader["Categoria"],
                        (decimal)reader["Preco"]);
        }
		public static Produto CarregarProduto(int id)
        {
			return BancoDeDados.Carregar(id, CarregarProduto);
        }

        public bool Equals(Produto other)
        {
            return other.Id == Id;
        }
    }
}