using LojaVirtual.Domain.Entites;
using LojaVirtual.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtualAPI.Controllers
{
    [Route(nameof(VendasController))]
    public class VendasController : Controller, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public VendasController(ApplicationDbContext context)
        {
            _context = context;
        }
        #region GET METHODS
        [HttpGet("GetVendas")]
        public async Task<IActionResult> GetVendas()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://camposdealer.dev/Sites/TesteAPI/venda");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return Ok(responseBody);
        }
        #endregion

        #region POST/PUT METHODS
        [HttpPost("InsertProduct")]
        public async Task<IActionResult> InsertProduct([FromBody] VendaModel model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpPut("EditProduct/{idVenda}")]
        public async Task<IActionResult> EditProduct(int idProduto, [FromBody] VendaModel model)
        {
            if (idProduto != model.IdVenda)
            {
                return BadRequest("O ID do produto na URL não corresponde ao ID do produto no corpo da solicitação.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Modelo inválido.");
            }

            try
            {
                var existingProduct = await _context.Produto.FindAsync(idProduto);
                if (existingProduct == null)
                {
                    return NotFound("Produto não encontrado.");
                }

                existingProduct.IdProduto = model.IdVenda;
                //existingProduct.DescricaoProduto = model.QuantidadeVenda;
                //existingProduct.ValorUnitario = model.ValorUnitario;

                _context.Update(existingProduct);
                await _context.SaveChangesAsync();

                return Ok(existingProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("DeleteProdutct/{idVenda}")]
        public async Task<IActionResult> DeleteProdutct(int idProduto)
        {
            var model = await _context.Produto.FindAsync(idProduto);

            _context.Produto.Remove(model);

            await _context.SaveChangesAsync();

            return Ok();
        }
        #endregion
    }
}
