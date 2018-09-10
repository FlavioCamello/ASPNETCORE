using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository,
            IPedidoRepository pedidoRepository,
            IItemPedidoRepository itemPedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public IActionResult Carrossel()
        {
            return View(produtoRepository.GetProdutos());
        }

        public async Task<IActionResult> Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                await pedidoRepository.AddItem(codigo);
            }

            Pedido taskPedido = await pedidoRepository.GetPedido();
            List<ItemPedido> itens = taskPedido.Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return base.View(carrinhoViewModel);
        }

        public async Task<IActionResult> Cadastro()
        {
            var pedido = await pedidoRepository.GetPedido();

            if (pedido == null)
            {
                return RedirectToAction("Carrossel");
            }

            return View(pedido.Cadastro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Resumo(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                return View(await pedidoRepository.UpdateCadastro(cadastro));
            }
            return RedirectToAction("Cadastro");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<UpdateQuantidadeResponse> UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            return await pedidoRepository.UpdateQuantidade(itemPedido);
        }

        
        public IActionResult BuscaDeProdutos(String pesquisa)
        {
            if (string.IsNullOrEmpty(pesquisa))
            {
                IList<Produto> produtos = produtoRepository.GetProdutos();
                BuscaDeProdutoViewModel buscaDeProdutoViewModel = new BuscaDeProdutoViewModel(produtos);
                pesquisa = "";
                return View(buscaDeProdutoViewModel);
            }
            else
            {
                IList<Produto> produtos = produtoRepository.GetProdutos(pesquisa);
                BuscaDeProdutoViewModel buscaDeProdutoViewModel = new BuscaDeProdutoViewModel(produtos);
                //buscaDeProdutoViewModel.Pesquisa = pesquisa;
                return View(buscaDeProdutoViewModel);
            }
        }

      /*  [HttpPost]
        public IActionResult BuscaDeProdutos(String pesquisa)
        {
            //if (string.IsNullOrEmpty(busca))
            // {
            IList<Produto> produtos = produtoRepository.GetProdutos();
            BuscaDeProdutoViewModel buscaDeProdutoViewModel = new BuscaDeProdutoViewModel(produtos);
            //busca = "";
            return View(buscaDeProdutoViewModel);
            //  }N
            //  else
            //  {
            //    IList<Produto> produtos = produtoRepository.GetProdutos();
            //    BuscaDeProdutoViewModel buscaDeProdutoViewModel = new BuscaDeProdutoViewModel(produtos);
            //    //buscaDeProdutoViewModel.Busca = busca;
            //     return View(buscaDeProdutoViewModel);
            // }
        }*/
    }
}
