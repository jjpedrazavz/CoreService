using CoreService.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreService.Models;
using CoreService.Entities;

namespace CoreService.Repository.Implementations
{
    public class AlimentosRepo: CoreRepo<Alimentos>, IRepository<Alimentos>
    {
        public AlimentosRepo(Hungry4Context context)
        {
            this.Context = context;
            Table = context.Alimentos;

        }

        public override Task<List<Alimentos>> GetAllAsync()
        {
            return Table.Include(p => p.Categoria).Include(p => p.Tipo).ToListAsync();
        }

        public Task<List<Alimentos>> getAllAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<Alimentos> GetOneAsync(int id)
        {
            return Table.Where(p => p.Id == id).Include(p => p.Categoria).Include(p => p.Tipo).Include(p => p.FoodImageMapping).FirstOrDefaultAsync();
        }

    }
}
