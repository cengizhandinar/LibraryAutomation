using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Library.Core.Entities.Abstract;

namespace Library.Core.Data.Abstract
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Bu method kendisine verilecek Id değişkeni ile sorgulama yapacak ve geriye interface e verilen tipte dönüş yapacak
        /// </summary>
        /// <param name="id">Aranan kaydın Guid tipinde Id bilgisi</param>
        T Find(int id);
        /// <summary>
        /// Kendisine gönderilen tipteki sınıfı veritabanına eklemek için kullanılacak
        /// </summary>
        T Add(T entity);
        /// <summary>
        /// Kendisine gönderilen tipteki sınıfı veritabanında güncellemek için kullanılacak
        /// </summary>
        T Update(T entity);
        /// <summary>
        /// Kendisine gönderilen tipteki sınıf ile veritabanında silme işlemi yapacak
        /// </summary>
        void Delete(T entity);
        /// <summary>
        /// Kendisine gönderilen bir expression ile yani linq sorguları ile veritabanında tüm verileri aramadan ilgili sorguya göre verileri arayıp geriye bir bool sonuc döndürür
        /// </summary>
        bool Any(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Kendisine gönderilen bir expression ile yani linq sorguları ile veritabanında işlem yapmadan önce  ilgili sorguya göre verileri bulup geriye bir int sonuc döndürür
        /// </summary>
        int Count(Expression<Func<T, bool>> predicate = null);
        /// <summary>
        /// Kendisine gönderilen bir expression ile yani linq sorguları ile veritabanından tüm verileri getirmeden ilgili sorguya göre kendisine gönderilen tipte bir varlık döndürür
        /// </summary>
        T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        /// <summary>
        /// Kendisine gönderilen bir expression ile yani linq sorguları ile veritabanından tüm verileri getirmeden ilgili sorguya göre verileri getirecek bir IList döndürür
        /// </summary>
        IList<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
    }
}