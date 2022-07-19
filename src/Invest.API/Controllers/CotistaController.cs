using Invest.Persistence;
using Invest.Domain;
using Microsoft.AspNetCore.Mvc;
using Invest.Application.Contratos;
using Invest.Application.DTOS;

namespace Invest.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CotistaController : ControllerBase
{  
    //Injeção de dependecia DataContex
    private readonly ICotistaService  _cotistaService;

    //Contrutor da API de Cotistas, 
    public CotistaController(ICotistaService cotistaService)
    {
       _cotistaService = cotistaService;
    }

    //Obtem todos os Cotistas
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            //Obtem todos os Cotistas
            var cotistas = await _cotistaService.GetAllCotistasAsync();
            //Verifica o resultado da busca 
            if(cotistas == null) return NotFound("Não existe nenhum Cotista Registrado");

            return Ok(cotistas);            
            
        }
        catch (System.Exception ex)
        {
            //Tratamento de exceção
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao recuperar Cotistas. Erro {ex}");
        }
    }

    //Obtem Cotista pelo Id 
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            //Obtem Cotista
            var cotista = await _cotistaService.GetCotistaByIdAsync(id);
            if (cotista == null) return NotFound("Cotista não encontrado");

            //retorno com Cotista
            return Ok(cotista);
            
        }
        catch (System.Exception ex)
        {
          //Tratamento de exceção
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao recuperar Cotistas. Erro {ex}");
        }
    }

    //Cadastra um novo Cotista 
    [HttpPost]
    public async Task<IActionResult> Post(CotistaRegisterDto cotista)
    {
        try
        {
            //Mapeamento de cmapos 
            var _cotista = new Cotista {
                Nome = cotista.Nome,
                DataNascimento = cotista.DataNascimento,
                Cpf = cotista.Cpf
            };
            
            //Insere o Cotista
            var cotistaRetorno = await _cotistaService.AddCotista(_cotista);

            //verifica se houve algum erro ao registrar Cotista
            if(cotistaRetorno == null) return BadRequest("Erro ao Adicionar Cotista");

            return Ok(cotistaRetorno);

        }
        catch (System.Exception ex)
        {
          //Tratamento de exceção
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao Registrar Cotistas. Erro {ex}");
        }
    }
}
