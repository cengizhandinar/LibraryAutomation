using Library.Core.Enum;
using Library.Core.Result.Abstract;

namespace Library.Core.Result.Concrete
{
    /// <summary>
    /// IAppResult arabiriminde imzaladığımız propları bu sınıfta tanımlıyoruz.
    /// Burada iki farklı yapı ile Geri dönüş tipleri oluşturulmuştur.
    /// Success dönüşü ile durumun başarılı olduğunu setleme işlemini burada yaparak kod maliyetini azaltıyoruz.
    /// Fail dönüşü ile de aynı şekilde durumun hatalı olduğunu setleme işlemini burada gerçekleştiriyoruz.
    /// Bu geri dönüş tiplerinde sadece ilgili Başarılı, Başarısız durumunu çağırarak parametre olarak Mesaj gönderilir.
    /// </summary>
    public class AppResult : IAppResult
    {
        public AppResult Fail(string message)
        {
            return new AppResult { ResultStatus = ResultStatus.Error, Message = message };
        }
        public AppResult Info(string message)
        {
            return new AppResult { ResultStatus = ResultStatus.Info, Message = message };
        }
        public AppResult Success(string message)
        {
            return new AppResult { ResultStatus = ResultStatus.Success, Message = message };
        }
        public AppResult Warning(string message)
        {
            return new AppResult { ResultStatus = ResultStatus.Warning, Message = message };
        }

        public string Message { get; private set; }
        public ResultStatus ResultStatus { get; private set; }
    }

    /// <summary>
    /// IAppResult arabiriminde imzaladığımız propları bu sınıfta tanımlıyoruz.
    /// Burada iki farklı yapı ile Geri dönüş tipleri oluşturulmuştur.
    /// Success dönüşü ile durumun başarılı olduğunu setleme işlemini burada yaparak kod maliyetini azaltıyoruz.
    /// Fail dönüşü ile de aynı şekilde durumun hatalı olduğunu setleme işlemini burada gerçekleştiriyoruz.
    /// Bu geri dönüş tiplerinde sadece ilgili Başarılı, Başarısız durumunu çağırarak parametre olarak Mesaj ve Data gönderilir.
    /// </summary>
    public class AppResult<T> : IAppResult<T> where T : class
    {
        public AppResult<T> Success(T data)
        {
            return new AppResult<T> { ResultStatus = ResultStatus.Success, Data = data };
        }
        public AppResult<T> Fail(string message)
        {
            return new AppResult<T> { ResultStatus = ResultStatus.Error, Message = message };
        }
        public AppResult<T> Warning(string message)
        {
            return new AppResult<T> { ResultStatus = ResultStatus.Warning, Message = message };
        }

        public T Data { get; private set; }
        public string Message { get; private set; }
        public ResultStatus ResultStatus { get; private set; }
    }
}