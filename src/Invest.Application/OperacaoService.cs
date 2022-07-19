using Invest.Application.Contratos;
using Invest.Domain;
using Invest.Persistence.Contratos;

namespace Invest.Application
{
    public class OperacaoService : IOperacaoService
    {
         //Injeção de depencia 
        private readonly IOperacaoPersistence _operacaoPersistence;
        //Construtor do serviço de Cotistas 
        public OperacaoService(IOperacaoPersistence operacaoPersistence)
        {
            _operacaoPersistence = operacaoPersistence;
        }
        public async Task<Operacao> AddOperacao(Operacao operacao)
        {
            try
            {
                //Adicona nova Operação 
                _operacaoPersistence.Add<Operacao>(operacao);

                //Verifica se foi salvo no contexto
                if (await _operacaoPersistence.SaveChangesAsync())
                {
                    return await _operacaoPersistence.GetOperacaoByIdAsync(operacao.Id);
                }
                
                return null;
                
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Operacao[]> GetAllOperacoesAsync()
        {
            try
            {
                var operacoes = _operacaoPersistence.GetAllOperacoesAsync();
                //Verifica conteudo do retorno 
                if(operacoes == null) return null;

                //Retorna todas as operações do Fundo 
                return operacoes;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Operacao> GetOperacaoByIdAsync(int OperacaoId)
        {
            try
            {
                //Obtem 
                var cotista = await _operacaoPersistence.GetOperacaoByIdAsync(OperacaoId);
                
                //Verifica conteudo do retorno 
                if(cotista == null) return null;

                //Retorna cotista do Fundo 
                return cotista;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}