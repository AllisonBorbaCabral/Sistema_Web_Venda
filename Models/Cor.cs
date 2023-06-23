using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("cor")]
    public class Cor
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }
        public string DsCor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltAlteracao { get; set; }
        public bool IsAtivo { get; set; }

        public Cor(string dsCor)
        {
            DsCor = dsCor;
        }

        public Cor()
        {

        }
    }
}