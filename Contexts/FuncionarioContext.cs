using MySqlConnector;
using AspNetCore.Models;

namespace AspNetCore.Contexts
{

    public class FuncionarioContext : AppDbContext
    {
        public List<Funcionario> GetFuncionarios()
        {
            try
            {
                var sql = @"
                    SELECT
                        a.ID,
                        a.NM_FUNCIONARIO,
                        a.SEXO, 
                        a.LOGRADOURO, 
                        a.NUMERO,
                        a.COMPLEMENTO,
                        a.BAIRRO,
                        a.TELEFONE,
                        a.CELULAR,
                        a.EMAIL,
                        a.ID_CIDADE,
                        b.NM_CIDADE,
                        a.CEP,
                        a.CPF,
                        a.RG,
                        a.DT_NASCIMENTO,
                        a.DT_ADMISSAO,
                        a.DT_DEMISSAO,
                        a.SALARIO,
                        a.DT_CADASTRO,
                        a.DT_ULT_ALTERACAO
                    FROM funcionario a,
                         cidade b
                    WHERE a.ID_CIDADE = b.ID
                ";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var list = new List<Funcionario>();

                while (reader.Read())
                {
                    var funcionario = new Funcionario
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        NmPessoa = Convert.ToString(reader["NM_FUNCIONARIO"]),
                        Sexo = Convert.ToString(reader["SEXO"]),
                        DsLogradouro = Convert.ToString(reader["LOGRADOURO"]),
                        Numero = Convert.ToString(reader["NUMERO"]),
                        Complemento = Convert.ToString(reader["COMPLEMENTO"]),
                        Bairro = Convert.ToString(reader["BAIRRO"]),
                        TelFixo = Convert.ToString(reader["TELEFONE"]),
                        Celular = Convert.ToString(reader["CELULAR"]),
                        Email = Convert.ToString(reader["EMAIL"]),
                        cidade = new Cidade 
                        {
                            Id = Convert.ToInt32(reader["ID_CIDADE"]),
                            NmCidade = Convert.ToString(reader["NM_CIDADE"])
                        },
                        Cep = Convert.ToString(reader["CEP"]),
                        Cpf = Convert.ToString(reader["CPF"]),
                        Rg = Convert.ToString(reader["RG"]),
                        DataNascimento = Convert.ToDateTime(reader["DT_NASCIMENTO"]),
                        DataAdmissao = Convert.ToDateTime(reader["DT_ADMISSAO"]),
                        DataDemissao = Convert.ToDateTime(reader["DT_DEMISSAO"]),
                        Salario = Convert.ToDecimal(reader["SALARIO"]),
                        DataCadastro = Convert.ToDateTime(reader["DT_CADASTRO"]),
                        DataUltAlteracao = Convert.ToDateTime(reader["DT_ULT_ALTERACAO"])
                    };
                    list.Add(funcionario);
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

        public Funcionario GetFuncionario(int? id)
        {
            try
            {
                var sql = $"SELECT a.ID, a.NM_FUNCIONARIO, a.SEXO, a.LOGRADOURO, a.NUMERO, a.COMPLEMENTO,a.BAIRRO, a.TELEFONE, a.CELULAR, a.EMAIL, a.ID_CIDADE, b.NM_CIDADE, a.CEP, a.CPF, a.RG, a.DT_NASCIMENTO, a.DT_ADMISSAO, a.DT_DEMISSAO, a.SALARIO, a.DT_CADASTRO, a.DT_ULT_ALTERACAO FROM funcionario a, cidade b WHERE a.ID_CIDADE = b.ID AND a.ID = {id}";
                OpenConn();
                qy = new MySqlCommand(sql, conn);
                reader = qy.ExecuteReader();
                var funcionario = new Funcionario();
                while (reader.Read())
                {
                    funcionario = new Funcionario()
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        NmPessoa = Convert.ToString(reader["NM_FUNCIONARIO"]),
                        Sexo = Convert.ToString(reader["SEXO"]),
                        DsLogradouro = Convert.ToString(reader["LOGRADOURO"]),
                        Numero = Convert.ToString(reader["NUMERO"]),
                        Complemento = Convert.ToString(reader["COMPLEMENTO"]),
                        Bairro = Convert.ToString(reader["BAIRRO"]),
                        TelFixo = Convert.ToString(reader["TELEFONE"]),
                        Celular = Convert.ToString(reader["CELULAR"]),
                        Email = Convert.ToString(reader["EMAIL"]),
                        cidade = new Cidade 
                        {
                            Id = Convert.ToInt32(reader["ID_CIDADE"]),
                            NmCidade = Convert.ToString(reader["NM_CIDADE"])
                        },
                        Cep = Convert.ToString(reader["CEP"]),
                        Cpf = Convert.ToString(reader["CPF"]),
                        Rg = Convert.ToString(reader["RG"]),
                        DataNascimento = Convert.ToDateTime(reader["DT_NASCIMENTO"]),
                        DataAdmissao = Convert.ToDateTime(reader["DT_ADMISSAO"]),
                        DataDemissao = Convert.ToDateTime(reader["DT_DEMISSAO"]),
                        Salario = Convert.ToDecimal(reader["SALARIO"]),
                        DataCadastro = Convert.ToDateTime(reader["DT_CADASTRO"]),
                        DataUltAlteracao = Convert.ToDateTime(reader["DT_ULT_ALTERACAO"])
                    };
                }
                return funcionario;
                
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

        public Boolean CreateFuncionario(Funcionario model)
        {
            try
            {
                var sql = $"INSERT INTO funcionario (NM_FUNCIONARIO, SEXO, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, TELEFONE, CELULAR, EMAIL, ID_CIDADE, CEP, CPF, RG, DT_NASCIMENTO, DT_ADMISSAO, DT_DEMISSAO, SALARIO, DT_CADASTRO, DT_ULT_ALTERACAO) VALUES('{model.NmPessoa}', '{model.Sexo}', '{model.DsLogradouro}', '{model.Numero}', '{model.Complemento}', '{model.Bairro}', '{model.TelFixo}', '{model.Celular}', '{model.Email}', '{model.cidade.Id}', '{model.Cep}', '{model.Cpf}', '{model.Rg}', '{model.DataNascimento}', '{model.DataAdmissao}', '{model.DataDemissao}', '{model.Salario}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";
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

        public void EditFuncionario(Funcionario model)
        {
            try
            {
                var sql = $"UPDATE funcionario SET NM_FUNCIONARIO = '{model.NmPessoa}', SEXO = '{model.Sexo}', LOGRADOURO = '{model.DsLogradouro}', NUMERO = '{model.Numero}', COMPLEMENTO = '{model.Complemento}', BAIRRO = '{model.Bairro}', TELEFONE = '{model.TelFixo}', CELULAR = '{model.Celular}', EMAIL = '{model.Email}', ID_CIDADE = '{model.cidade.Id}', CEP = '{model.Cep}', CPF = '{model.Cpf}', RG = '{model.Rg}', DT_NASCIMENTO = '{model.DataNascimento}', DT_ADMISSAO = '{model.DataAdmissao}', DT_DEMISSAO = '{model.DataDemissao}', SALARIO = '{model.Salario}', DT_ULT_ALTERACAO = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE ID = {model.Id};";
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

        public Boolean DeleteFuncionario(int? id)
        {
            try
            {
                var sql = $"DELETE FROM funcionario WHERE ID = {id};";
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