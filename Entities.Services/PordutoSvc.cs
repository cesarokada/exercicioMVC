using DB.Entities;
using DB.Persistence;
using IContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Services
{
    public class PordutoSvc : IProdutoSvc
    {
        public List<Produto> GetAllProdutos()
        {
            var produtos = new List<Produto>();

            using(var context = new Context())
            {
                produtos = context.Produtos.ToList();
            }

            return produtos;
        }

        public Produto GetProduto(int Id)
        {
            Produto p = new Produto();

            using (var context = new Context())
            {
                p = context.Produtos.FirstOrDefault(x => x.IdProduto == Id);
            }
            return p;
        }

        public void InsertProduto(Produto p)
        {
            using (var context = new Context())
            {
                context.Produtos.Add(p);
                context.SaveChanges();
            }
        }

        public void ModifyProduto(Produto p)
        {
            using (var context = new Context())
            {
                Produto pUpdate = context.Produtos.FirstOrDefault(x => x.IdProduto == p.IdProduto);
                pUpdate.NomeProduto = p.NomeProduto;
                pUpdate.QtdProduto = p.QtdProduto;
                context.SaveChanges();
            }
        }

        public void RemoveProduto(int Id)
        {
            using (var context = new Context())
            {
                Produto p = context.Produtos.FirstOrDefault(x => x.IdProduto == Id);
                context.Produtos.Remove(p);
                context.SaveChanges();
            }
        }
    }
}
