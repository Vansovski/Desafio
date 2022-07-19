using Invest.Domain;

namespace Invest.Application.Contratos
{
    public interface ICotistaService
    {
        //Registrar Cotista
        Task<Cotista> AddCotista(Cotista operacao);
         
        //Obtem todos os Cotistas
        Task<Cotista[]> GetAllCotistasAsync();
        //Obtem Cotista pelo Id 
        Task<Cotista> GetCotistaByIdAsync(int CotaId);
    }
}