using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("tamanho_grade")]
    public class TamanhoGrade
    {
        [Display(Name = "Tamanho")]
        public Tamanho tamanho { get; set; }
        [Display(Name = "Grade da Tamanho")]
        public GradeTamanho gradeTamanho { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltAlteracao { get; set; }
        public bool IsAtivo { get; set; }

        public TamanhoGrade(Tamanho objTamanho, GradeTamanho objGradeTamanho)
        {
            tamanho = objTamanho;
            gradeTamanho = objGradeTamanho;
        }

        public TamanhoGrade()
        {

        }
    }
}