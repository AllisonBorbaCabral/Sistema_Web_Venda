using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Data;
using AspNetCore.Models;
using AspNetCore.ViewModels;

namespace AspNetCore.Contexts
{
    public class GradeCorContext : AppDbContext
    {
        public List<GradeCor> GetGradeCores()
        {
            try
            {
                var sql = @"
                    SELECT
                        ID
                    FROM grade_cor";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<GradeCor>();

                while (reader.Read())
                {
                    var gradeCor = new GradeCor
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                    };
                    list.Add(gradeCor);
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

        public GradeCor GetGradeCor(int? id)
        {
            try
            {
                var sql = $"SELECT ID, DT_CADASTRO, DT_ULT_ALTERACAO FROM grade_cor WHERE Id = {id};";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var gradeCor = new GradeCor();
                while (reader.Read())
                {
                    gradeCor = new GradeCor()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        DataCadastro = Convert.ToDateTime(reader["DT_CADASTRO"]),
                        DataUltAlteracao = Convert.ToDateTime(reader["DT_ULT_ALTERACAO"])
                    };
                }
                return gradeCor;

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
        public Boolean CreateGradeCor(GradeCor model)
        {
            try
            {
                var sql = $"INSERT INTO grade_cor (DT_CADASTRO, DT_ULT_ALTERACAO) VALUES('{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
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
        public void EditGradeCor(GradeCor model)
        {
            try
            {
                var sql = $"UPDATE grade_cor DT_ULT_ALTERACAO = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE ID = {model.Id};";
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


        public Boolean DeleteGradeCor(int? id)
        {
            try
            {
                var sql = $"DELETE FROM grade_cor WHERE ID = {id};";
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