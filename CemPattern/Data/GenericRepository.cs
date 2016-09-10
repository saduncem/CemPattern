﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CemPattern.Models;
using System.Data.Entity;
namespace CemPattern.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly LUCA_DBEntities _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(LUCA_DBEntities context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Tüm kayıtlar.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        /// <summary>
        /// Kayıt bul.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Kayıt ekle.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Kayıt güncelle.
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// Kayıt sil.
        /// </summary>
        /// <param name="id">Kayıt id</param>
        public virtual void Delete(int id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Kayıt sil.
        /// </summary>
        /// <param name="entityToDelete">Kayıt</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
    }
}