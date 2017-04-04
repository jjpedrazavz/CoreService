using CoreService.Contratos;
using CoreService.Entities;
using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.Repository.Implementations
{
    public class AlimentosRepo: CoreRepo<Alimentos>, IRepository<Alimentos>
    {
        public AlimentosRepo(HungryDbContext context)
        {
            this.Context = context;
            Table = context.Alimentos;

        }
    }
}
