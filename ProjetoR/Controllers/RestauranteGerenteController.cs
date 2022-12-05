using ProjetoR.Models.ProjetoR;
using ProjetoR.Models.Seguranca;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoR.Controllers
{
    public class RestauranteGerenteController : Controller
    {
        #region Gerenciador
        public ActionResult Gerenciador()
        {
            if (Usuario.CarregarUsuario(Request) is Usuario.Gerente)
                return View();
            else
                return RedirectToAction("Index","Restaurante");
        }

        private ActionResult GerenciadorLink()
        {
            return RedirectToAction("Gerenciador");
        }

        [HttpPost]
        public ActionResult AdicionarCategoria(string Nome,string Descricao,string Imediato = null)
        {
            bool _imediato = Imediato==null? false : true;

            SqlConnection conn = new SqlConnection(BancoDeDados.ConnString);
            try
            {
                SqlCommand comm = new SqlCommand("INSERT INTO Categoria VALUES (@nome,@descricao,@imediato)", conn);
                SqlParameter pNome = new SqlParameter("@nome", Nome);
                SqlParameter pDescricao = new SqlParameter("@descricao", Descricao);
                SqlParameter pImediato = new SqlParameter("@imediato", _imediato);
                comm.Parameters.Add(pNome);
                comm.Parameters.Add(pDescricao);
                comm.Parameters.Add(pImediato);
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return GerenciadorLink();
        }
        public ActionResult RemoverCategoria(int id)
        {
            SqlConnection conn = new SqlConnection(BancoDeDados.ConnString);
            try
            {
                SqlCommand comm = new SqlCommand("DELETE FROM Categoria WHERE Id = @id", conn);
                SqlParameter pId = new SqlParameter("@id", id);
                comm.Parameters.Add(pId);
                conn.Open();
                comm.ExecuteNonQuery();

                comm.CommandText = "DELETE FROM Produto WHERE Categoria = @id";
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return GerenciadorLink();
        }

        [HttpPost]
        public ActionResult AdicionarProduto(string nome,string descricao,string categoria,string preco) 
        {
            SqlConnection conn = new SqlConnection(BancoDeDados.ConnString);
            try
            {
                SqlCommand comm = new SqlCommand("INSERT INTO Produto VALUES (@nome,@descricao,@categoria,@preco)", conn);
                SqlParameter pNome = new SqlParameter("@nome", nome);
                SqlParameter pDescricao = new SqlParameter("@descricao", descricao);
                SqlParameter pCategoria = new SqlParameter("@categoria", int.Parse(categoria));
                SqlParameter pPreco = new SqlParameter("@preco", decimal.Parse(preco));
                comm.Parameters.Add(pNome);
                comm.Parameters.Add(pDescricao);
                comm.Parameters.Add(pCategoria);
                comm.Parameters.Add(pPreco);
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return GerenciadorLink();
        }
        public ActionResult RemoverProduto(int id)
        {
            SqlConnection conn = new SqlConnection(BancoDeDados.ConnString);
            try
            {
                SqlCommand comm = new SqlCommand("DELETE FROM Produto WHERE Id = @id", conn);
                SqlParameter pId = new SqlParameter("@id", id);
                comm.Parameters.Add(pId);
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return GerenciadorLink();
        }
        #endregion


        #region Menu
        public ActionResult MenuLink()
        {
            return RedirectToAction("Menu", "Restaurante");
        }
        public ActionResult MenuRemoverProduto(string id)
        {
            SqlConnection conn = new SqlConnection(BancoDeDados.ConnString);
            try
            {
                SqlCommand comm = new SqlCommand("DELETE FROM MenuItem WHERE ProdutoId = @id", conn);
                SqlParameter pId = new SqlParameter("@id", int.Parse(id));
                comm.Parameters.Add(pId);
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return MenuLink();

        }
        [HttpPost]
        public ActionResult MenuAdicionarProduto(string id)
        {
            SqlConnection conn = new SqlConnection(BancoDeDados.ConnString);
            try
            {
                SqlCommand comm = new SqlCommand("INSERT INTO MenuItem Values(@menuNome,@produtoId)", conn);
                SqlParameter pProdutoId = new SqlParameter("@produtoId",int.Parse(id));
                SqlParameter pMenuNome = new SqlParameter("@menuNome", RestauranteController.MenuAtivo.Nome);
                comm.Parameters.Add(pProdutoId);
                comm.Parameters.Add(pMenuNome);
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return MenuLink();
        }
        #endregion
    }
}