using System;
using Library.Core.Data.Abstract;
using Library.Core.Entities.Abstract;

namespace Library.Data.Abstract
{
    /// <summary>
    /// Oluşturacağımız UnitofWork sınıfının içermesi gereken metotlara ait imzaları bu kısımda tanımlayacağız.
    /// UnitofWork sınıfını türetirken doğrudan değil bu interface'i kullanarak türeteceğiz Böylece dependency injection yaparak
    /// kodumuza esneklik kazandırmış olacağız.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Veritabanında işlemlerin yapılması emrini veren kısım olacak
        /// Repository içerisinde kuyruğa aldığımız tüm işlemler bu metot çalıştırıldığı anda sırası ile veritabanında değişikliğe uğrayacak
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// Gerektiğinde repository instance oluşturmak için kullanılacak.
        /// </summary>
        IGenericRepository<T> GetRepository<T>() where T : class, IEntity, new();
    }
}
