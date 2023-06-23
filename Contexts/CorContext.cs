using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Data;
using AspNetCore.Models;
using AspNetCore.ViewModels;

namespace AspNetCore.Contexts
{
    public class CorContext : AppDbContext
    {
        public List<Cor> GetCores()
        {
            try
            {
                var sql = @"
                    SELECT
                        ID,
                        DS_COR
                    FROM cor";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<Cor>();

                while (reader.Read())
                {
                    var cor = new Cor
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        DsCor = Convert.ToString(reader["DS_COR"]),
                    };
                    list.Add(cor);
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

        public Cor GetCor(int? id)
        {
            try
            {
                var sql = $"SELECT ID, DS_COR, DT_CADASTRO, DT_ULT_ALTERACAO FROM cor WHERE Id = {id};";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var cor = new Cor();
                while (reader.Read())
                {
                    cor = new Cor()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        DsCor = Convert.ToString(reader["DS_COR"]),
                        DataCadastro = Convert.ToDateTime(reader["DT_CADASTRO"]),
                        DataUltAlteracao = Convert.ToDateTime(reader["DT_ULT_ALTERACAO"])
                    };
                }
                return cor;

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
        public Boolean CreateCor(Cor model)
        {
            try
            {
                var sql = $"INSERT INTO cor (DS_COR, DT_CADASTRO, DT_ULT_ALTERACAO) VALUES('{model.DsCor}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
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
        public void EditCor(Cor model)
        {
            try
            {
                var sql = $"UPDATE cor SET DS_COR = '{model.DsCor}', DT_ULT_ALTERACAO = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE ID = {model.Id};";
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


        public Boolean DeleteCor(int? id)
        {
            try
            {
                var sql = $"DELETE FROM cor WHERE ID = {id};";
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