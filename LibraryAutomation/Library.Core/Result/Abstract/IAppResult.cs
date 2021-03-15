using Library.Core.Enum;

namespace Library.Core.Result.Abstract
{
    /// <summary>
    /// Her seferinde kontrol etmek istemediğimiz standart tiplerin bu nesne ile dönüşünü yapacağız.
    /// </summary>
    public interface IAppResult
    {
        ResultStatus ResultStatus { get; }
        string Message { get; }
    }

    /// <summary>
    /// AppResult türünde geri döndürmek istediğimiz generic tipi yukarıdaki yapıdan farklı olarak Data alanları ile birlikte geriye dönüyoruz
    /// </summary>
    public interface IAppResult<out T> : IAppResult where T : class
    {
        T Data { get; }
    }
}