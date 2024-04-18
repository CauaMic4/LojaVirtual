using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Entites
{
    public class VendaModel
    {
        public VendaModel()
        {
            
            DataVenda = DateTime.Now;
        }

        public VendaModel(int idProduto)
        {

            ValorVenda = QuantidadeVenda + Produtos.FirstOrDefault(x => x.IdProduto.Equals(idProduto)).ValorUnitario;
        }
        public int IdVenda { get; set; }
        public virtual ICollection<ClienteModel> Clientes { get; set; }
        public virtual ICollection<ProdutoModel> Produtos { get; set; }
        public int QuantidadeVenda { get; set; }
        public float ValorVenda { get; private set; }
        public DateTime DataVenda { get; set; }


        public void CalcularValorVenda()
        {
            if (Produtos != null && Produtos.Any())
            {
                float valorTotalProdutos = Produtos.Sum(p => p.ValorUnitario);
                ValorVenda = QuantidadeVenda * valorTotalProdutos;
            }
            else
            {
                ValorVenda = 0;
            }
        }
    }
}
