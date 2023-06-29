using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListGradeCorViewModel
{
    public string Descricao;
    public ICollection<GradeCor> GradeCores { get; set; } = new List<GradeCor>();
}