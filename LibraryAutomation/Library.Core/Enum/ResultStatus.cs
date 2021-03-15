namespace Library.Core.Enum
{
    /// <summary>
    /// Projemiz içerisinde kullanacağımız durumları bu tarz classlar içerisinde yazarak bir araya toplamış olacağız.
    /// Bu sayede bir durum ataması yaparken ya da kontrol gerçekleştirirken bu enumlar'ı kullanmak yeterli olacak.
    /// Bu durum üzerinde ilgili CRUD operasyonlarının sonucunda işlemlerin başarı durumları belirlenir..
    /// </summary>
    public enum ResultStatus
    {
        Success,
        Error,
        Warning,
        Info
    }
}