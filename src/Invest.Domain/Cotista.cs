namespace Invest.Domain
{
    public class Cotista
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public IEnumerable<Operacao> Operacoes { get; set; }
        
    }
}