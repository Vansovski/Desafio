using Invest.Domain;

namespace Invest.Persistence.Contratos
{
    public interface ICotistaPersistence
    {
        //Obtem todos os Cotistas
        Task<Cotista[]> GetAllCotistasAsync();
        //Obtem Cotista pelo Id 
        Task<Cotista> GetCotistaAsync(int CotaId);
         
    }
}