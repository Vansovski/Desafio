using Invest.Domain;

namespace Invest.Persistence.Contratos
{
    public interface IOperacaoPersistence
    {
         //Obtem todas as Operções
        Task<Operacao[]> GetAllOperacoesAsync();

        //Obtem Operacao pelo Id 
        Task<Operacao> GetOperacaoByIdAsync(int OperacaoId);
         
    }
}