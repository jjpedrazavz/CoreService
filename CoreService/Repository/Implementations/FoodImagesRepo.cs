﻿using CoreService.Contratos;
using CoreService.Entities;
using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Repository.Implementations
{
    public class FoodImagesRepo: CoreRepo<FoodImages>, IRepository<FoodImages>
    {
        public FoodImagesRepo(Hungry4Context context)
        {
            this.Context = context;
            Table = context.FoodImages;

        }

        public override List<FoodImages> GetAll()
        {
            return Table.ToList();
        }

        public Task<List<FoodImages>> getAllAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<FoodImages> GetOneAsync(int id)
        {

            return Table.Include(p => p.FoodImageMapping).Where(p => p.Id == id).FirstOrDefaultAsync();

        }

    }
}
