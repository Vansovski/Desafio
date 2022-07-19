namespace Invest.Application.DTOS
{
    public class CotistaDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public int QtdCotas { get; set; }
    }
}