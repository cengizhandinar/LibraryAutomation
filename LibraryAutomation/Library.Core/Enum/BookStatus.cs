namespace Library.Core.Enum
{
    /// <summary>
    /// Projemiz içerisinde kullanacağımız durumları bu tarz classlar içerisinde yazarak bir araya toplamış olacağız.
    /// Bu sayede bir durum ataması yaparken ya da kontrol gerçekleştirirken bu enumlar'ı kullanmak yeterli olacak.
    /// Bu durum üzerinde projede kullanılacak kullanıcı-kitap ilişkisi ile ilgili durumlar barındırılır.
    /// </summary>
    public enum BookStatus
    {
        Read,
        Reading,
        WillRead
    }
}
