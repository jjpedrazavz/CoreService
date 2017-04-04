using CoreService.Contratos;
using CoreService.Entities;
using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.Repository.Implementations
{
    public class CategoriasRepo: CoreRepo<Categorias>, IRepository<Categorias>
    {
        public CategoriasRepo(HungryDbContext context)
        {
            this.Context = context;
            Table = context.Categorias;

        }
    }
}
