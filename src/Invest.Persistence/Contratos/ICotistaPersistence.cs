using Invest.Domain;

namespace Invest.Persistence.Contratos
{
    public interface ICotistaPersistence: IPersistence
    {
        //Obtem todos os Cotistas
        Task<Cotista[]> GetAllCotistasAsync();
        //Obtem Cotista pelo Id 
        Task<Cotista> GetCotistaByIdAsync(int CotaId);
         
    }
}