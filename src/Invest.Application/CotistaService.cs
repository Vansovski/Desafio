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
        //Construtor do serviço de Cotistas 
        public CotistaService(ICotistaPersistence cotistaPersistence)
        {
            _cotistaPersistence = cotistaPersistence;
        }

        //Registra Cotista
        public async Task<CotistaConsultaDto> AddCotista(CotistaRegisterDto cotistaRegister)
        {
            try
            {
                 //Mapeamento de cmapos 
                var cotista = new Cotista {
                Nome = cotistaRegister.Nome,
                DataNascimento = cotistaRegister.DataNascimento,
                Cpf = cotistaRegister.Cpf
                };
                //Verifica se o Cotista já existe 
                var cotistaExiste = await _cotistaPersistence.GetCotistaByCpfAsync(cotista.Cpf);
                if(cotistaExiste != null) return null;

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
        public async Task<List<CotistaConsultaDto>> GetAllCotistasAsync()
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
                    //Adiciona ao retorno 
                    cotistaRetorno.Add(new CotistaConsultaDto(){
                        Id = item.Id,
                        Nome = item.Nome,
                        DataNascimento = item.DataNascimento,
                        Cpf = item.Cpf,
                        QtdCotas = SaldoCotas(item)
                    });
                }

                //Retorna todos os cotistas do Fundo 
                return cotistaRetorno;
                
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CotistaConsultaDto> GetCotistaByIdAsync(int CotaId)
        {
            try
            {
                //Obtem cotista do Banco de Dados
                var cotista = await _cotistaPersistence.GetCotistaByIdAsync(CotaId);
                
                //Verifica conteudo do retorno 
                if(cotista == null) return null;

                //Retorno DTO do Cotista
                CotistaConsultaDto _cotistaRet = new CotistaConsultaDto(){
                    Id = cotista.Id,
                    Nome = cotista.Nome,
                    DataNascimento = cotista.DataNascimento,
                    Cpf = cotista.Cpf,
                    QtdCotas = SaldoCotas(cotista)
                    };

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
            if(operacoes.Count() == 0)
            {
                return 0;
            }
            //Saldo de cotas 
            int saldo = 0;
            //Soma Compra Subtrai Venda 
            foreach(Operacao operacao in operacoes )
            {
                //0 significa compra 1 venda
                saldo = (operacao.TipoOperacao == 0)? saldo + operacao.QtdCotas
                                                    : saldo - operacao.QtdCotas; 

            }
            //Retorna saldo de Cotas 
            return saldo;
        }
    }
}