using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Data;
using AspNetCore.Models;
using AspNetCore.ViewModels;

namespace AspNetCore.Contexts
{
    public class GradeTamanhoContext : AppDbContext
    {
        public List<GradeTamanho> GetGradeTamanhos()
        {
            try
            {
                var sql = @"
                    SELECT
                        ID
                    FROM grade_tamanho";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<GradeTamanho>();

                while (reader.Read())
                {
                    var gradeTamanho = new GradeTamanho
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                    };
                    list.Add(gradeTamanho);
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

        public GradeTamanho GetGradeTamanho(int? id)
        {
            try
            {
                var sql = $"SELECT ID, DT_CADASTRO, DT_ULT_ALTERACAO FROM grade_tamanho WHERE Id = {id};";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var gradeTamanho = new GradeTamanho();
                while (reader.Read())
                {
                    gradeTamanho = new GradeTamanho()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        DataCadastro = Convert.ToDateTime(reader["DT_CADASTRO"]),
                        DataUltAlteracao = Convert.ToDateTime(reader["DT_ULT_ALTERACAO"])
                    };
                }
                return gradeTamanho;

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
        public Boolean CreateGradeTamanho(GradeTamanho model)
        {
            try
            {
                var sql = $"INSERT INTO grade_tamanho (DT_CADASTRO, DT_ULT_ALTERACAO) VALUES('{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
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
        public void EditGradeTamanho(GradeTamanho model)
        {
            try
            {
                var sql = $"UPDATE grade_tamanho DT_ULT_ALTERACAO = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE ID = {model.Id};";
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


        public Boolean DeleteGradeTamanho(int? id)
        {
            try
            {
                var sql = $"DELETE FROM grade_tamanho WHERE ID = {id};";
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