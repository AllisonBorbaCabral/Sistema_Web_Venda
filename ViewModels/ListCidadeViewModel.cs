using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListCidadeViewModel
{
    public ICollection<Cidade> Cidades { get; set; } = new List<Cidade>();
}