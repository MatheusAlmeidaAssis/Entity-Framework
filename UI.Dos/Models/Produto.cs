using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Dos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public Categoria Categoria { get; set; }//relação um pra muitos
        public virtual ICollection<ListaCompra> ListaCompras { get; set; }
    }
}
