using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Data;
using AspNetCore.Models;
using AspNetCore.ViewModels;

namespace AspNetCore.Contexts
{
    public class CorGradeContext : AppDbContext
    {
        public List<CorGrade> GetCoresGrade()
        {
            try
            {
                var sql = @"
                    SELECT
                        a.ID_COR,
                        a.ID_GRADE_COR,
                        b.DS_COR
                    FROM cor_grade a,
                    cor b,
                    grade_cor c
                    WHERE a.ID_COR = b.ID
                    AND a.ID_GRADE_COR = c.ID;";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<CorGrade>();

                while (reader.Read())
                {
                    var corGrade = new CorGrade
                    {
                        cor = new Cor {
                            Id = Convert.ToInt32(reader["ID_COR"]),
                            DsCor = Convert.ToString(reader["DS_COR"])
                        },
                        gradeCor = new GradeCor {
                            Id = Convert.ToInt32(reader["ID_GRADE_COR"])
                        }
                        
                    };
                    list.Add(corGrade);
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

        public CorGrade GetCorGrade(int? idCor, int? idGradeCor)
        {
            try
            {
                var sql = $"SELECT a.ID_COR, b.DS_COR, a.ID_GRADE_COR FROM cor_grade a, cor b WHERE a.ID_COR = {idCor} AND a.ID_GRADE_COR = {idGradeCor}, AND a.ID_COR = b.ID;";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var corGrade = new CorGrade();
                while (reader.Read())
                {
                    corGrade = new CorGrade()
                    {
                        cor = new Cor() 
                        {
                            Id = Convert.ToInt32(reader["ID_COR"]),
                            DsCor = Convert.ToString(reader["DS_COR"])
                        },
                        gradeCor = new GradeCor() 
                        {
                            Id = Convert.ToInt32(reader["ID_GRADE_COR"]),
                        }
                    };
                }
                return corGrade;

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
        public Boolean CreateCorGrade(CorGrade model)
        {
            try
            {
                var sql = $"INSERT INTO cor_grade (ID_COR, ID_GRADE_COR) VALUES({model.cor.Id}, {model.gradeCor.Id});";
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
        public void EditCorGrade(CorGrade model)
        {
            try
            {
                var sql = $"UPDATE cor_grade ID_COR = {model.cor.Id}, ID_GRADE_COR = {model.gradeCor.Id} WHERE ID_COR = {model.cor.Id} AND ID_GRADE_COR = {model.gradeCor.Id};";
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


        public Boolean DeleteCorGrade(int? idCor, int? idGradeCor)
        {
            try
            {
                var sql = $"DELETE FROM cor_grade WHERE ID_COR = {idCor} AND ID_GRADE_COR = {idGradeCor};";
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