namespace Library.Services.Utilities
{
    public static class Messages
    {
        public static class User
        {
            public static string NotFound()
            {
                return "Böyle bir kullanıcı bulunamadı.";
            }
            public static string IsThereEmail()
            {
                return $"Bu e-mail adresi zaten kullanımdadır.";
            }
            public static string NotFoundActive()
            {
                return "Aktif herhangi bir kullanıcı bulunamadı.";
            }
            public static string NotFoundDeleted()
            {
                return "Silinen herhangi bir kullanıcı bulunamadı.";
            }
            public static string IsThereUserName()
            {
                return $"Bu kullanıcı adı zaten kullanımdadır.";
            }
            public static string Add(string userName)
            {
                return $"{userName} kullanıcı adlı kullanıcı başarıyla eklenmiştir.";
            }
            public static string Delete(string userName, bool isUser)
            {
                return isUser
                    ? $"Sayın {userName}. Profiliniz başarıyla dondurulmuştur. Lütfen çıkış yapınız."
                    : $"{userName} kullanıcı adlı kullanıcı başarıyla arşivlenmiştir.";
            }
            public static string Update(string userName, bool isUser)
            {
                return isUser 
                    ? $"Sayın {userName}. Profil bilgileriniz başarıyla güncellenmiştir." 
                    : $"{userName} kullanıcı adlı kullanıcı başarıyla güncellenmiştir.";
            }
            public static string HardDelete(string userName, bool isUser)
            {
                return isUser
                    ? $"Sayın {userName}. Profiliniz başarıyla silinmiştir. Lütfen çıkış yapınız."
                    : $"{userName} kullanıcı adlı kullanıcı başarıyla arşivden kaldırılmıştır.";
            }
            public static string UndoDelete(string userName)
            {
                return $"{userName} kullanıcı adlı kullanıcı başarıyla arşivden geri getirilmiştir.";
            }
            public static string RoleUpdate(string userName)
            {
                return $"{userName} kullanıcı adlı kullanıcının rolü başarıyla güncellenmiştir.";
            }
        }
        public static class Book
        {
            public static string NotFound()
            {
                return "Böyle bir kitap bulunamadı.";
            }
            public static string NotFoundActive()
            {
                return "Aktif herhangi bir kitap bulunamadı.";
            }
            public static string NotFoundDeleted()
            {
                return "Silinen herhangi bir kitap bulunamadı.";
            }
            public static string NotFoundInStock()
            {
                return "Stoğu olan herhangi bir kitap bulunamadı.";
            }
            public static string NotFoundNonStock()
            {
                return "Stokta olmayan herhangi bir kitap bulunamadı.";
            }
            public static string NotDelivered(string bookName)
            {
                return $"{bookName} adlı kitabın teslim işlemi gerçekleşmediği için silme işlemi gerçekleştiremezsiniz.";
            }
            public static string Add(string bookName)
            {
                return $"{bookName} adlı kitap başarıyla eklenmiştir.";
            }
            public static string Delete(string bookName)
            {
                return $"{bookName} adlı kitap başarıyla arşivlenmiştir.";
            }
            public static string Update(string bookName)
            {
                return $"{bookName} adlı kitap başarıyla güncellenmiştir.";
            }
            public static string IsThere(string bookName)
            {
                return $"{bookName} adlı kitap kitap zaten mevcuttur.";
            }
            public static string HardDelete(string bookName)
            {
                return $"{bookName} adlı kitap başarıyla arşivden kaldırılmıştır.";
            }
            public static string UndoDelete(string bookName)
            {
                return $"{bookName} adlı kitap başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class Writer
        {
            public static string NotFound()
            {
                return "Böyle bir yazar bulunamadı.";
            }
            public static string NotFoundActive()
            {
                return "Aktif herhangi bir yazar bulunamadı.";
            }
            public static string NotFoundDeleted()
            {
                return "Silinen herhangi bir yazar bulunamadı.";
            }
            public static string Add(string writerName)
            {
                return $"{writerName} adlı yazar başarıyla eklenmiştir.";
            }
            public static string Delete(string writerName)
            {
                return $"{writerName} adlı yazar başarıyla arşivlenmiştir.";
            }
            public static string Update(string writerName)
            {
                return $"{writerName} adlı yazar başarıyla güncellenmiştir.";
            }
            public static string IsThere(string writerName)
            {
                return $"{writerName} adlı yazar zaten mevcuttur.";
            }
            public static string HardDelete(string writerName)
            {
                return $"{writerName} adlı yazar başarıyla arşivden kaldırılmıştır.";
            }
            public static string UndoDelete(string writerName)
            {
                return $"{writerName} adlı yazar başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class Contact
        {
            public static string NotFound()
            {
                return "Böyle bir mesaj bulunamadı.";
            }
            public static string NotFoundActive()
            {
                return "Aktif herhangi bir mesaj bulunamadı.";
            }
            public static string NotFoundDeleted()
            {
                return "Silinen herhangi bir mesaj bulunamadı.";
            }
            public static string Add(string userName)
            {
                return $"Sayın {userName}. Mesajınız başarıyla gönderilmiştir.";
            }
            public static string Delete(string userName)
            {
                return $"{userName} kullanıcı adlı kullanıcının mesajı başarıyla arşivlenmiştir.";
            }
            public static string HardDelete(string userName)
            {
                return $"{userName} kullanıcı adlı kullanıcının mesajı başarıyla arşivden kaldırılmıştır.";
            }
            public static string UndoDelete(string userName)
            {
                return $"{userName} kullanıcı adlı kullanıcının mesajı başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class Category
        {
            public static string NotFound()
            {
                return "Böyle bir kategori bulunamadı.";
            }
            public static string NotFoundActive()
            {
                return "Aktif herhangi bir kategori bulunamadı.";
            }
            public static string NotFoundDeleted()
            {
                return "Silinen herhangi bir kategori bulunamadı.";
            }
            public static string NotFoundParents()
            {
                return "Herhangi bir alt kategori bulunamadı.";
            }
            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla arşivlenmiştir.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            }
            public static string IsThere(string categoryName)
            {
                return $"{categoryName} adlı kategori zaten mevcuttur.";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla arşivden kaldırılmıştır.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class Publisher
        {
            public static string NotFound()
            {
                return "Böyle bir yayınevi bulunamadı.";
            }
            public static string NotFoundActive()
            {
                return "Aktif herhangi bir yayınevi bulunamadı.";
            }
            public static string NotFoundDeleted()
            {
                return "Silinen herhangi bir yayınevi bulunamadı.";
            }
            public static string Add(string publisherName)
            {
                return $"{publisherName} adlı yayınevi başarıyla eklenmiştir.";
            }
            public static string Delete(string publisherName)
            {
                return $"{publisherName} adlı yayınevi başarıyla arşivlenmiştir.";
            }
            public static string Update(string publisherName)
            {
                return $"{publisherName} adlı yayınevi başarıyla güncellenmiştir.";
            }
            public static string IsThere(string publisherName)
            {
                return $"{publisherName} adlı yayınevi zaten mevcuttur.";
            }
            public static string HardDelete(string publisherName)
            {
                return $"{publisherName} adlı yayınevi başarıyla arşivden kaldırılmıştır.";
            }
            public static string UndoDelete(string publisherName)
            {
                return $"{publisherName} adlı yayınevi başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class Comment
        {
            public static string NotFound()
            {
                return "Böyle bir yorum bulunamadı.";
            }
            public static string NotFoundActive()
            {
                return "Aktif herhangi bir yorum bulunamadı.";
            }
            public static string NotFoundComment(string userName)
            {
                return $"Sayın {userName}. Herhangi bir kitaba ait yorumunuz bulunamadı.";
            }
            public static string NotFoundDeleted()
            {
                return "Silinen herhangi bir yorum bulunamadı.";
            }
            public static string Add(string userName)
            {
                return $"Sayın {userName}. Yorumunuz eklenmiştir. Onay sürecinden sonra yayınlanacaktır.";
            }
            public static string Update(string userName)
            {
                return $"Sayın {userName}. Yorumunuz güncellenmiştir. Onay sürecinden sonra yayınlanacaktır.";
            }
            public static string Delete(string userName)
            {
                return $"{userName} adlı kullanıcının yorumu başarıyla arşivlenmiştir.";
            }
            public static string NotFoundNonApproved()
            {
                return "Onay bekleyen herhangi bir yorum bulunamadı.";
            }
            public static string Approve(string userName)
            {
                return $"{userName} adlı kullanıcının yorumu başarıyla onaylanmıştır.";
            }
            public static string Approved(string userName)
            {
                return $"{userName} adlı kullanıcının yorumu zaten onaylıdır.";
            }
            public static string HardDelete(string userName, bool isUser)
            {
                return isUser 
                    ? $"Sayın {userName}. Yorumunuz başarıyla kaldırılmıştır." 
                    : $"{userName} adlı kullanıcının yorumu başarıyla arşivden kaldırılmıştır.";
            }
            public static string UndoDelete(string userName)
            {
                return $"{userName} adlı kullanıcının yorumu başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class UserBook
        {
            public static string NotFoundRead()
            {
                return "Okunmuş herhangi bir kitap bulunamadı.";
            }
            public static string NotFoundReading()
            {
                return "Şu an okunan herhangi bir kitap bulunamadı.";
            }
            public static string NotFoundReadAndReadingByBook()
            {
                return "Kitaba ait herhangi bir okunma ilişkisi bulunamadı.";
            }
            public static string NotFoundReadAndReadingByUser()
            {
                return "Kullanıcıya ait okunan/okunmuş herhangi bir kitap bulunamadı.";
            }
            public static string NotFoundWillRead()
            {
                return "Okunacak herhangi bir kitap bulunamadı.";
            }
            public static string LimitOfUser(string userName)
            {
                return $"{userName} adlı kullanıcıya tanımlanacak max kitap sayısına ulaşılmıştır.";
            }
            public static string Lend(string userName, string bookName)
            {
                return $"{userName} kullanıcısına {bookName} kitabı başarıyla tanımlanmıştır.";
            }
            public static string Added(string userName, string bookName)
            {
                return $"Sayın {userName}. {bookName} kitabı başarıyla listenize eklenmiştir.";
            }
            public static string Receive(string userName, string bookName)
            {
                return $"{userName} kullanıcısından {bookName} kitabı başarıyla teslim alınmıştır.";
            }
            public static string HardDelete(string userName, string bookName)
            {
                return $"{userName} kullanıcısından {bookName} kitabı başarıyla kaldırılmıştır.";
            }
            public static string IsThereRead(string userName, string bookName)
            {
                return $"Sayın {userName}. {bookName} kitabı okuduklarınız arasında zaten mevcuttur.";
            }
            public static string IsThereReading(string userName, string bookName)
            {
                return $"Sayın {userName}. {bookName} kitabı okuyacaklarınız arasında zaten mevcuttur.";
            }
        }
        public static class FavoriteBook
        {
            public static string NotFound()
            {
                return "Herhangi bir favori kitap bulunamamıştır.";
            }
            public static string NotFoundFavorite()
            {
                return "Herhangi bir favori kitap bulunamamıştır.";
            }
            public static string Add(string userName, string bookName)
            {
                return $"Sayın {userName}. {bookName} kitabı başarıyla favorilerinize eklenmiştir.";
            }
            public static string IsThere(string userName, string bookName)
            {
                return $"Sayın {userName}. {bookName} kitabı zaten favorileriniz arasındadır.";
            }
            public static string HardDelete(string userName, string bookName)
            {
                return $"Sayın {userName}. {bookName} kitabı başarıyla favorilerinizden kaldırılmıştır.";
            }
        }
        public static class BookCategories
        {
            public static string IsThere()
            {
                return $"Bu kitaba ait seçilen kategori zaten tanımlıdır.";
            }
            public static string NotFoundBook()
            {
                return "Kategorisi olmayan kitap bulunamamıştır.";
            }
            public static string Add(string bookName, string categoryName)
            {
                return $"{bookName} adlı kitaba ait {categoryName} kategorisi başarıyla eklenmiştir.";
            }
            public static string HardDeleteByCategory(string categoryName)
            {
                return $"{categoryName} kategorisine ait tüm alt kategoriler başarıyla silinmiştir.";
            }
            public static string HardDelete(string bookName, string categoryName)
            {
                return $"{bookName} adlı kitaba ait {categoryName} kategorisi başarıyla silinmiştir.";
            }
        }
    }
}