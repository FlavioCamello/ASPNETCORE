using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploWebApi.Models
{
    
    public class Marcacao
    {
        public Marcacao(string data, string hora, int id)
        {
            this.hora = hora;
            this.data = data;
            this.id = id;
        }

        public int id { get; set; }
        public String data { get; set; }
        public String hora { get; set; }
    }
    
}