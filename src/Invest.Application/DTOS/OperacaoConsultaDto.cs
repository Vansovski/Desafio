using System.ComponentModel.DataAnnotations;

namespace Invest.Application.DTOS
{
    public class OperacaoConsultaDto
    {
        public int Id { get; set; }
    
        public int CotistaId { get; set; }

        public string? DataOperacao { get; set; }

        public int TipoOperacao { get; set; }

        public int QtdCotas { get; set; }

        public double valorCota { get; set; }
    }
}