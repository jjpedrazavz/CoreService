using CoreService.Contratos;
using CoreService.Entities;
using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Repository.Implementations
{
    public class FoodImageMappingRepo: CoreRepo<FoodImageMapping>, IRepository<FoodImageMapping>
    {
        public FoodImageMappingRepo(Hungry4Context context)
        {
            this.Context = context;
            Table = context.FoodImageMapping;

        }

        public Task<List<FoodImageMapping>> getAllAsync(int id)
        {
            return Table.Include(p => p.AlimentosImage).Where(p => p.AlimentosImageId == id).ToListAsync();

        }

        public override Task<FoodImageMapping> GetOneAsync(int id)
        {
            return Table.Where(p => p.Id == id).Include(p => p.AlimentosImage).FirstOrDefaultAsync();
        }


    }
}
