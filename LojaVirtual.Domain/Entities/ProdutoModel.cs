using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Entites
{
    public class ProdutoModel
    {
        public int IdProduto { get; set; }
        public string? DescricaoProduto { get; set; }
        public float ValorUnitario { get; set; }
    }
}
