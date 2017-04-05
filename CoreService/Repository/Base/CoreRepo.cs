using CoreService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.Repository
{
    /// <summary>
    /// Logica basica que debe ser implementada para Tabla, de forma generica.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CoreRepo<T> where T : class, new()
    {
        public HungryDbContext Context;

        protected DbSet<T> Table;

        internal int SaveChanges()
        {
            try
            {

                return Context.SaveChanges();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                Debug.WriteLine("Error Con la peracion async" + ex.Message);
                throw new Exception(ex.Message);
            }
            catch(DbUpdateException ex)
            {
                Debug.WriteLine("Error Al actualizar los datos en" + ex.Message);
                throw new Exception(ex.Message);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error en" + ex.Message);
                throw new Exception(ex.Message);
            }

        }

        internal async Task<int> SaveChangesAsync()
        {
            try
            {

                return await Context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                Debug.WriteLine("Error Con la peracion async" + ex.Message);
                throw new Exception(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                Debug.WriteLine("Error Al actualizar los datos en" + ex.Message);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error en" + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public virtual T GetOne(int id)
        {
           return  Table.Find(id);
        }

        public virtual async Task<T> GetOneAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public virtual List<T> GetAll()
        {
            return Table.ToList();
        }

        public int Add(T entity)
        {
            Table.Add(entity);

            return SaveChanges();
        }

        public async Task<int> AddAsync(T entity)
        {
            Table.Add(entity);

            return await SaveChangesAsync();
        }

        public int AddRange(List<T> entities)
        {
            Table.AddRange(entities);
            return SaveChanges();
        }

        public async Task<int> AddRangeAsync(List<T> entites)
        {
            Table.AddRange(entites);

            return await SaveChangesAsync();
        }

        public int Save(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public async Task<int> SaveAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;

            return await SaveChangesAsync();
        }

        public int Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return await SaveChangesAsync();
        }

        public async Task<bool> ContainsAsync(T entity)
        {
            return await Table.ContainsAsync(entity);
        }
    }
}
