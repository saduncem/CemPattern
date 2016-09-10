using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CemPattern.Models;
namespace CemPattern.Service
{
    public interface ILucaDataService
    {

        /// <summary>
        /// Tüm roller.
        /// </summary>
        /// <returns></returns>
        IQueryable<edefter> GetAll();

      

        /// <summary>
        /// Rol bul.
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        edefter Find(int roleId);

        /// <summary>
        /// Kullanıcı role sahip mi.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
      

        /// <summary>
        /// Kullanıcı ekle.
        /// </summary>
        /// <param name="role"></param>
        void Insert(edefter edefter);

        /// <summary>
        /// Kullanıcı güncelle.
        /// </summary>
        /// <param name="role"></param>
        void Update(edefter edefter);

        /// <summary>
        /// Kullanıcı sil.
        /// </summary>
        /// <param name="role">Rol</param>
        void Delete(edefter role);

        /// <summary>
        /// Kullanıcı sil.
        /// </summary>
        /// <param name="roleId">Rol Id</param>
        void Delete(int roleId);
    }
}