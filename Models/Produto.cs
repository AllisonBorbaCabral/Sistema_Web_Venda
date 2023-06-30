using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("produto")]
    public class Produto:Pai
    {
        public string DsProduto { get; set; }
        public int Ncm { get; set; }
        public string Und { get; set; }
        public GradeCor gradeCor { get; set; }
        public GradeTamanho gradeTamanho { get; set; }
        public bool IsAtivo { get; set; }

        public Produto(string dsProduto, int ncm, string und, GradeCor objGradeCor, GradeTamanho objGradeTamanho)
        {
            DsProduto = dsProduto;
            Ncm = ncm;
            Und = und;
            gradeCor = objGradeCor;
            gradeTamanho = objGradeTamanho;
        }

        public Produto()
        {

        }
    }
}