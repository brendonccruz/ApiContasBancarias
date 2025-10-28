using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using MinhaNovaApi.Data;

namespace MinhaNovaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContasController : ControllerBase
{
    private readonly ApiDbContext _context;

    public ContasController(ApiDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> GetTodasAsContas()
    {
        var contas = await _context.Contas.ToListAsync();
        return Ok(contas);
    }

    [HttpGet("{numeroDaConta}")]
    public async Task<IActionResult> GetContaPorNumero(string numeroDaConta)
    {
        var conta = await _context.Contas
            .FirstOrDefaultAsync(c => c.NumeroConta == numeroDaConta);

        if (conta == null)
        {
            return NotFound("A conta com este número não foi encontrada.");
        }

        return Ok(conta);
    }

    [HttpPost]
    public async Task<IActionResult> PostNovaConta([FromBody] CriarContaRequest request)
    {
        var novaConta = new ContaEmpresarial(
            request.NumeroConta,
            request.Titular,
            request.LimiteEmprestimo
        );

        _context.Contas.Add(novaConta);
        
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetContaPorNumero),
            new { numeroDaConta = novaConta.NumeroConta },
            novaConta
        );
    }

    [HttpPut("{numeroDaConta}")]
    public async Task<IActionResult> PutAtualizarConta(string numeroDaConta, [FromBody] AtualizarContaRequest request)
    {
        var conta = await _context.Contas
            .FirstOrDefaultAsync(c => c.NumeroConta == numeroDaConta);

        if (conta == null)
        {
            return NotFound("Conta não encontrada para atualização.");
        }

        conta.Titular = request.Titular;
        conta.LimiteEmprestimo = request.LimiteEmprestimo;
        
        await _context.SaveChangesAsync();

        return Ok(conta);
    }

    [HttpDelete("{numeroDaConta}")]
    public async Task<IActionResult> DeleteConta(string numeroDaConta)
    {
        var conta = await _context.Contas
            .FirstOrDefaultAsync(c => c.NumeroConta == numeroDaConta);

        if (conta == null)
        {
            return NotFound("Conta não encontrada para exclusão.");
        }

        _context.Contas.Remove(conta);
        
        await _context.SaveChangesAsync();

        return NoContent();
    }
}