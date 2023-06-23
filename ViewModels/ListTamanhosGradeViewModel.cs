using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListTamanhosGradeViewModel
{
    public ICollection<TamanhoGrade> TamanhosGrade { get; set; } = new List<TamanhoGrade>();
}