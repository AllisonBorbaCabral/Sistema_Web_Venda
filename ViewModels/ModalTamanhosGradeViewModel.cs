using System.ComponentModel.DataAnnotations;
using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ModalTamanhosGradeViewModel
{
    [Display(Name = "Tamanho")]
    public Tamanho tamanho { get; set; }
    [Display(Name = "Grade Tamanho")]
    public GradeTamanho gradeTamanho { get; set; }
}