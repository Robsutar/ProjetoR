using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public List<Produto> CarregarProdutos()
        {
            List<Produto> saida = new List<Produto>();

            SqlConnection conn = new SqlConnection(BancoDeDados.ConnString);
            try {
                SqlCommand comm = new SqlCommand("SELECT * FROM MenuItem WHERE MenuNome = @Nome", conn);
                SqlParameter nomeP = new SqlParameter();
                nomeP.ParameterName = "@Nome";
                nomeP.Value = Nome;
                comm.Parameters.Add(nomeP);

                conn.Open();

                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        saida.Add(Produto.CarregarProduto((int)reader["ProdutoId"]));
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
		public Dictionary<Categoria,List<Produto>> CarregarCategoriasProdutos()
        {
            Dictionary<Categoria, List<Produto>> saida = new Dictionary<Categoria, List<Produto>>();

            List<Produto> produtos = CarregarProdutos(); 

            SqlConnection conn = new SqlConnection(BancoDeDados.ConnString);
            try
            {
                SqlCommand comm = new SqlCommand("SELECT * FROM Categoria", conn);

                conn.Open();

                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categoria c = Categoria.CarregarCategoria(reader,true);
                        List<Produto> cp = new List<Produto>();
                        foreach(Produto p in produtos)
                        {
                            if (p.Categoria == c.Id)
                                cp.Add(p);
                        }
                        //if (cp.Count > 0)
                            saida.Add(c, cp);
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
	}
}