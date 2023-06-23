using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Data;
using AspNetCore.Models;
using AspNetCore.ViewModels;

namespace AspNetCore.Contexts
{
    public class CondicaoPagtoContext : AppDbContext
    {
        public List<CondicaoPagto> GetCondicoesPagto()
        {
            try
            {
                var sql = @"
                    SELECT
                        ID,
                        DS_CONDICAO_PAGTO,
                        MULTA,
                        JUROS,
                        DESC_FINANCEIRO
                    FROM condicao_pagto";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<CondicaoPagto>();

                while (reader.Read())
                {
                    var condicaoPagto = new CondicaoPagto
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        DsCondicaoPagto = Convert.ToString(reader["DS_CONDICAO_PAGTO"]),
                        Multa = Convert.ToDecimal(reader["MULTA"]),
                        Juros = Convert.ToDecimal(reader["JUROS"]),
                        DescFinanceiro = Convert.ToDecimal(reader["DESC_FINANCEIRO"]),
                    };
                    list.Add(condicaoPagto);
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

        public CondicaoPagto GetCondicaoPagto(int? id)
        {
            try
            {
                var sql = $"SELECT ID, DS_CONDICAO_PAGTO, MULTA, JUROS, DESC_FINANCEIRO, DT_CADASTRO, DT_ULT_ALTERACAO FROM condicao_pagto WHERE Id = {id};";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var condicaoPagto = new CondicaoPagto();
                while (reader.Read())
                {
                    condicaoPagto = new CondicaoPagto()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        DsCondicaoPagto = Convert.ToString(reader["DS_CONDICAO_PAGTO"]),
                        Multa = Convert.ToDecimal(reader["MULTA"]),
                        Juros = Convert.ToDecimal(reader["JUROS"]),
                        DescFinanceiro = Convert.ToDecimal(reader["DESC_FINANCEIRO"]),
                        DataCadastro = Convert.ToDateTime(reader["DT_CADASTRO"]),
                        DataUltAlteracao = Convert.ToDateTime(reader["DT_ULT_ALTERACAO"])
                    };
                }
                return condicaoPagto;

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
        public Boolean CreateCondicaoPagto(CondicaoPagto model)
        {
            try
            {
                var sql = $"INSERT INTO condicao_pagto (DS_CONDICAO_PAGTO, MULTA, JUROS, DESC_FINANCEIRO, DT_CADASTRO, DT_ULT_ALTERACAO) VALUES('{model.DsCondicaoPagto}', '{model.Multa}', '{model.Juros}', '{model.DescFinanceiro}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
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
        public void EditCondicaoPagto(CondicaoPagto model)
        {
            try
            {
                var sql = $"UPDATE condicao_pagto SET DS_CONDICAO_PAGTO = '{model.DsCondicaoPagto}', MULTA = '{model.Multa}', JUROS = '{model.Juros}', DESC_FINANCEIRO = '{model.DescFinanceiro}', DT_ULT_ALTERACAO = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE ID = {model.Id};";
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


        public Boolean DeleteCondicaoPagto(int? id)
        {
            try
            {
                var sql = $"DELETE FROM condicao_pagto WHERE ID = {id};";
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