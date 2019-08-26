using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Dos.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<Produto> Produtos { get; set; }
    }
}
