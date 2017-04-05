using CoreService.Contratos;
using CoreService.Entities;
using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Repository.Implementations
{
    public class OrdenesRepo : CoreRepo<Ordenes>, IRepository<Ordenes>
    {
        public OrdenesRepo(HungryDbContext context)
        {
            this.Context = context;
            Table = context.Ordenes;
        }

        public override List<Ordenes> GetAll()
        {
            return Table.Include(o => o.Comensal).Include(o => o.Estado).ToList();
        }

        public override Task<List<Ordenes>> GetAllAsync()
        {
            return Table.Include(p => p.Estado).Include(o => o.Comensal).ToListAsync();
        }

        public override Ordenes GetOne(int id)
        {
            return Table.Where(p => p.OrdenId == id).Include(p => p.Comensal).Include(p => p.Estado).FirstOrDefault();
        }

        public override Task<Ordenes> GetOneAsync(int id)
        {
            return Table.Where(p => p.OrdenId == id).Include(p => p.Comensal)
                   .Include(p => p.Estado).Include(p => p.Menu).FirstOrDefaultAsync();
        }

    }
}
