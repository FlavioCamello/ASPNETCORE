using ExemploWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExemploWebApi.Controllers
{
    public class MarcacaoController : ApiController
    {
        private static List<Marcacao> marcacoes = new List<Marcacao>();

        [HttpGet]
        public List<Marcacao> Get()
        {
            if(marcacoes.Count == 0) {
                marcacoes.Add(new Marcacao("26 11 1987", "12 30", 1));
                marcacoes.Add(new Marcacao("26 11 1987", "13 00", 2));
                marcacoes.Add(new Marcacao("26 11 1987", "10 30", 3));
                marcacoes.Add(new Marcacao("26 11 1987", "11 00", 4));
            }
            return marcacoes;
        }

        
        public void Post(Marcacao marcacao)
        {
            if (marcacao != null)
            {
                marcacoes.Add(marcacao);
            }
        }
    }
}
