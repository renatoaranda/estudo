using TesteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace TesteWebApi.Controllers
{
    public class LivroController : ApiController
    {
        Livro[] livros = new Livro[]{
            new Livro{Id=1, Nome="Refactoring", Categoria="Best Pratices", Preco=45.60M},
            new Livro{Id=2, Nome="ASP", Categoria="Web", Preco=20.50M},
            new Livro{Id=3, Nome="Code Clean", Categoria="Best Pratices", Preco=15.00M}
        };

        [Filtro]
        public IEnumerable<Livro> Get()
        {
            return livros;
        }

        public Livro Get(int id)
        {
            var livro = livros.FirstOrDefault((p) => p.Id == id);
            if (livro == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return livro;
        }

        public IEnumerable<Livro> GetLivrosByCategory(string categoria)
        {
            return
                livros.Where(x => string.Equals(x.Categoria, categoria,
                    StringComparison.OrdinalIgnoreCase));
        }

    }
}
