using CoreService.Contratos;
using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreService.Entities;

namespace CoreService.Repository.Implementations
{
    public class MenuRepo: CoreRepo<Menu>, IRepository<Menu>
    {
        public MenuRepo(Hungry4Context context)
        {
            this.Context = context;
            Table = context.Menu;
        }

        public async Task<List<Menu>> getAllAsync(int orderID)
        {
            return await Table.Include(p => p.Alimento).Where(p => p.OrdenId == orderID).ToListAsync();
        }

    }
}
