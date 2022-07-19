using Invest.Domain;
using Invest.Persistence.Context;
using Invest.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Invest.Persistence
{
    public class OperacaoPersistence : Persistence, IOperacaoPersistence
    {
        //Injeção de dependecia InvestContext
        private readonly InvestContext _context;

        //Contrutor da API de Cotistas, 
        public OperacaoPersistence(InvestContext context): base(context)
        {
            _context = context;
        }

        public async Task<Operacao[]> GetAllOperacoesAsync()
        {
            //Query para obter todas as operções inclui o Cotista da operção
            IQueryable<Operacao> query = _context.Operacoes.Include(op => op.Cotista);

            //Ordena pelo Id da Operção
            query = query.OrderBy(op => op.Id);

            //Retorna Array de Operções 
            return await query.ToArrayAsync();
        }

        public async Task<Operacao> GetOperacaoByIdAsync(int OperacaoId)
        {
            //Query para obter todas as operções inclui o Cotista da operção
            IQueryable<Operacao> query = _context.Operacoes.Include(op => op.Cotista);

            //Obtem Operação pelo Id 
            query = query.OrderBy(op => op.Id)
                         .Where(op => op.Id == OperacaoId);


            return await query.FirstOrDefaultAsync();
        }
    }
}