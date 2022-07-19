using Invest.Domain;
using Invest.Persistence.Context;
using Invest.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Invest.Persistence
{
    public class CotistaPersistence : Persistence, ICotistaPersistence
    {

        //Injeção de dependecia InvestContext
        private readonly InvestContext _context;

        //Contrutor da API de Cotistas, 
        public CotistaPersistence(InvestContext context): base(context)
        {
            _context = context;
        }
        public async Task<Cotista[]> GetAllCotistasAsync()
        {
            //Query para obter todos os Cotistas
            IQueryable<Cotista> query = _context.Cotistas.Include(cotista => cotista.Operacoes);


            //Ordena pelo Id do Cotista
            query = query.OrderBy(ct => ct.Id);

            //Retorna todas os Cotistas 
            return await query.ToArrayAsync();
        }

        public async Task<Cotista> GetCotistaAsync(int CotistaId)
        {
            //Query para obter todos os Cotistas
            IQueryable<Cotista> query = _context.Cotistas.Include(cotista => cotista.Operacoes);


            //Ordena pelo Id do Cotista
            query = query.OrderBy(ct => ct.Id)
                         .Where(ct => ct.Id == CotistaId);

            return await query.FirstOrDefaultAsync();
        }
    }
}