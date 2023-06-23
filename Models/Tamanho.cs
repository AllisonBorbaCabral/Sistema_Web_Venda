using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("tamanho")]
    public class Tamanho
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }
        public string DsTamanho { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltAlteracao { get; set; }
        public bool IsAtivo { get; set; }

        public Tamanho(string dsTamanho)
        {
            DsTamanho = dsTamanho;
        }
        public Tamanho()
        {

        }
    }
}