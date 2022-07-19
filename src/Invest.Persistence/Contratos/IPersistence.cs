namespace Invest.Persistence.Contratos
{
    public interface IPersistence
    {
        //Adicionar 
        void Add<T>(T Entity) where T: class;
        
        //salvar no Contexto
        Task<bool> SaveChangesAsync();

        //Podemos inserir outras opções para persistencia como Update, Delete
         
    }
}