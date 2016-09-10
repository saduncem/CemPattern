using CemPattern.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CemPattern.Models;
namespace CemPattern.Service
{
    public class LucaDataService : ILucaDataService
    {
        
        
        private readonly IUnitOfWork _uow;
        private readonly IGenericRepository<edefter> _edefRepository;


        public LucaDataService(IUnitOfWork uow)
        {
            _uow = uow;
            _edefRepository = uow.GetRepository<edefter>();
         
        }
 
        /// <summary>
        /// Tüm roller.
        /// </summary>
        /// <returns></returns>
        public IQueryable<edefter> GetAll()
        {
            return _edefRepository.GetAll();
        }
 
     
 
        /// <summary>
        /// Rol bul.
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public edefter Find(int roleId)
        {
            return _edefRepository.Find(roleId);
        }
 
      
 
        /// <summary>
        /// Kullanıcı ekle.
        /// </summary>
        /// <param name="role"></param>
        public void Insert(edefter role)
        {
            _edefRepository.Insert(role);
        }
 
        /// <summary>
        /// Kullanıcı güncelle.
        /// </summary>
        /// <param name="role"></param>
        public void Update(edefter role)
        {
            _edefRepository.Update(role);
        }
 
        /// <summary>
        /// Kullanıcı sil.
        /// </summary>
        /// <param name="role">Rol</param>
        public void Delete(edefter     role)
        {
            _edefRepository.Delete(role);
        }
 
        /// <summary>
        /// Kullanıcı sil.
        /// </summary>
        /// <param name="roleId">Rol Id</param>
        public void Delete(int roleId)
        {
            _edefRepository.Delete(roleId);
        }
    }
}