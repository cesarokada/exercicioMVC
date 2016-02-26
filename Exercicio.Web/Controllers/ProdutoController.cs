using Exercicio.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercicio.Web.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            WSPRODUTO.ProdutoSvcClient proxy = new WSPRODUTO.ProdutoSvcClient("BasicHttpBinding_IProdutoSvc");
            var produtos = proxy.GetAllProdutos();

            var models = produtos.ToList().ConvertAll<ProdutoVM>(p =>
            {
                return new ProdutoVM
                {
                    Codigo = p.IdProduto,
                    Nome = p.NomeProduto,
                    Quantidade = p.QtdProduto
                };
            });

            return View(models);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            WSPRODUTO.ProdutoSvcClient proxy = new WSPRODUTO.ProdutoSvcClient("BasicHttpBinding_IProdutoSvc");
            var produto = proxy.GetProduto(id);

            var model = new ProdutoVM
            {
                Codigo = produto.IdProduto,
                Nome = produto.NomeProduto,
                Quantidade = produto.QtdProduto
            };

            return View(model);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            var model = new ProdutoVM();
            return View(model);
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoVM model)
        {
            WSPRODUTO.ProdutoSvcClient proxy = new WSPRODUTO.ProdutoSvcClient("BasicHttpBinding_IProdutoSvc");
            try
            {
                var produto = new WSPRODUTO.Produto
                {
                    NomeProduto = model.Nome,
                    QtdProduto = model.Quantidade
                };

                proxy.InsertProduto(produto);                
                return RedirectToAction("Index");                
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            WSPRODUTO.ProdutoSvcClient proxy = new WSPRODUTO.ProdutoSvcClient("BasicHttpBinding_IProdutoSvc");

            var produto = proxy.GetProduto(id);

            var model = new ProdutoVM
            {
                Codigo = produto.IdProduto,
                Nome = produto.NomeProduto,
                Quantidade = produto.QtdProduto
            };

            return View(model);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProdutoVM model)
        {
            WSPRODUTO.ProdutoSvcClient proxy = new WSPRODUTO.ProdutoSvcClient("BasicHttpBinding_IProdutoSvc");
            var produto = proxy.GetProduto(id);
            try
            {                
                produto.IdProduto = model.Codigo;
                produto.NomeProduto = model.Nome;
                produto.QtdProduto = model.Quantidade;
                proxy.ModifyProduto(produto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            WSPRODUTO.ProdutoSvcClient proxy = new WSPRODUTO.ProdutoSvcClient("BasicHttpBinding_IProdutoSvc");
            var produto = proxy.GetProduto(id);
            
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, WSPRODUTO.Produto produto)
        {
            WSPRODUTO.ProdutoSvcClient proxy = new WSPRODUTO.ProdutoSvcClient("BasicHttpBinding_IProdutoSvc");
            try
            {
                proxy.RemoveProduto(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
