using Microsoft.AspNetCore.Mvc;
using Invest.Application.Contratos;
using Invest.Application.DTOS;

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
    public async Task<IActionResult> Post(OperacaoRegisterDto operacaoRegister)
    {
        //Adicona nova operação 
        try
        {
            //Insere a Operacao
            var _operacao = await _operacaoService.AddOperacao(operacaoRegister);

            //verifica se houve algum erro ao registrar a Operação
            if(_operacao == null) return BadRequest(new {Message = "Erro ao Adicionar Operação!"});

            return Ok(_operacao);

        }
        catch (System.Exception ex)
        {
            //Cotista Invalido
            if(ex.Message == "CotistaInvalido")
            {
                //Retorno de saldo
                return BadRequest(new {Message = "Erro ao Adicionar Operação, Cotista Inválido!"});
            }

            //Saldo Insuficiente
            if(ex.Message == "SaldoInsuficiente")
            {
                //Retorno de saldo
                return BadRequest(new {Message = "Saldo Cotas insuficiente para venda!"});
            }

            //Tratamento de exceção
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao adcionar Operação. Erro {ex}");
        }
    }

}
