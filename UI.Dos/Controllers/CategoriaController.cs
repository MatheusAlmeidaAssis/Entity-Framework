using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Dos.Models;

namespace UI.Dos.Controllers
{
    public class CategoriaController
    {
        public DbProduto Banco { get; set; }
        public CategoriaController()
        {
            Banco = new DbProduto();
        }
        public void Salvar(Categoria categoria)
        {
            if (categoria.Id > 0)
            {
                var categoriaAlterar = Listar(categoria.Id).FirstOrDefault();
                if (categoriaAlterar.Nome != categoria.Nome)
                    categoriaAlterar.Nome = categoria.Nome;                
            }
            else
            {
                Banco.Categorias.Add(categoria);
            }
            Banco.SaveChanges();
        }
        public IEnumerable<Categoria> Listar(int id = 0)
        {
            if (id > 0)
            {
                var categoria = Banco.Categorias.First(x => x.Id == id);
                var categorias = new List<Categoria>
                {
                    categoria
                };
                return categorias;
            }
            return Banco.Categorias;
        }
        public void Excluir(int id)
        {
            var categoria = Listar(id).FirstOrDefault();
            Banco.Set<Categoria>().Remove(categoria);
            Banco.SaveChanges();
        }
    }
}
