using AutoMapper;
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
        private readonly ICotistaPersistence _cotistaPersistence;
        private readonly ICotistaService _cotistaService;
        private readonly IMapper _mapper;

        //Construtor do serviço de Cotistas 
        public OperacaoService(IOperacaoPersistence operacaoPersistence, 
                               ICotistaPersistence cotistaPersistence,
                               ICotistaService cotistaService,
                               IMapper mapper)
        {
            _operacaoPersistence = operacaoPersistence;
            _cotistaPersistence = cotistaPersistence;
            _cotistaService = cotistaService;
            _mapper = mapper;
        }
        public async Task<OperacaoConsultaDto?> AddOperacao(OperacaoRegisterDto operacaoRegister)
        {
            try
            {
                //variável critica a ser processada 
                var dataAtual = DateTime.Now;

                //Verifica se Cotista existe para inserir operacao
                var cotista = await _cotistaPersistence.GetCotistaByIdAsync(operacaoRegister.CotistaId??0);
                if(cotista == null) 
                {
                    //Cotista Invalido
                    throw new InvalidOperationException("CotistaInvalido");
                }
                
                //Se for operção de venda 1 verifica se existe saldo 
                if(operacaoRegister.TipoOperacao == 1)
                {
                    //Quantidade de Cotas disponivel 
                    var saldoCotas = _cotistaService.SaldoCotas(cotista);
                    if(operacaoRegister.Cotas > saldoCotas)
                    {
                        //Saldo de cotas insuficiente para venda
                        throw new InvalidOperationException("SaldoInsuficiente");
                    }
                }

                //Mapeamento da Operação
                var operacao = _mapper.Map<Operacao>(operacaoRegister);
                operacao.ValorCota = valorCota(dataAtual);
                operacao.DataOperacao = dataAtual.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
                
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

        public async Task<OperacaoConsultaDto[]?> GetAllOperacoesAsync()
        {
            try
            {
                var operacoes = await _operacaoPersistence.GetAllOperacoesAsync();
                //Verifica conteudo do retorno 
                if(operacoes == null) return null;

                //Lista de OperaçõesDto Mapeado
                var _operacoes = _mapper.Map<OperacaoConsultaDto[]>(operacoes);

                //Retorna todas as operações do Fundo 
                return _operacoes;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OperacaoConsultaDto?> GetOperacaoByIdAsync(int OperacaoId)
        {
            try
            {
                //Obtem Operçao dado o Id 
                var op = await _operacaoPersistence.GetOperacaoByIdAsync(OperacaoId);

                //Verifica conteudo do retorno 
                if(op == null) return null;

                //Mapeamento para DTO
                var _operacaoDto = _mapper.Map<OperacaoConsultaDto>(op);
                
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