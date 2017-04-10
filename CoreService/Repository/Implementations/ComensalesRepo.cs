using CoreService.Contratos;
using CoreService.Entities;
using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.Repository.Implementations
{
    public class ComensalesRepo : CoreRepo<Comensales>, IRepository<Comensales>
    {
        public ComensalesRepo(Hungry4Context context)
        {
            this.Context = context;
            Table = context.Comensales;

        }

        public Task<List<Comensales>> getAllAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
