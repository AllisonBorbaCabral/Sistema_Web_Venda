using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListEstoqueViewModel
{
    public ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();
}