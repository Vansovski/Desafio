using Invest.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Invest.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperacaoController : ControllerBase
{  
    //Contrutor da API das operações 
    public OperacaoController()
    {
       
    }


    //Obtem todas as Operações 
    [HttpGet]
    public string Get()
    {
        return "Retorno";
    }

    //Obtem operação pelo Id
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "Retorno";
    }

    //Registra um nova Operação Compra ou Venda
    [HttpPost]
    public string Post()
    {
        return "Retorno";
    }

}
