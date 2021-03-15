using System;
using AutoMapper;
using Library.Data.Abstract;
using Library.Services.AutoMapper;

namespace Library.Services.Concrete
{
    /// <summary>
    /// Tüm Manager sınıflarımızda kullanacağımız arabirimleri her manager sınıfının constructorlarına tek tek uygulamamak için
    /// ManagerBase sınıfından miras alarak Dependency Injection ile yapıcı metotların oluşmasını sağlarız.
    /// </summary>
    public class ManagerBase
    {
        public ManagerBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper => _lazy.Value;
        private readonly Lazy<IMapper> _lazy = new Lazy<IMapper>(() =>
        {
            var configuration = new MapperConfiguration(configure =>
            {
                configure.AddProfile<EntityProfiles>();
            });
            return configuration.CreateMapper();
        });
    }
}