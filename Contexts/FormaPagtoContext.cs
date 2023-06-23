using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Data;
using AspNetCore.Models;
using AspNetCore.ViewModels;

namespace AspNetCore.Contexts
{
    public class FormaPagtoContext : AppDbContext
    {
        public List<FormaPagto> GetFormasPagto()
        {
            try
            {
                var sql = @"
                    SELECT
                        ID,
                        DS_FORMA_PAGTO
                    FROM forma_pagto";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<FormaPagto>();

                while (reader.Read())
                {
                    var formaPagto = new FormaPagto
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        DsFormaPagto = Convert.ToString(reader["DS_FORMA_PAGTO"]),
                    };
                    list.Add(formaPagto);
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

        public FormaPagto GetFormaPagto(int? id)
        {
            try
            {
                var sql = $"SELECT ID, DS_FORMA_PAGTO, DT_CADASTRO, DT_ULT_ALTERACAO FROM forma_pagto WHERE Id = {id};";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var formaPagto = new FormaPagto();
                while (reader.Read())
                {
                    formaPagto = new FormaPagto()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        DsFormaPagto = Convert.ToString(reader["DS_FORMA_PAGTO"]),
                        DataCadastro = Convert.ToDateTime(reader["DT_CADASTRO"]),
                        DataUltAlteracao = Convert.ToDateTime(reader["DT_ULT_ALTERACAO"])
                    };
                }
                return formaPagto;

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
        public Boolean CreateFormaPagto(FormaPagto model)
        {
            try
            {
                var sql = $"INSERT INTO forma_pagto (DS_FORMA_PAGTO, DT_CADASTRO, DT_ULT_ALTERACAO) VALUES('{model.DsFormaPagto}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
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
        public void EditFormaPagto(FormaPagto model)
        {
            try
            {
                var sql = $"UPDATE forma_pagto SET DS_FORMA_PAGTO = '{model.DsFormaPagto}', DT_ULT_ALTERACAO = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE ID = {model.Id};";
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


        public Boolean DeleteFormaPagto(int? id)
        {
            try
            {
                var sql = $"DELETE FROM forma_pagto WHERE ID = {id};";
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