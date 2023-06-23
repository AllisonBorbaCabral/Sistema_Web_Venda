using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Data;
using AspNetCore.Models;
using AspNetCore.ViewModels;

namespace AspNetCore.Contexts
{
    public class ProdutoContext : AppDbContext
    {
        public List<Produto> GetProdutos()
        {
            try
            {
                var sql = @"
                    SELECT
                        ID,
                        DS_PRODUTO,
                        NCM,
                        UND
                    FROM produto";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<Produto>();

                while (reader.Read())
                {
                    var produto = new Produto
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        DsProduto = Convert.ToString(reader["DS_PRODUTO"]),
                        Ncm = Convert.ToInt32(reader["NCM"]),
                        Und = Convert.ToString(reader["UND"]),
                    };
                    list.Add(produto);
                }
                return list;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            finally
            {
                CloseConn();
            }
        }

        public Produto GetProduto(int? id)
        {
            try
            {
                var sql = $"SELECT ID, DS_PRODUTO, NCM, UND, ID_GRADE_COR, ID_GRADE_TAMANHO, DT_CADASTRO, DT_ULT_ALTERACAO FROM produto WHERE Id = {id};";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var produto = new Produto();
                while (reader.Read())
                {
                    produto = new Produto()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        DsProduto = Convert.ToString(reader["DS_PRODUTO"]),
                        Ncm = Convert.ToInt32(reader["NCM"]),
                        Und = Convert.ToString(reader["UND"]),
                        gradeCor = new GradeCor()
                        {
                            Id = Convert.ToInt32(reader["ID_GRADE_COR"])
                        },
                        gradeTamanho = new GradeTamanho()
                        {
                            Id = Convert.ToInt32(reader["ID_GRADE_TAMANHO"])
                        },
                        DataCadastro = Convert.ToDateTime(reader["DT_CADASTRO"]),
                        DataUltAlteracao = Convert.ToDateTime(reader["DT_ULT_ALTERACAO"])
                    };
                }
                return produto;

            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            finally
            {
                CloseConn();
            }
        }
        public Boolean CreateProduto(Produto model)
        {
            try
            {
                var sql = $"INSERT INTO produto (DS_PRODUTO, NCM, UND, ID_GRADE_COR, ID_GRADE_TAMANHO, DT_CADASTRO, DT_ULT_ALTERACAO) VALUES('{model.DsProduto}', '{model.Ncm}', '{model.Und}', '{model.gradeCor.Id}', '{model.gradeTamanho.Id}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                qy.ExecuteNonQuery();
                return true;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            finally
            {
                CloseConn();
            }
        }
        public void EditProduto(Produto model)
        {
            try
            {
                var sql = $"UPDATE produto SET DS_PRODUTO = '{model.DsProduto}', NCM = '{model.Ncm}', UND = '{model.Und}', ID_GRADE_COR = '{model.gradeCor.Id}', ID_GRADE_TAMANHO = '{model.gradeTamanho.Id}', DT_ULT_ALTERACAO = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE ID = {model.Id};";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                qy.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            finally
            {
                CloseConn();
            }
        }


        public Boolean DeleteProduto(int? id)
        {
            try
            {
                var sql = $"DELETE FROM produto WHERE ID = {id};";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                qy.ExecuteNonQuery();
                return true;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            finally
            {
                CloseConn();
            }
        }
    }
}