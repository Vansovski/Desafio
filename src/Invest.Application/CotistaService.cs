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
        public async Task<Cotista> AddCotista(Cotista cotista)
        {
            try
            {
                //Adiciona Cotista
                _cotistaPersistence.Add<Cotista>(cotista);
                //Verifica se foi salvo no contexto
                if (await _cotistaPersistence.SaveChangesAsync())
                {
                    return await _cotistaPersistence.GetCotistaByIdAsync(cotista.Id);
                }
                
                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Obtem todos os Cotistas
        public async Task<List<CotistaDto>> GetAllCotistasAsync()
        {
            try
            {
                //Obtem 
                var cotistas = await _cotistaPersistence.GetAllCotistasAsync();
                
                //Verifica conteudo do retorno 
                if(cotistas == null) return null;

                var cotistaRetorno = new List<CotistaDto>();

                foreach (var item in cotistas)
                {
                    //Adiciona ao retorno 
                    cotistaRetorno.Add(new CotistaDto(){
                        Id = item.Id,
                        Nome = item.Nome,
                        DataNascimento = item.DataNascimento,
                        Cpf = item.Cpf,
                        QtdCotas = SaldoCotas(item.Operacoes)
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

        public async Task<Cotista> GetCotistaByIdAsync(int CotaId)
        {
            try
            {
                //Obtem 
                var cotista = await _cotistaPersistence.GetCotistaByIdAsync(CotaId);
                
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


        //Saldo de Cotas
        public int SaldoCotas(IEnumerable<Operacao> operacoes)
        {
            if(operacoes.Count() == 0)
            {
                return 0;
            }
            //Saldo de cotas 
            int saldo = 0;
            //Soma Compra Subtrai Venda 
            foreach(Operacao operacao in operacoes )
            {
                saldo = (operacao.TipoOperacao == 1)? saldo + operacao.QtdCotas
                                                    : saldo - operacao.QtdCotas; 

            }
            //Retorna saldo de Cotas 
            return saldo;
        }
    }
}