using CoreService.Contratos;
using CoreService.Entities;
using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.Repository.Implementations
{
    public class TipoRepo: CoreRepo<Tipos>, IRepository<Tipos>
    {
        public TipoRepo(HungryDbContext context)
        {
            this.Context = context;
            Table = context.Tipos;
        }
    }
}
