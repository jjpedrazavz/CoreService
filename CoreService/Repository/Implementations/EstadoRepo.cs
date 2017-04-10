using CoreService.Contratos;
using CoreService.Entities;
using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.Repository.Implementations
{
    public class EstadoRepo :CoreRepo<Estado>, IRepository<Estado>
    {
        public EstadoRepo(Hungry4Context context)
        {
            this.Context = context;
            Table = context.Estado;
        }

        public Task<List<Estado>> getAllAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
