using System.ComponentModel.DataAnnotations;

namespace Invest.Domain
{
    public class Operacao
    {
        public int Id { get; set; }

        [Required]
        public int CotistaId { get; set; }

        public Cotista? Cotista { get; set; }
        
        public string? DataOperacao { get; set; }

        [Required]
        public int TipoOperacao { get; set; }
        
        [Required]
        public int QtdCotas { get; set; }

        public double ValorCota { get; set; }
    }
}