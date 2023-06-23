using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("grade_tamanho")]
    public class GradeTamanho
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltAlteracao { get; set; }
        public bool IsAtivo { get; set; }

        public GradeTamanho()
        { }
    }
}