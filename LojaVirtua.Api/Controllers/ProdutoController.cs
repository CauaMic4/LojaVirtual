using LojaVirtual.Domain.Entites;
using LojaVirtual.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtua.Api.Controllers
{
    [Route(nameof(ProdutoController))]
    public class ProdutoController : Controller, IDisposable
    {
        private readonly ApplicationDbContext _context;
        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region GET METHODS
        [HttpGet("GetProduto")]
        public async Task<IActionResult> GetCliente()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://camposdealer.dev/Sites/TesteAPI/produto");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return Ok(responseBody);
        }
        #endregion

        #region POST/PUT METHODS
        [HttpPost("InsertProduct")]
        public async Task<IActionResult> InsertProduct([FromBody] ProdutoModel model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

            return Ok();
        }

        [HttpPut("EditProduct/{idProduto}")]
        public async Task<IActionResult> EditProduct(int idProduto)
        {
            if (ModelState.IsValid)
            {
                var model = await _context.Produto.FirstOrDefaultAsync(x => x.IdProduto.Equals(idProduto));
                _context.Update(model);
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            else
                return BadRequest("Erro na edição");

            return Ok();
        }

        [HttpDelete("DeleteProduct/{idProduto}")]
        public async Task<IActionResult> DeleteClient(int idProduto)
        {
            var model = await _context.Produto.FindAsync(idProduto);

            _context.Produto.Remove(model);

            await _context.SaveChangesAsync();

            return Ok();
        }
        #endregion
    }
}
