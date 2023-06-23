using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Data;
using AspNetCore.Models;
using AspNetCore.ViewModels;

namespace AspNetCore.Contexts
{
    public class EstoqueContext : AppDbContext
    {
        public List<Estoque> GetEstoques()
        {
            try
            {
                var sql = @"
                    SELECT
                        a.REFERENCIA,
                        a.ID_PRODUTO,
                        b.DS_PRODUTO,
                        a.ID_COR,
                        c.DS_COR,
                        a.ID_TAMANHO,
                        d.DS_TAMANHO,
                        a.QTD,
                        a.VALOR_COMPRA,
                        a.VALOR_VENDA,
                        a.PERC_VENDA
                    FROM estoque a,
                    produto b,
                    cor c,
                    tamanho d
                    WHERE a.ID_PRODUTO = b.ID
                    AND a.ID_COR = c.ID
                    AND a.ID_TAMANHO = d.ID";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<Estoque>();

                while (reader.Read())
                {
                    var estoque = new Estoque
                    {
                        Referencia = Convert.ToInt32(reader["REFERENCIA"]),
                        produto = new Produto()
                        {
                            Id = Convert.ToInt32(reader["ID_PRODUTO"]),
                            DsProduto = Convert.ToString(reader["DS_PRODUTO"])
                        },
                        cor = new Cor()
                        {
                            Id = Convert.ToInt32(reader["ID_COR"]),
                            DsCor = Convert.ToString(reader["DS_COR"])
                        },
                        tamanho = new Tamanho()
                        {
                            Id = Convert.ToInt32(reader["ID_TAMANHO"]),
                            DsTamanho = Convert.ToString(reader["DS_TAMANHO"])
                        },
                        Qtd = Convert.ToInt32(reader["QTD"]),
                        VlrCompra = Convert.ToDecimal(reader["VALOR_COMPRA"]),
                        VlrVenda = Convert.ToDecimal(reader["VALOR_VENDA"]),
                        PercVenda = Convert.ToDecimal(reader["PERC_VENDA"])
                    };
                    list.Add(estoque);
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

        public Estoque GetEstoque(int? id)
        {
            try
            {
                var sql = $"SELECT a.REFERENCIA, a.ID_PRODUTO, b.DS_PRODUTO, a.ID_COR, c.DS_COR, a.ID_TAMANHO, d.DS_TAMANHO, a.QTD, a.VALOR_COMPRA, a.VALOR_VENDA, a.PERC_VENDA, a.DT_CADASTRO, a.DT_ULT_ALTERACAO FROM estoque a, produto b, cor c, tamanho d WHERE a.REFERENCIA = {id} AND a.ID_PRODUTO = b.ID AND a.ID_COR = c.ID AND a.ID_TAMANHO = d.ID;";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var estoque = new Estoque();
                while (reader.Read())
                {
                    estoque = new Estoque()
                    {
                        Referencia = Convert.ToInt32(reader["REFERENCIA"]),
                        produto = new Produto()
                        {
                            Id = Convert.ToInt32(reader["ID_PRODUTO"]),
                            DsProduto = Convert.ToString(reader["DS_PRODUTO"])
                        },
                        cor = new Cor()
                        {
                            Id = Convert.ToInt32(reader["ID_COR"]),
                            DsCor = Convert.ToString(reader["DS_COR"])
                        },
                        tamanho = new Tamanho()
                        {
                            Id = Convert.ToInt32(reader["ID_TAMANHO"]),
                            DsTamanho = Convert.ToString(reader["DS_TAMANHO"])
                        },
                        Qtd = Convert.ToInt32(reader["QTD"]),
                        VlrCompra = Convert.ToDecimal(reader["VALOR_COMPRA"]),
                        VlrVenda = Convert.ToDecimal(reader["VALOR_VENDA"]),
                        PercVenda = Convert.ToDecimal(reader["PERC_VENDA"]),
                        DataCadastro = Convert.ToDateTime(reader["DT_CADASTRO"]),
                        DataUltAlteracao = Convert.ToDateTime(reader["DT_ULT_ALTERACAO"])
                    };
                }
                return estoque;

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
        public Boolean CreateEstoque(Estoque model)
        {
            try
            {
                var sql = $"INSERT INTO estoque (REFERENCIA, ID_PRODUTO, ID_COR, ID_TAMANHO, QTD, VALOR_COMPRA, VALOR_VENDA, PERC_VENDA, DT_CADASTRO, DT_ULT_ALTERACAO) VALUES('{model.Referencia}', '{model.produto.Id}', '{model.cor.Id}', '{model.tamanho.Id}', '{model.Qtd}', '{model.VlrCompra}', '{model.VlrVenda}', '{model.PercVenda}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
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
        public void EditEstoque(Estoque model)
        {
            try
            {
                var sql = $"UPDATE estoque SET ID_PRODUTO = '{model.produto.Id}', ID_COR = '{model.cor.Id}', ID_TAMANHO = '{model.tamanho.Id}', QTD = '{model.Qtd}', VALOR_COMPRA = '{model.VlrCompra}', VALOR_VENDA = '{model.VlrVenda}', PERC_VENDA = '{model.PercVenda}', DT_ULT_ALTERACAO = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE REFERENCIA = {model.Referencia};";
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


        public Boolean DeleteEstoque(int? id)
        {
            try
            {
                var sql = $"DELETE FROM estoque WHERE Referencia = {id};";
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