using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Library.Core.Data.Abstract;
using Library.Core.Entities.Abstract;

namespace Library.Core.Data.Concrete
{
    /// <summary>
    /// Daha önce oluşturduğumuz IGenericRepository interface ini implemente eden sınıfımız
    /// Interface üzerinde sadece metot imzalarını yani tanımlarını bildirmiştik.
    /// Bu sınıf arayüzde belirttiğimiz imzalara sahip metotları uygulamak zorundadır.
    /// Generic olarak uygulanan Repository pattern tekrarlı kod yazmanın önüne geçerek kodun yönetilebilirliğini kolaylaştırmaktadır.
    /// Bu sınıfın amacı oluşturduğumuz entitylerde yapılacak CRUD işlemlerini tek noktadan yönetmesi.
    /// Ancak dikkat ettiyseniz burada bir SaveChanges yani değişiklikleri veritabanına ilet komutu bulunmuyor
    /// Bunun nedeni bizim o işlemi UnitOfWork ile yapacak oluşumuz.
    /// </summary>
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        #region Variables

        //Database işlemleri için DbContext tablo işlemleri için ise DbSet sınıfını kullanacağız
        private readonly DbSet<T> _dbSet;
        protected readonly DbContext Context;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Yapıcı method bizim için Dependency Injection kullanarak DbContext örneği oluşturuyor.
        /// </summary>
        public GenericRepository(DbContext context)
        {
            //Değişkenlere değer ataması yapıyoruz.
            Context = context;
            _dbSet = Context.Set<T>();
        }

        #endregion Constructor

        #region GetterMethods

        /// <summary>
        /// İstenen tipteki sınıfı gönderilen Id parametresi ile arayan ve döndüren metot
        /// </summary>
        public T Find(int id)
        {
            return _dbSet.Find(id); ;
        }
        /// <summary>
        ///  Geriye IQueryable tipinde dbSet nesnesini ilgili parametler kontrol edildikten sonra SingleOrDefault ile çevirerek dönüyoruz.
        /// </summary>
        public T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> entities = _dbSet;
            entities = entities.Where(predicate);
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    entities = entities.Include(includeProperty);
                }
            }
            return entities.SingleOrDefault();
        }
        /// <summary>
        ///  Geriye IQueryable tipinde dbSet nesnesini ilgili parametler kontrol edildikten sonra listeye çevirerek dönüyoruz.
        /// </summary>
        public IList<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> entities = _dbSet;
            if (predicate != null) entities = entities.Where(predicate);
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    entities = entities.Include(includeProperty);
                }
            }
            return entities.ToList();
        }

        #endregion GetterMethods

        #region SetterMethods

        /// <summary>
        /// Gönderilen entity nesnesinin veritabanına eklenmesi için kuyruğa alan metot
        /// </summary>
        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }
        /// <summary>
        /// Gönderilen entity nesnesinin veritabanında update edilmesi için önce Attach ederek daha sonrada durumunu Modified yaparak kuyruğa alan metot
        /// </summary>
        public T Update(T entity)
        {
            if (entity != null)
                Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        /// <summary>
        /// Kendisine gönderilen entity nesnesinin silinmesi için önce attach olup olmadığını kontrol ediyor eğer değil ise attach ederek
        /// silinmesi için kuyruğa ekliyoruz. SaveChanges komutu gelene kadar bu silme işlemi gerçekleşmeyecek. O komutu da UnitOfWork sınıfında vereceğiz.
        /// </summary>
        public void Delete(T entity)
        {
            _dbSet.Remove(entity); ;
        }

        #endregion SetterMethods

        #region OtherMethods

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Any(predicate);
        }
        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            return (predicate == null ? Context.Set<T>().Count() : Context.Set<T>().Count(predicate));
        }

        #endregion OtherMethods
    }
}