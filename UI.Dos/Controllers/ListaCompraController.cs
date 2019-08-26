using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using UI.Dos.Models;

namespace UI.Dos.Controllers
{
    public class ListaCompraController
    {
        public DbProduto Banco { get; set; }
        public ListaCompraController()
        {
            Banco = new DbProduto();
        }
        public void Salvar(ListaCompra listaCompra)
        {
            if (listaCompra.Id > 0)
            {
                var listaCompraAlterar = Listar(listaCompra.Id).FirstOrDefault();
                if (listaCompraAlterar.Descricao != listaCompra.Descricao)
                    listaCompraAlterar.Descricao = listaCompra.Descricao;
                if (listaCompraAlterar.Produtos != listaCompra.Produtos.Select(produto => Banco.Produtos.FirstOrDefault(x => x.Id == produto.Id)).ToList())
                    listaCompraAlterar.Produtos = listaCompra.Produtos.Select(produto => Banco.Produtos.FirstOrDefault(x => x.Id == produto.Id)).ToList();
            }
            else
            {
                listaCompra.Produtos = listaCompra.Produtos.Select(produto => Banco.Produtos.FirstOrDefault(x=>x.Id == produto.Id)).ToList();
                Banco.ListaCompras.Add(listaCompra);
            }
            Banco.SaveChanges();
        }
        public IEnumerable<ListaCompra> Listar(int id = 0)
        {
            if (id > 0)
            {
                var listaCompra = Banco.ListaCompras.Include(x=>x.Produtos).Include(x=>x.Produtos.Select(c=>c.Categoria)).First(x => x.Id == id);
                var listaCompras = new List<ListaCompra>
                {
                    listaCompra
                };
                return listaCompras;
            }
            return Banco.ListaCompras.Include(x => x.Produtos).Include(x => x.Produtos.Select(c => c.Categoria));
        }
        public void Excluir(int id)
        {
            var listaCompra = Listar(id).FirstOrDefault();
            listaCompra.Produtos = null;
            Banco.Set<ListaCompra>().Remove(listaCompra);
            Banco.SaveChanges();
        }
    }
}
