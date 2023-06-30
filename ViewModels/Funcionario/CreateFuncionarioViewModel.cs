using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class CreateFuncionarioViewModel
{
    public int Id { get; set; }
    public string NmPessoa { get; set; }
    public string Sexo { get; set; }
    public string DsLogradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string TelFixo { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }
    public Cidade cidade { get; set; }
    public string Cep { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public DateTime DataNascimento { get; set; }
    public DateTime DataAdmissao { get; set; }
    public DateTime DataDemissao { get; set; }
    public decimal Salario { get; set; }
}