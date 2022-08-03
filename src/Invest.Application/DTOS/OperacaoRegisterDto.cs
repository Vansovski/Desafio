using System.ComponentModel.DataAnnotations;

namespace Invest.Application.DTOS
{
    public class OperacaoRegisterDto
    {

        [Required(ErrorMessage ="Id do cotista é um campo Obrigatório!")]
        public int? CotistaId { get; set; }

        [Required(ErrorMessage ="A operação Compra/Venda deve ser informada!")]
        [Range(0,1, ErrorMessage="A operação deve ser 0 para compra e 1 para venda!")]
        public int? TipoOperacao { get; set; }
        
        [Required(ErrorMessage ="Quantidade de cotas de ser um numero inteiro, maior que 0!")]
        public int? Cotas { get; set; }
        
    }
}