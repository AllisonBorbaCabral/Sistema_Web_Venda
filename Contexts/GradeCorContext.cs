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
                        a.ID,
                        a.DS_GRADE,
                        b.ID,
                        b.DS_COR
                    FROM grade_cor a,
                    cor b, cor_grade c
                    WHERE a.ID = c.ID_GRADE_COR
                    AND b.ID = c.ID_COR";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<GradeCor>();
                while (reader.Read())
                {                    
                    var gradeCor = new GradeCor
                    {
                        Id = Convert.ToInt32(reader["a.ID"]),
                        Descricao = Convert.ToString(reader["a.DS_GRADE"]),
                        Cores = new List<Cor>()
                    };
                    var cor = new Cor
                    {
                        Id = Convert.ToInt32(reader["b.ID"]),
                        DsCor = Convert.ToString(reader["b.DS_COR"])
                    };
                    gradeCor.Cores.Add(cor);
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