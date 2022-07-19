using System.ComponentModel.DataAnnotations;

namespace Invest.Application.DTOS
{
    public class CotistaRegisterDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
        
        [Required]
        public string Cpf { get; set; }
    }
}