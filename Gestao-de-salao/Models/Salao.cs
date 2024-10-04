using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_de_salao.Models
{
    [Table("Saloes")]
    public class Salao : LinksHATEOS
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public int AnoComeco { get; set; }
        [Required]
        public int AnoCadastro { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }
    }
}
