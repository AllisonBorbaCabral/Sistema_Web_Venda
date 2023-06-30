using AspNetCore.Models;

namespace AspNetCore
{
    public class Funcionario : Pessoa
    {
        public string Cnh { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataDemissao { get; set; }
        public decimal Salario { get; set; }

        public Funcionario(string nmPessoa, string sexo, string dsLogradouro, string numero, string complemento, string bairro, string telFixo, string celular, string email, Cidade objCidade, string cep, string cpf, string rg, DateTime dtNascimento, DateTime dtAdmissao, DateTime dtDemissao, decimal salario)
        {
            NmPessoa = nmPessoa;
            Sexo = sexo;
            DsLogradouro = dsLogradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            TelFixo = telFixo;
            Celular = celular;
            Email = email;
            cidade = objCidade;
            Cep = cep;
            Cpf = cpf;
            Rg = rg;
            DataNascimento = dtNascimento;
            DataAdmissao = dtAdmissao;
            DataDemissao = dtDemissao;
            Salario = salario;
        }

        public Funcionario()
        {}
    }
}