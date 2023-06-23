using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("cor_grade")]
    public class CorGrade
    {
        [Display(Name = "Cor")]
        public Cor cor { get; set; }
        [Display(Name = "Grade da cor")]
        public GradeCor gradeCor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltAlteracao { get; set; }
        public bool IsAtivo { get; set; }

        public CorGrade(Cor objCor, GradeCor objGradeCor)
        {
            cor = objCor;
            gradeCor = objGradeCor;
        }

        public CorGrade()
        {

        }
    }
}