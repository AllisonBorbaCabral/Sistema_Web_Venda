using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("tamanho")]
    public class Tamanho:Pai
    {
        public string DsTamanho { get; set; }
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