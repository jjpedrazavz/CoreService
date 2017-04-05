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
    public class AlimentosRepo: CoreRepo<Alimentos>, IRepository<Alimentos>
    {
        public AlimentosRepo(HungryDbContext context)
        {
            this.Context = context;
            Table = context.Alimentos;

        }

        public override Task<List<Alimentos>> GetAllAsync()
        {
            return Table.Include(p => p.Categoria).Include(p => p.Tipo).ToListAsync();
        }

        
        public override Task<Alimentos> GetOneAsync(int id)
        {
            return Table.Where(p => p.Id == id).Include(p => p.Categoria).Include(p => p.Tipo).Include(p => p.FoodImageMapping).FirstOrDefaultAsync();
        }

    }
}
