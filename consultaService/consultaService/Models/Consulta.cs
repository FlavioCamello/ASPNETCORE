using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace consultaService.Models
{
    [DataContract]
    public class Consulta
    {
        public Consulta(int id, string data, string hora)
        {
            this.id = id;
            this.data = data;
            this.hora = hora;
        }

        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string data { get; set; }
        [DataMember]
        public string hora { get; set; }
    }
}