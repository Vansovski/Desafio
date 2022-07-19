using System.ComponentModel.DataAnnotations;

namespace Invest.Application.DTOS
{
    public class OperacaoRegisterDto
    {

        [Required]
        public int CotistaId { get; set; }

        [Required]
        public int TipoOperacao { get; set; }
        
        [Required]
        public int QtdCotas { get; set; }
        
    }
}