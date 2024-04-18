using LojaVirtual.Domain.Entites;
using LojaVirtual.Infra.Data;
using LojaVirtualAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtua.Api.Controllers
{
    [Route(nameof(ClienteController))]
    public class ClienteController : Controller, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }
        #region GET METHODS
        [HttpGet("GetCliente")]
        public async Task<IActionResult> GetCliente()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://camposdealer.dev/Sites/TesteAPI/cliente");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return Ok(responseBody);
        }
        #endregion

        #region POST/PUT METHODS
        [HttpPost("InsertClient")]
        public async Task<IActionResult> InsertClient([FromBody] ClienteModel model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("EditClient/{IdCliente}")]
        public async Task<IActionResult> EditClient(int IdCliente)
        {
            if (ModelState.IsValid)
            {
                var model = await _context.Produto.FirstOrDefaultAsync(x => x.IdProduto.Equals(IdCliente));
                _context.Update(model);
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            else
                return BadRequest("Erro na edição");
        }

        [HttpDelete("DeleteClient/{IdCliente}")]
        public async Task<IActionResult> DeleteClient(int IdCliente)
        {
            var model = await _context.Cliente.FindAsync(IdCliente);

            if (model == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _context.Cliente.Remove(model);

            await _context.SaveChangesAsync();

            return Ok();
        }
        #endregion
    }
}
