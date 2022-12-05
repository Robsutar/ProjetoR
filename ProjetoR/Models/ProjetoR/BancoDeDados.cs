using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.ProjetoR
{
    public static class BancoDeDados
    {
        public static string ConnString =
            @"Data Source = DESKTOP-FKR1AFA;
            Initial Catalog = ProjetoR; 
            Integrated Security = True;"
        ;

        public static int ExecucaoSimples(SqlCommand comm)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            try
            {
                comm.Connection = conn;

                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public static int ExecucaoEscalarSimples(SqlCommand comm)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            try
            {
                comm.Connection = conn;
                conn.Open();

                object escalar = comm.ExecuteScalar();
                return (int)escalar;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static int ReniciarAutoIncrement<T>()
        {
            return ExecucaoSimples(new SqlCommand("DBCC CHECKIDENT (" + typeof(T).Name+ ", RESEED, 0)"));
        }
        public static T Carregar<T>(int id, Func<SqlDataReader, bool,T> func)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            try
            {
                SqlCommand comm = new SqlCommand("SELECT * FROM " + typeof(T).Name + " WHERE Id = @id", conn);
                SqlParameter pId = new SqlParameter("@id", id);
                comm.Parameters.Add(pId);

                conn.Open();

                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    return func(reader,false);
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
        }

        public static List<T> CarregarLista<T>(Func<SqlDataReader,bool, T> func)
        {
            SqlCommand comm = new SqlCommand("SELECT * FROM " + typeof(T).Name);
            return CarregarLista(comm, func);
        }

        public static List<T> CarregarLista<T>(SqlCommand comm,Func<SqlDataReader,bool ,T> func)
        {
            List<T> saida = new List<T>();
            SqlConnection conn = new SqlConnection(ConnString);
            try
            {
                comm.Connection = conn;

                conn.Open();

                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        saida.Add(func(reader,true));
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

        public static int Atualizar<T>(int id, Dictionary<string,object> values)
        {
            string setStatement = " SET ";
            SqlCommand comm = new SqlCommand("");
            foreach(var so in values)
            {
                setStatement += so.Key + " = " + so.Value+", ";
            }
            setStatement = setStatement.Substring(0, setStatement.Length - 2);
            comm.CommandText = "UPDATE " + typeof(T).Name + setStatement+ " WHERE Id = @id";
            comm.Parameters.Add(new SqlParameter("@id", id));
            return ExecucaoSimples(comm);
        }
        public static int Inserir<T>(List<object> values)
        {
            SqlCommand comm = new SqlCommand("INSERT INTO " + typeof(T).Name + " VALUES(");

            for (int i = 0; i < values.Count; i++)
            {
                comm.CommandText += "@" + i + ",";
                comm.Parameters.Add(new SqlParameter("@" + i, values[i]));
            }
            comm.CommandText = comm.CommandText.Substring(0, comm.CommandText.Length - 1) + ")";
            return ExecucaoSimples(comm);
        }
        public static int InserirEscalar<T>(List<object> values)
        {
            SqlCommand comm = new SqlCommand("INSERT INTO " + typeof(T).Name + " VALUES(");

            for (int i = 0; i < values.Count; i++)
            {
                comm.CommandText += "@" + i + ",";
                comm.Parameters.Add(new SqlParameter("@" + i, values[i]));
            }
            comm.CommandText = comm.CommandText.Substring(0, comm.CommandText.Length - 1) +
                "); SELECT CAST(scope_identity() AS int)";
            return ExecucaoEscalarSimples(comm);
        }

        public static int DeletarTudo<T>()
        {
            return ExecucaoSimples(new SqlCommand("DELETE FROM " + typeof(T).Name));
        }
        public static int Deletar<T>(int id)
        {
            SqlCommand comm = new SqlCommand("DELETE FROM " + typeof(T).Name + 
                " WHERE Id = @id");
            comm.Parameters.Add(new SqlParameter("@id",id));
            return ExecucaoSimples(comm);
        }
    }
}