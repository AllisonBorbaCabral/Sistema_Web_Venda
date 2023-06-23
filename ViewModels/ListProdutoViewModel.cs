using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListProdutoViewModel
{
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}