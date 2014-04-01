using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteWebApi.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
    }
}