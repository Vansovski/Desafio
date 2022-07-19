using Invest.Domain;

namespace Invest.Application.Contratos
{
    public interface IOperacaoService
    {
        //Adicona uma nova operacao
        Task<Operacao> AddOperacao(Operacao operacao);


        //Obtem todas as Operções
        Task<Operacao[]> GetAllOperacoesAsync();

        //Obtem Operacao pelo Id 
        Task<Operacao> GetOperacaoByIdAsync(int OperacaoId);
    }
}