using System.ComponentModel.DataAnnotations;
using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ModalCoresGradeViewModel
{
    [Display(Name = "Cor")]
    public Cor cor { get; set; }
    [Display(Name = "Grade Cor")]
    public GradeCor gradeCor { get; set; }
}