using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Entites
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }
        public string? nmCliente { get; set; }
        public string? Cidade { get; set; }
    }
}
