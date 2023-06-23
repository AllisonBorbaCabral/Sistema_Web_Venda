using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListGradeTamanhoViewModel
{
    public ICollection<GradeTamanho> GradeTamanhos { get; set; } = new List<GradeTamanho>();
}