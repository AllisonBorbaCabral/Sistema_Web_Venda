using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using System.Data;
using AspNetCore.Models;
using AspNetCore.ViewModels;

namespace AspNetCore.Contexts
{
    public class CidadeContext : AppDbContext
    {
        public List<Cidade> GetCidades()
        {
            try
            {
                var sql = @"
                    SELECT
                        a.ID,
                        a.NM_CIDADE,
                        a.DDD,
                        a.ID_ESTADO,
                        b.NM_ESTADO
                    FROM cidade a,
                    estado b
                    WHERE a.ID_ESTADO = b.ID";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<Cidade>();

                while (reader.Read())
                {
                    var cidade = new Cidade
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        NmCidade = Convert.ToString(reader["NM_CIDADE"]),
                        Ddd = Convert.ToString(reader["DDD"]),
                        estado = new Estado()
                        {
                            Id = Convert.ToInt32(reader["ID_ESTADO"]),
                            NmEstado = Convert.ToString(reader["NM_ESTADO"])
                        }
                    };
                    list.Add(cidade);
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

        public Cidade GetCidade(int? id)
        {
            try
            {
                var sql = $"SELECT a.ID, a.NM_CIDADE, a.DDD, a.ID_ESTADO, b.NM_ESTADO, a.DT_CADASTRO, a.DT_ULT_ALTERACAO FROM cidade a, estado b WHERE a.Id = {id} and a.ID_ESTADO = b.ID;";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var cidade = new Cidade();
                while (reader.Read())
                {
                    cidade = new Cidade()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        NmCidade = Convert.ToString(reader["NM_CIDADE"]),
                        Ddd = Convert.ToString(reader["DDD"]),
                        estado = new Estado()
                        {
                            Id = Convert.ToInt32(reader["ID_ESTADO"]),
                            NmEstado = Convert.ToString(reader["NM_ESTADO"])
                        },
                        DataCadastro = Convert.ToDateTime(reader["DT_CADASTRO"]),
                        DataUltAlteracao = Convert.ToDateTime(reader["DT_ULT_ALTERACAO"])
                    };
                }
                return cidade;

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
        public Boolean CreateCidade(Cidade model)
        {
            try
            {
                var sql = $"INSERT INTO cidade (NM_CIDADE, DDD, ID_ESTADO, DT_CADASTRO, DT_ULT_ALTERACAO) VALUES('{model.NmCidade}', '{model.Ddd}', '{model.estado.Id}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
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
        public void EditCidade(Cidade model)
        {
            try
            {
                var sql = $"UPDATE cidade SET NM_CIDADE = '{model.NmCidade}', DDD = '{model.Ddd}', ID_ESTADO = '{model.estado.Id}', DT_ULT_ALTERACAO = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE ID = {model.Id};";
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


        public Boolean DeleteCidade(int? id)
        {
            try
            {
                var sql = $"DELETE FROM cidade WHERE ID = {id};";
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