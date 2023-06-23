using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Data;
using AspNetCore.Models;
using AspNetCore.ViewModels;

namespace AspNetCore.Contexts
{
    public class TamanhoContext : AppDbContext
    {
        public List<Tamanho> GetTamanhos()
        {
            try
            {
                var sql = @"
                    SELECT
                        ID,
                        DS_TAMANHO
                    FROM tamanho;";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<Tamanho>();

                while (reader.Read())
                {
                    var tamanho = new Tamanho
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        DsTamanho = Convert.ToString(reader["DS_TAMANHO"])
                    };
                    list.Add(tamanho);
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

        public Tamanho GetTamanho(int? id)
        {
            try
            {
                var sql = $"SELECT ID, DS_TAMANHO, DT_CADASTRO, DT_ULT_ALTERACAO FROM tamanho WHERE ID = {id};";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var tamanho = new Tamanho();
                while (reader.Read())
                {
                    tamanho = new Tamanho()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        DsTamanho = Convert.ToString(reader["DS_TAMANHO"]),
                        DataCadastro = Convert.ToDateTime(reader["DT_CADASTRO"]),
                        DataUltAlteracao = Convert.ToDateTime(reader["DT_ULT_ALTERACAO"])
                    };
                }
                return tamanho;

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
        public Boolean CreateTamanho(Tamanho model)
        {
            try
            {
                var sql = $"INSERT INTO tamanho (DS_TAMANHO, DT_CADASTRO, DT_ULT_ALTERACAO) VALUES('{model.DsTamanho}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
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
        public void EditTamanho(Tamanho model)
        {
            try
            {
                var sql = $"UPDATE tamanho SET DS_TAMANHO = '{model.DsTamanho}', DT_ULT_ALTERACAO = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE ID = {model.Id};";
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


        public Boolean DeleteTamanho(int? id)
        {
            try
            {
                var sql = $"DELETE FROM tamanho WHERE ID = {id};";
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