using AspNetCore.Models;
namespace AspNetCore.ViewModels;

public class CreateGradeCorViewModel
{ 
    public string Descricao { get; set; }
    public ICollection<Cor> Cores { get; set; } = new List<Cor>();
}