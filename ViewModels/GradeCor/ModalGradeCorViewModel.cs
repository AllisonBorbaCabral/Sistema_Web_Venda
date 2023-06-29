using System.ComponentModel.DataAnnotations;
using AspNetCore.Models;
namespace AspNetCore.ViewModels;

public class ModalGradeCorViewModel
{
    [Display(Name = "Código")]
    public int Id { get; set; }
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }
    [Display(Name = "Cores")]
    public ICollection<Cor> Cores { get; set; } = new List<Cor>();
    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; }
    [Display(Name = "Data da Última Alteração")]
    public DateTime DataUltAlteracao { get; set; }
}