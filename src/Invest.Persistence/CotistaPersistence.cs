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
        public async Task<Cotista[]?> GetAllCotistasAsync()
        {
            //Query para obter todos os Cotistas
            IQueryable<Cotista>? query = _context.Cotistas?.Include(cotista => cotista.Operacoes);


            //Ordena pelo Id do Cotista
            query = query?.OrderBy(ct => ct.Id);

            //Retorna todas os Cotistas 
            if(query != null) return await query.ToArrayAsync();
            return null;
        }

        //Obtem por Id
        public async Task<Cotista?> GetCotistaByIdAsync(int CotistaId)
        {
            //Query para obter todos os Cotistas
            IQueryable<Cotista>? query = _context.Cotistas?.Include(cotista => cotista.Operacoes);


            //Ordena pelo Id do Cotista
            query = query?.OrderBy(ct => ct.Id)
                         .Where(ct => ct.Id == CotistaId);
            if(query != null)
            {
                return await query.FirstOrDefaultAsync();
            }
            return null;
        }
        
        //Obtem por CPF
        public async Task<Cotista?> GetCotistaByCpfAsync(string cpf)
        {
            //Query para obter todos os Cotistas
            IQueryable<Cotista>? query = _context.Cotistas?.
                                            OrderBy(ct => ct.Id)
                                            .Where(ct => ct.Cpf == cpf);

            if(query != null) return await query.FirstOrDefaultAsync();
            return null;
        }


    }
}