using System.ComponentModel.DataAnnotations;
using AspNetCore.Models;
namespace AspNetCore.ViewModels;

public class ModalFuncionarioViewModel
{
    [Display(Name = "Código")]
    public int Id { get; set; }
    [Display(Name = "Nome")]
    public string NmPessoa { get; set; } = string.Empty;
    [Display(Name = "Sexo")]
    public string Sexo { get; set; } = string.Empty;
    [Display(Name = "Logradouro")]
    public string DsLogradouro { get; set; } = string.Empty;
    [Display(Name = "Numero")]
    public string Numero { get; set; } = string.Empty;
    [Display(Name = "Complemento")]
    public string Complemento { get; set; } = string.Empty;
    [Display(Name = "Bairro")]
    public string Bairro { get; set; } = string.Empty;
    [Display(Name = "Telefone")]
    public string TelFixo { get; set; } = string.Empty;
    [Display(Name = "Celular")]
    public string Celular { get; set; } = string.Empty;
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;
    [Display(Name = "Cidade")]
    public Cidade cidade { get; set; }
    [Display(Name = "CEP")]
    public string Cep { get; set; } = string.Empty;
    [Display(Name = "CPF")]
    public string Cpf { get; set; } = string.Empty;
    [Display(Name = "RG")]
    public string Rg { get; set; } = string.Empty;
    [Display(Name = "Data de Nascimento")]
    public DateTime DataNascimento { get; set; }
    [Display(Name = "Data de Admissão")]
    public DateTime DataAdmissao { get; set; }
    [Display(Name = "Data de Demissão")]
    public DateTime DataDemissao { get; set; }
    [Display(Name = "Salário")]
    public decimal Salario { get; set; }
    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; }
    [Display(Name = "Data da Última Alteração")]
    public DateTime DataUltAlteracao { get; set; }
}