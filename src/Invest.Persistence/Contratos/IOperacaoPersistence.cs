using Invest.Domain;

namespace Invest.Persistence.Contratos
{
    public interface IOperacaoPersistence: IPersistence
    {
        //Obtem todas as Operções
        Task<Operacao[]?> GetAllOperacoesAsync();

        //Obtem Operacao pelo Id 
        Task<Operacao?> GetOperacaoByIdAsync(int OperacaoId);
         
    }
}