using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListFuncionarioViewModel
{
    public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
}