using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using AspNetCore.Models;
using AspNetCore.ViewModels;

namespace AspNetCore.Contexts
{
    public class PaisContext : AppDbContext
    {
        public List<Pais> GetPaises()
        {
            try
            {
                var sql = @"
                    SELECT
                        ID,
                        NMPAIS,
                        SIGLA,
                        DDI
                    FROM pais";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<Pais>();

                while (reader.Read())
                {
                    var pais = new Pais
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        NmPais = Convert.ToString(reader["NMPAIS"]),
                        SiglaPais = Convert.ToString(reader["SIGLA"]),
                        DdiPais = Convert.ToString(reader["DDI"])
                    };
                    list.Add(pais);
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

        public Pais GetPais(int? id)
        {
            try
            {
                var sql = $"SELECT ID, NMPAIS, SIGLA, DDI, DTCADASTRO, DTULTALTERACAO FROM pais WHERE Id = {id}";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var pais = new Pais();
                while (reader.Read())
                {
                    pais = new Pais()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        NmPais = Convert.ToString(reader["NMPAIS"]),
                        SiglaPais = Convert.ToString(reader["SIGLA"]),
                        DdiPais = Convert.ToString(reader["DDI"]),
                        DataCadastro = Convert.ToDateTime(reader["DTCADASTRO"]),
                        DataUltAlteracao = Convert.ToDateTime(reader["DTULTALTERACAO"])
                    };
                }
                return pais;

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
        public Boolean CreatePais(Pais model)
        {
            try
            {
                var sql = $"INSERT INTO pais (NMPAIS, SIGLA, DDI, DTCADASTRO, DTULTALTERACAO) VALUES('{model.NmPais}', '{model.SiglaPais}', '{model.DdiPais}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
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
        public void EditPais(Pais model)
        {
            try
            {
                var sql = $"UPDATE pais SET NMPAIS = '{model.NmPais}', SIGLA = '{model.SiglaPais}', DDI = '{model.DdiPais}', DTULTALTERACAO = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE ID = {model.Id};";
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


        public Boolean DeletePais(int? id)
        {
            try
            {
                var sql = $"DELETE FROM pais WHERE ID = {id};";
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