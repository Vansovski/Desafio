using AutoMapper;
using Invest.Application.Contratos;
using Invest.Application.DTOS;
using Invest.Domain;
using Invest.Persistence.Contratos;

namespace Invest.Application
{
    public class CotistaService : ICotistaService
    {
        //Injeção de depencia 
        private readonly ICotistaPersistence _cotistaPersistence;
        private readonly IMapper _mapper;

        //Construtor do serviço de Cotistas 
        public CotistaService(ICotistaPersistence cotistaPersistence,
                              IMapper mapper)
        {
            _cotistaPersistence = cotistaPersistence;
            _mapper = mapper;
        }

        //Registra Cotista
        public async Task<CotistaConsultaDto?> AddCotista(CotistaRegisterDto cotistaRegister)
        {
            try
            {
                //Verifica se o Cotista já existe 
                var cotistaExiste = await _cotistaPersistence.GetCotistaByCpfAsync(cotistaRegister.Cpf ?? "");
                if(cotistaExiste != null)
                {
                    throw new  Exception("Já existe cotista com esse CPF!");
                }
                
                //Mapeamento de campos 
                var cotista = _mapper.Map<Cotista>(cotistaRegister);

                //Adiciona Cotista
                _cotistaPersistence.Add<Cotista>(cotista);
                //Verifica se foi salvo no contexto
                if (await _cotistaPersistence.SaveChangesAsync())
                {
                    return await GetCotistaByIdAsync(cotista.Id);
                }
                
                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Obtem todos os Cotistas com as informações de retorno e verifica saldo de Cotas
        public async Task<List<CotistaConsultaDto>?> GetAllCotistasAsync()
        {
            try
            {
                //Obtem 
                var cotistas = await _cotistaPersistence.GetAllCotistasAsync();
                
                //Verifica conteudo do retorno 
                if(cotistas == null) return null;

                var cotistaRetorno = new List<CotistaConsultaDto>();

                foreach (var item in cotistas)
                {
                    var mapeamentoDTO = _mapper.Map<CotistaConsultaDto>(item);
                    mapeamentoDTO.QtdCotas = SaldoCotas(item);
                    //Adiciona ao retorno 
                    cotistaRetorno.Add(mapeamentoDTO);
                }

                //Retorna todos os cotistas do Fundo 
                return cotistaRetorno;
                
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CotistaConsultaDto?> GetCotistaByIdAsync(int CotaId)
        {
            try
            {
                //Obtem cotista do Banco de Dados
                var cotista = await _cotistaPersistence.GetCotistaByIdAsync(CotaId);
                
                //Verifica conteudo do retorno 
                if(cotista == null) return null;
                
                //Mapeamento do DTO
                var _cotistaRet = _mapper.Map<CotistaConsultaDto>(cotista);

                //saldo de Cotas
                _cotistaRet.QtdCotas = SaldoCotas(cotista);

                //Retorna cotista do Fundo 
                return _cotistaRet;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Calcula Saldo de Cotas dado conjunto de Operções
        public int SaldoCotas(Cotista cotista)
        {
            //Obtem operções do Cotista
            var operacoes =  cotista.Operacoes;
            if(operacoes != null)
            {
                //Saldo de cotas 
                int saldo = 0;
                
                //Soma Compra Subtrai Venda 
                foreach(Operacao operacao in operacoes)
                {
                    //0 significa compra 1 venda
                    saldo = (operacao.TipoOperacao == 0)? saldo + operacao.QtdCotas
                                                        : saldo - operacao.QtdCotas; 

                }
                //Retorna saldo de Cotas 
                return saldo;
            }
            //Senão tiver lista Retorna 0
            return 0;
        }
    }
}