using Invest.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Invest.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CotistaController : ControllerBase
{  
    //Contrutor da API de Cotistas
    public CotistaController()
    {
       
    }

    //Lista HardCoded de Cotistas
    public List<Cotista> cotistas = new List<Cotista>() {

        new Cotista() {
            Id = 1,
            Nome = "Pedro",
            DataNascimento = DateTime.Parse("1996-03-08"),
            Cpf = "111.111.111-11"
        },
        new Cotista() {
            Id = 2,
            Nome = "João",
            DataNascimento = DateTime.Parse("1995-05-31"),
            Cpf = "222.222.222-22"
        },
        new Cotista() {
            Id = 3,
            Nome = "Maria",
            DataNascimento = DateTime.Parse("1996-07-03"),
            Cpf = "333.333.333-33"
        },
        new Cotista() {
            Id = 4,
            Nome = "Loana",
            DataNascimento = DateTime.Parse("1992-10-15"),
            Cpf = "444.444.444-44"
        },
        new Cotista() {
            Id = 5,
            Nome = "Lucas",
            DataNascimento = DateTime.Parse("2000-02-29"),
            Cpf = "555.555.555-55"
        }
    };


    //Obtem todos os Cotistas
    [HttpGet]
    public IEnumerable<Cotista> Get()
    {
        return cotistas;
    }

    //Obtem Cotista pelo Id 
    [HttpGet("{id}")]
    public Cotista Get(int id)
    {
        //Obtem Cotista 
        var cotista = cotistas.SingleOrDefault(cot => cot.Id == id);
        //Se existir cotista com id retorna 
        return (cotista != null) ? cotista: null;
    }

    //Cadastra um novo Cotista 
    [HttpPost]
    public IEnumerable<Cotista> Post(Cotista cotista)
    {
        //Insere cotista na lista
        cotistas.Add(cotista);
        //retorna lista com a inserção
        return cotistas;
    }
}
