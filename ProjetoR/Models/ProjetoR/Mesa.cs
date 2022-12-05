using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public static Mesa CarregarMesa(SqlDataReader reader, bool readed)
        {
            if (!readed)
                if (!reader.Read())
                    throw new NotImplementedException();
            return new Mesa((int)reader["Id"], (bool)reader["Ocupada"]);
        }
        public static Mesa CarregarMesa(int id)
        {
            return BancoDeDados.Carregar(id,CarregarMesa);
        }

        public static void Recriar(int quantidadeMesas)
        {
            BancoDeDados.DeletarTudo<Mesa>();
            BancoDeDados.ReniciarAutoIncrement<Mesa>();
            for(int i = 0; i < quantidadeMesas; i++)
            {
                BancoDeDados.Inserir<Mesa>(new List<object>() { false }) ;
            }
        }

        public void AtualizarOcupacao(bool ocupada)
        {
            Ocupada = ocupada;
            var dict = new Dictionary<string, object>();
            dict.Add("Ocupada", ocupada ? 1 : 0);
            BancoDeDados.Atualizar<Mesa>(Id, dict );
        }
    }
}