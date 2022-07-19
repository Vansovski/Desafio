using Invest.Persistence;
using Invest.Domain;
using Microsoft.AspNetCore.Mvc;
using Invest.Persistence.Context;
using Invest.Application.Contratos;

namespace Invest.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperacaoController : ControllerBase
{
    //Injeção de dependencia 
    private readonly IOperacaoService _operacaoService;
    //Contrutor da API das operações 
    public OperacaoController(IOperacaoService operacaoService)
    {
        _operacaoService = operacaoService;
    }

    //Obtem todas as Operações 
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        //Lista de Operações 
        try
        {
            //Obtem todas as Operaçoes 
            var operacoes = await _operacaoService.GetAllOperacoesAsync();
            //Verifica o resultado da busca 
            if (operacoes == null) return NotFound("Não existe nenhuma Operação!");

            return Ok(operacoes);

        }
        catch (System.Exception ex)
        {
            //Tratamento de exceção
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao recuperar Operações. Erro {ex}");
        }
    }


    //Obtem operação pelo Id
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        //Obtem a operação dado o Id 
        try
        {
            //Obtem a Operação 
            var operacoes = await _operacaoService.GetOperacaoByIdAsync(id);
            //Verifica o resultado da busca 
            if (operacoes == null) return NotFound("Não existe esta Operação!");

            return Ok(operacoes);
        }
        catch (System.Exception ex)
        {
            //Tratamento de exceção
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao obter  a Operção. Erro {ex}");
        }
    }

    //Registra um nova Operação Compra ou Venda
    [HttpPost]
    public async Task<IActionResult> Post(Operacao operacao)
    {
        //Adicona nova operação 
        try
        {
            //Insere o Cotista
            var _cotista = await _operacaoService.AddOperacao(operacao);

            //verifica se houve algum erro ao registrar Cotista
            if(_cotista == null) return BadRequest("Erro ao Adicionar Cotista");

            return Ok(_cotista);

        }
        catch (System.Exception ex)
        {
            //Tratamento de exceção
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao adcionar Operação. Erro {ex}");
        }
    }

}
