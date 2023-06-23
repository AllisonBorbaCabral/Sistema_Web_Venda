using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListCoresGradeViewModel
{
    public ICollection<CorGrade> CoresGrade { get; set; } = new List<CorGrade>();
}