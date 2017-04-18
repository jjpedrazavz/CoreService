using CoreService.Contratos;
using CoreService.Entities;
using CoreService.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Repository.Implementations
{
    public class MenuBundleRepo : CoreRepo<MenuBundle>, IRepository<MenuBundle>
    {
        public MenuBundleRepo(Hungry4Context context)
        {
            this.Context = context;
            Table = context.MenuBundle;

        }

        public async Task<List<MenuBundle>> getAllAsync(int id)
        {
            return await Table.Where(p => p.MenuBundleId == id).ToListAsync();
        }
    }
}
