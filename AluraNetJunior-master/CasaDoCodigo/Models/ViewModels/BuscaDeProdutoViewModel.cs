using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutoViewModel
    {
        public BuscaDeProdutoViewModel()
        {
        }

        public BuscaDeProdutoViewModel(IList<Produto> produtos)
        {
            this.Produtos = produtos;
        }

        public IList<Produto> Produtos { get; }
        public String Pesquisa { get; set; }
    }
}
