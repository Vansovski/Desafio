using Invest.Application.DTOS;
using Invest.Domain;

namespace Invest.Application.Contratos
{
    public interface IOperacaoService
    {
        //Adicona uma nova operacao
        Task<Operacao> AddOperacao(OperacaoRegisterDto operacaoRegister);

        //Obtem todas as Operções
        Task<List<OperacaoConsultaDto>> GetAllOperacoesAsync();

        //Obtem Operacao pelo Id 
        Task<OperacaoConsultaDto> GetOperacaoByIdAsync(int OperacaoId);
    }
}