using Invest.Application.Contratos;
using Invest.Application.DTOS;
using Invest.Domain;
using Invest.Persistence.Contratos;

namespace Invest.Application
{
    public class OperacaoService : IOperacaoService
    {
         //Injeção de depencia 
        private readonly IOperacaoPersistence _operacaoPersistence;
        private readonly ICotistaService _cotistaService;
        //Construtor do serviço de Cotistas 
        public OperacaoService(IOperacaoPersistence operacaoPersistence, 
                               ICotistaService cotistaService)
        {
            _operacaoPersistence = operacaoPersistence;
            _cotistaService = cotistaService;
        }
        public async Task<OperacaoConsultaDto> AddOperacao(OperacaoRegisterDto operacaoRegister)
        {
            try
            {
                //Verifica se Cotista existe para inserir operacao
                var cotista = await _cotistaService.GetCotistaByIdAsync(operacaoRegister.CotistaId);
                if(cotista == null) return null;

                //variável critica a ser processada 
                var dataAtual = DateTime.Now;
                //Mapeamento da Operação
                var operacao = new Operacao{
                    CotistaId = operacaoRegister.CotistaId,
                    //Formato da data
                    DataOperacao = dataAtual.ToString("yyyy-MM-ddTHH:mm:ss.fffffff"),
                    TipoOperacao = operacaoRegister.TipoOperacao,
                    QtdCotas = operacaoRegister.Cotas,
                    ValorCota = valorCota(dataAtual)
                };
                
                //Adicona nova Operação 
                _operacaoPersistence.Add<Operacao>(operacao);

                //Verifica se foi salvo no contexto
                if (await _operacaoPersistence.SaveChangesAsync())
                {
                    return await GetOperacaoByIdAsync(operacao.Id);
                }
                
                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OperacaoConsultaDto>> GetAllOperacoesAsync()
        {
            try
            {
                var operacoes = await _operacaoPersistence.GetAllOperacoesAsync();
                //Verifica conteudo do retorno 
                if(operacoes == null) return null;

                //Lista de OperaçõesDto 
                List<OperacaoConsultaDto> _operacoes = new List<OperacaoConsultaDto>();

                //Mapeamento de Operações
                foreach(var op in operacoes)
                {
                    //adiciona elemento e faz mapeamento para DTO 
                    _operacoes.Add(new OperacaoConsultaDto{
                        Id = op.Id,
                        CotistaId = op.CotistaId,
                        DataOperacao = op.DataOperacao,
                        Operacao = op.TipoOperacao,
                        Cotas = op.QtdCotas,
                        valorCota = op.ValorCota
                    });
                }

                //Retorna todas as operações do Fundo 
                return _operacoes;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OperacaoConsultaDto> GetOperacaoByIdAsync(int OperacaoId)
        {
            try
            {
                //Obtem Operçao dado o Id 
                var op = await _operacaoPersistence.GetOperacaoByIdAsync(OperacaoId);

                //Verifica conteudo do retorno 
                if(op == null) return null;

                //Mapeamento para DTO
                var _operacaoDto = new OperacaoConsultaDto{
                        Id = op.Id,
                        CotistaId = op.CotistaId,
                        DataOperacao = op.DataOperacao,
                        Operacao = op.TipoOperacao,
                        Cotas = op.QtdCotas,
                        valorCota = op.ValorCota
                    };
                
                //Retorna operação do Fundo 
                return _operacaoDto;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Calculo do valor da Cota 
        public double valorCota(DateTime data)
        {
            //Regra de negocio 
            var valorCota = 120.00 + Math.Log(data.Minute + 1,2) 
                                   - Math.Log(data.Second + 1,3);

            //valor arredondado 
            return Math.Round(valorCota,2);
        }
    }
}