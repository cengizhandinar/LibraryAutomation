using System;
using Library.Core.Enum;

namespace Library.Core.Entities.Abstract
{
    /// <summary>
    /// Tüm entitylerimizde bulunması gereken propertyleri bu base class ile tanımlıyoruz.
    /// Bu sınıfımızı inherit alacak derived class'ımız dğrudan aşağıdaki propertylere sahip olacak ve biz tekrarlı kod yazmak zorunda kalmayacağız
    /// Eğer bu sınıf türetildiğinde ilgili alanlar null ise default olarak yanlarında belirtilen değerler atanacak.
    /// Buradaki bir diğer detay ise GeneralStatus complex tipi. Bu bize içerisinde bulunan IsActive, IsDeleted gibi proplar ile yardımcı olacak.
    /// Data ve Dto arasındaki value transferlerini AutoMapper kullanarak yapacağız.
    /// </summary>
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
        public string CreatedByName { get; set; } = "Admin";
        public string UpdatedByName { get; set; } = "Admin";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public GeneralStatus GeneralStatus { get; set; } = GeneralStatus.Active;
    }
}