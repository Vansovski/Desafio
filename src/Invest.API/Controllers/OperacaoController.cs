using Invest.Persistence;
using Invest.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Invest.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperacaoController : ControllerBase
{  
    //Injeção de dependencia 
    private readonly InvestContext _context;
    //Contrutor da API das operações 
    public OperacaoController(InvestContext context)
    {
       _context = context;
    }

    //Obtem todas as Operações 
    [HttpGet]
    public IEnumerable<Operacao> Get()
    {
        //Lista de Operações 
        return _context.Operacoes.ToList();
    }

    //Obtem operação pelo Id
    [HttpGet("{id}")]
    public Operacao Get(int id)
    {
        //Obtem a operação dado o Id 
        var op = _context.Operacoes.FirstOrDefault(op => op.Id == id);
        return op;
    }

    //Registra um nova Operação Compra ou Venda
    [HttpPost]
    public IEnumerable<Operacao> Post(Operacao operacao)
    {
        //Adicona nova operação 
        _context.Add(operacao);
        _context.SaveChanges();
        return _context.Operacoes.ToList();
    }

}
