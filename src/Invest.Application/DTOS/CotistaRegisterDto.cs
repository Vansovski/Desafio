using System.ComponentModel.DataAnnotations;

namespace Invest.Application.DTOS
{
    public class CotistaRegisterDto
    {
        [Required(ErrorMessage ="Nome é um campo Obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Data de nascimento é um campo Obrigatório!")]
        public DateTime DataNascimento { get; set; }
                
        [Required(ErrorMessage ="CPF é um campo Obrigatório!")]
        [StringLength(14,MinimumLength = 14, ErrorMessage ="Formato do CPF de ser xxx.xxx.xxx-xx")]
        public string Cpf { get; set; }
    }
}