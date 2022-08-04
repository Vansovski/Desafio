using Invest.Persistence.Context;
using Invest.Persistence.Contratos;

namespace Invest.Persistence
{
    public class Persistence : IPersistence
    {

        //Injeção de dependecia InvestContext
        protected readonly InvestContext _context;

        //Contrutor da API de Cotistas, 
        public Persistence(InvestContext context)
        {
            _context = context;
        }

        //Adiciona
        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }

        //Salva Alterações 
        public async Task<bool> SaveChangesAsync()
        {
            //se for maior que 0 houve alteração 
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}