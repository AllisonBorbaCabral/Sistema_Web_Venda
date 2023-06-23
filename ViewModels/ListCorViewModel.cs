using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListCorViewModel
{
    public ICollection<Cor> Cores { get; set; } = new List<Cor>();
}