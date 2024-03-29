using Invest.Domain;
using Invest.Persistence.Context;
using Invest.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Invest.Persistence
{
    public class OperacaoPersistence : Persistence, IOperacaoPersistence
    {
        
        //Contrutor da API de Cotistas, 
        public OperacaoPersistence(InvestContext context): base(context)
        {
            
        }

        public async Task<Operacao[]?> GetAllOperacoesAsync()
        {
            //Query para obter todas as operções inclui o Cotista da operção
            IQueryable<Operacao>? query = _context.Operacoes;

            //Ordena pelo Id da Operção
            query = query?.OrderBy(op => op.Id);

            //Retorna Array de Operções 
            if(query != null) return await query.ToArrayAsync();
            return null;
        }

        public async Task<Operacao?> GetOperacaoByIdAsync(int OperacaoId)
        {
            //Query para obter todas as operções inclui o Cotista da operção
            IQueryable<Operacao>? query = _context.Operacoes;

            //Obtem Operação pelo Id 
            query = query?.OrderBy(op => op.Id)
                         .Where(op => op.Id == OperacaoId);

            if(query != null) return await query.FirstOrDefaultAsync();
            return null;
        }
    }
}