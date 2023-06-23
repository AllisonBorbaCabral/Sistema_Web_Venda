using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Data;
using AspNetCore.Models;
using AspNetCore.ViewModels;

namespace AspNetCore.Contexts
{
    public class TamanhoGradeContext : AppDbContext
    {
        public List<TamanhoGrade> GetTamanhosGrade()
        {
            try
            {
                var sql = @"
                    SELECT
                        a.ID_TAMANHO,
                        a.ID_GRADE_TAMANHO,
                        b.DS_TAMANHO
                    FROM tamanho_grade a,
                    tamanho b,
                    grade_tamanho c
                    WHERE a.ID_TAMANHO = b.ID
                    AND a.ID_GRADE_TAMANHO = c.ID;";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<TamanhoGrade>();

                while (reader.Read())
                {
                    var tamanhoGrade = new TamanhoGrade
                    {
                        tamanho = new Tamanho {
                            Id = Convert.ToInt32(reader["ID_TAMANHO"]),
                            DsTamanho = Convert.ToString(reader["DS_TAMANHO"])
                        },
                        gradeTamanho = new GradeTamanho {
                            Id = Convert.ToInt32(reader["ID_GRADE_TAMANHO"])
                        }
                        
                    };
                    list.Add(tamanhoGrade);
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

        public TamanhoGrade GetTamanhoGrade(int? idTamanho, int? idGradeTamanho)
        {
            try
            {
                var sql = $"SELECT a.ID_TAMANHO, b.DS_TAMANHO, a.ID_GRADE_TAMANHO FROM tamanho_grade a, tamanho b WHERE a.ID_TAMANHO = {idTamanho} AND a.ID_GRADE_TAMANHO = {idGradeTamanho}, AND a.ID_TAMANHO = b.ID;";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var tamanhoGrade = new TamanhoGrade();
                while (reader.Read())
                {
                    tamanhoGrade = new TamanhoGrade()
                    {
                        tamanho = new Tamanho() 
                        {
                            Id = Convert.ToInt32(reader["ID_TAMANHO"]),
                            DsTamanho = Convert.ToString(reader["DS_TAMANHO"])
                        },
                        gradeTamanho = new GradeTamanho() 
                        {
                            Id = Convert.ToInt32(reader["ID_GRADE_TAMANHO"]),
                        }
                    };
                }
                return tamanhoGrade;

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
        public Boolean CreateTamanhoGrade(TamanhoGrade model)
        {
            try
            {
                var sql = $"INSERT INTO tamanho_grade (ID_TAMANHO, ID_GRADE_TAMANHO) VALUES({model.tamanho.Id}, {model.gradeTamanho.Id});";
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
        public void EditTamanhoGrade(TamanhoGrade model)
        {
            try
            {
                var sql = $"UPDATE tamanho_grade ID_TAMANHO = {model.tamanho.Id}, ID_GRADE_TAMANHO = {model.gradeTamanho.Id} WHERE ID_TAMANHO = {model.tamanho.Id} AND ID_GRADE_TAMANHO = {model.gradeTamanho.Id};";
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


        public Boolean DeleteTamanhoGrade(int? idTamanho, int? idGradeTamanho)
        {
            try
            {
                var sql = $"DELETE FROM tamanho_grade WHERE ID_TAMANHO = {idTamanho} AND ID_GRADE_TAMANHO = {idGradeTamanho};";
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