using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public List<Produto> CarregarProdutos()
        {
            List<Produto> saida = new List<Produto>();

            SqlConnection conn = new SqlConnection(BancoDeDados.ConnString);
            try
            {
                SqlCommand comm = new SqlCommand("SELECT * FROM Produto WHERE Categoria = @categoria", conn);
                SqlParameter pCategoria = new SqlParameter("@categoria",Id);
                comm.Parameters.Add(pCategoria);

                conn.Open();

                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        saida.Add(Produto.CarregarProduto(reader,true));
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return saida;
        }

        public static Categoria CarregarCategoria(SqlDataReader reader,bool readed)
        {
            if (!readed)
                if (!reader.Read())
                    throw new NotImplementedException();
            return new Categoria((int)reader["Id"], (string)reader["Nome"],
                            (string)reader["Descricao"], (bool)reader["Imediato"]);
        }

        public static List<Categoria> CarregarCategorias()
        {
            return BancoDeDados.CarregarLista(CarregarCategoria);
        }

        public static Dictionary<Categoria, List<Produto>> CarregarCategoriasProdutos()
        {
            Dictionary<Categoria, List<Produto>> prodcat = new Dictionary<Categoria, List<Produto>>();
            foreach (Categoria c in Categoria.CarregarCategorias())
            {
                prodcat.Add(c, c.CarregarProdutos());
            }
            return prodcat;
        }
    }
}