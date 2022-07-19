using Invest.Persistence;
using Invest.Domain;
using Microsoft.AspNetCore.Mvc;
using Invest.Persistence.Context;

namespace Invest.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CotistaController : ControllerBase
{  
    //Injeção de dependecia DataContex
    private readonly InvestContext _context;

    //Contrutor da API de Cotistas, 
    public CotistaController(InvestContext context)
    {
       _context = context;
    }

    //Obtem todos os Cotistas
    [HttpGet]
    public IEnumerable<Cotista> Get()
    {
        return _context.Cotistas;
    }

    //Obtem Cotista pelo Id 
    [HttpGet("{id}")]
    public Cotista Get(int id)
    {
        //Obtem Cotista 
        var cotista = _context.Cotistas.SingleOrDefault(cot => cot.Id == id);
        //Se existir cotista com id retorna 
        return (cotista != null) ? cotista: null;
    }

    //Cadastra um novo Cotista 
    [HttpPost]
    public IEnumerable<Cotista> Post(Cotista cotista)
    {
        //Insere cotista 
        _context.Add(cotista);
        _context.SaveChanges();
        //retorna todos os cotistas
        var cotistas = _context.Cotistas.ToList();
        return cotistas ;
    }
}
