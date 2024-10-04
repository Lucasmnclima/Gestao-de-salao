using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestao_de_salao.Models
{
    [Table("Pagamentos")]
    public class Pagamento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ModoPagamento { get; set; }
        [Required]
        public DateTime DataPagamento {  get; set; }
        [Required]
        [Column(TypeName ="decimal(18,2")]
        public decimal Valor { get; set; }
        [Required]
        public TipoPagamento Tipo {  get; set; }
        [Required]
        public int SalaoId { get; set; }
        public Salao Salao { get; set; }

    }

    public enum TipoPagamento
    {
        CartaoCredito,
        CartaoDebito,
        Dinheiro,
        Pix
    }
}
