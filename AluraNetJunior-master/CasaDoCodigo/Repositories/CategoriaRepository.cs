using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task AddCategoria(String nomeCategoria);
        Categoria GetCategoria(String nomeCategoria);
    }
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task AddCategoria(string nomeCategoria)
        {
            var categorias = dbSet.ToList();
            foreach(var cat in categorias)
            {
                if (cat.Nome.Equals(nomeCategoria))
                {
                    return;
                }              
            }
            var categoria = new Categoria(nomeCategoria);
            contexto.Set<Categoria>()
                .Add(categoria);        
                await contexto.SaveChangesAsync();
            }

        public Categoria GetCategoria(String nomeCategoria)
        {
            var categoria =   dbSet
                            .Where(p => p.Nome == nomeCategoria)
                            .SingleOrDefault();

            return categoria;
            
        }
    }
    }

