using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Data;
using AspNetCore.Models;
using AspNetCore.ViewModels;

namespace AspNetCore.Contexts
{
    public class EstadoContext : AppDbContext
    {
        public List<Estado> GetEstados()
        {
            try
            {
                var sql = @"
                    SELECT
                        a.ID,
                        a.NM_ESTADO,
                        a.UF,
                        a.ID_PAIS,
                        b.NM_PAIS
                    FROM estado a,
                    pais b
                    WHERE a.ID_PAIS = b.ID";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<Estado>();

                while (reader.Read())
                {
                    var estado = new Estado
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        NmEstado = Convert.ToString(reader["NM_ESTADO"]),
                        Uf = Convert.ToString(reader["UF"]),
                        pais = new Pais()
                        {
                            Id = Convert.ToInt32(reader["ID_PAIS"]),
                            NmPais = Convert.ToString(reader["NM_PAIS"])
                        }
                    };
                    list.Add(estado);
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

        public Estado GetEstado(int? id)
        {
            try
            {
                var sql = $"SELECT a.ID, a.NM_ESTADO, a.UF, a.ID_PAIS, b.NM_PAIS, a.DT_CADASTRO, a.DT_ULT_ALTERACAO FROM estado a, pais b WHERE a.Id = {id} and a.ID_PAIS = b.ID;";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var estado = new Estado();
                while (reader.Read())
                {
                    estado = new Estado()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        NmEstado = Convert.ToString(reader["NM_ESTADO"]),
                        Uf = Convert.ToString(reader["UF"]),
                        pais = new Pais()
                        {
                            Id = Convert.ToInt32(reader["ID_PAIS"]),
                            NmPais = Convert.ToString(reader["NM_PAIS"])
                        },
                        DataCadastro = Convert.ToDateTime(reader["DT_CADASTRO"]),
                        DataUltAlteracao = Convert.ToDateTime(reader["DT_ULT_ALTERACAO"])
                    };
                }
                return estado;

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
        public Boolean CreateEstado(Estado model)
        {
            try
            {
                var sql = $"INSERT INTO estado (NM_ESTADO, UF, ID_PAIS, DT_CADASTRO, DT_ULT_ALTERACAO) VALUES('{model.NmEstado}', '{model.Uf}', '{model.pais.Id}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
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
        public void EditEstado(Estado model)
        {
            try
            {
                var sql = $"UPDATE estado SET NM_ESTADO = '{model.NmEstado}', UF = '{model.Uf}', ID_PAIS = '{model.pais.Id}', DT_ULT_ALTERACAO = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE ID = {model.Id};";
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


        public Boolean DeleteEstado(int? id)
        {
            try
            {
                var sql = $"DELETE FROM estado WHERE ID = {id};";
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