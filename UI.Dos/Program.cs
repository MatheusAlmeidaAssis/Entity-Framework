using System;
using UI.Dos.Controllers;
using UI.Dos.Models;

namespace UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctlProduto = new ProdutoController();            
            ctlProduto.Excluir(2);
            var produtos = ctlProduto.Listar();
            foreach (var item in produtos)
            {
                Console.WriteLine("{0} - {1}", item.Id, item.Nome);
            }            
            Console.ReadKey();
        }
    }
}
