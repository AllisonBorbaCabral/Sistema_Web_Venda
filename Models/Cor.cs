using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("cor")]
    public class Cor:Pai
    {
        public string DsCor { get; set; }
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