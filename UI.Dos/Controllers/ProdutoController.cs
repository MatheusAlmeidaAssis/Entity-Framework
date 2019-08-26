using System.Collections.Generic;
using System.Linq;
using UI.Dos.Models;
using System.Data.Entity;

namespace UI.Dos.Controllers
{
    public class ProdutoController
    {
        public DbProduto Banco { get; set; }
        public ProdutoController()
        {
            Banco = new DbProduto();
        }
        public void Salvar(Produto produto)
        {
            if (produto.Id > 0)
            {
                var produtoAlterar = Listar(produto.Id).FirstOrDefault();
                if (produtoAlterar.Nome != produto.Nome)
                    produtoAlterar.Nome = produto.Nome;
                if (produtoAlterar.Categoria != produto.Categoria)
                    produtoAlterar.Categoria = produto.Categoria;
            }
            else
            {
                produto.Categoria = Banco.Categorias.First(x => x.Id == produto.Categoria.Id);
                Banco.Produtos.Add(produto);
            }
            Banco.SaveChanges();
        }
        public IEnumerable<Produto> Listar(int id = 0)
        {
            if (id > 0)
            {
                var produto = Banco.Produtos.Include(x => x.Categoria).First(x => x.Id == id);
                var produtos = new List<Produto>
                {
                    produto
                };
                return produtos;
            }
            return Banco.Produtos.Include(x=> x.Categoria);
        }
        public void Excluir(int id)
        {
            var produto = Listar(id).FirstOrDefault();
            Banco.Set<Produto>().Remove(produto);
            Banco.SaveChanges();
        }
    }
}
