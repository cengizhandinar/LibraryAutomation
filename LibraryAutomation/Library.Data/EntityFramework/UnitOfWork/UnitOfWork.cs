using System;
using System.Collections.Generic;
using System.Linq;
using Library.Core.Data.Abstract;
using Library.Core.Data.Concrete;
using Library.Core.Entities.Abstract;
using Library.Core.Enum;
using Library.Data.Abstract;
using Library.Data.EntityFramework.Context;
using Library.Data.Utilities;
using Library.Entities.Entities.Concrete;

namespace Library.Data.EntityFramework.UnitOfWork
{
    /// <summary>
    /// Repositoryler ile CRUD işlemlerini tek bir noktada topladık ve veritabanına kaydedilmek üzere kuyruğa aldık.
    /// UnitOfWork ile de bu kuyruğu tek noktadan kaydedeceğiz.
    /// Aynı zamanda bundan sonraki tüm süreçte yazılan metotları ve entitylerimizi bu metot sayesinde kullanabileceğiz.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Variables

        /// <summary>
        /// Sınıf içerisinde kullanacağımız değişkenler
        /// Veritabanı işlemleri için DbContext sınıfı
        /// _disposed isimli bir bool değişken. Bu değişken ile context in dispose olup olmadığını kontrol edeceğiz.
        /// </summary>
        private readonly AppDbContext _context;
        private bool _disposed;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Yapıcı method dependency injection ile DbContext üretilmesini sağlayacaktı. 
        /// Ancak bu durumu şuan ki WinForm projemizde yapılandıramadığımızdan dolayı yeni bir tane üreterek oluşturuyoruz.
        /// </summary>
        public UnitOfWork()
        {
            _context = new AppDbContext();

            // Veritabanı oluşurken ilgili tablolara data ekleme işlemini burada gerçekleştiriyoruz.

            if (_context.Books.Any() || _context.BookCategories.Any() || _context.Categories.Any() ||
                _context.Comments.Any() ||
                _context.Contacts.Any() || _context.FavoriteBooks.Any() || _context.Publishers.Any() ||
                _context.Users.Any() ||
                _context.UserBooks.Any() || _context.Writers.Any()) return;
            _context.Books.AddRange(new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Name = "Körlük",
                    Description = "Adı bilinmeyen bir ülkenin adı bilinmeyen bir kentinde, " +
                                  "arabasının direksiyonunda trafik ışığının yeşile dönmesini bekleyen bir adam ansızın kör olur. " +
                                  "Ancak karanlıklara değil, bembeyaz bir boşluğa gömülür. " +
                                  "Arkasından, körlük salgını bütün kente, hatta bütün ülkeye yayılır. " +
                                  "Ne yönetim kalır ülkede, ne de düzen; bütün körler karantinaya alınır. " +
                                  "Hayal bile edilemeyecek bir kaos, pislik, açlık ve zorbalık hüküm sürmektedir artık. " +
                                  "Yaşam durmuştur, insanların tek çabası, ne pahasına olursa olsun hayatta kalmaktır. " +
                                  "Roman, kentteki akıl hastanesinde karantinaya alınan, oradan kurtulunca da birbirinden ayrılmayan, biri çocuk yedi kişiye odaklanır. " +
                                  "Aralarında, bütün kentte gözleri gören tek kişi olan ve gruptakilere rehberlik eden bir kadın da vardır. " +
                                  "Bu yedi kişi, cehenneme dönen bu kentte, hayatta kalabilmek için inanılmaz bir mücadele verir. " +
                                  "Saramago’nun müthiş bir gözlem gücüyle betimlediği bu kaotik dünya, insanın karanlık yüzünün simgesi." +
                                  "Körlük,ürkütücü bir roman, beklenmedik bir felaketi yaşayan bir toplumun nasıl çöktüğünün, nasıl bencilleştiğinin ve değer yargılarını yitirdiğinin hikâyesi." +
                                  "Konusunun ürkütücülüğüne rağmen olağanüstü bir şiirsellikle anlatılmış bu unutulmaz roman,usta yazarın belki de en etkileyici yapıtı.",
                    NumberOfPages = 336,
                    ReleaseDate = new DateTime(2020, 10, 11),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 1,
                    Place = "A1",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 1,
                    PublisherId = 1,
                    NumberOfComments = 2,
                    NumberOfFavorites = 2,
                    NumberOfReads = 2,
                    RatingAverage = 4,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 2,
                    Name = "Şeker Portakalı",
                    Description = "Brezilya edebiyatının klasiklerinden Şeker Portakalı, José Mauro de Vasconcelos’un başyapıtı kabul edilir. " +
                                  "Yetişkinler dünyasının sınırlamalarına hayal gücüyle meydan okuyan Zezé’nin yoksulluk, acı ve ümit dolu hikâyesi yazarın çocukluğundan derin izler taşır." +
                                  "Beş yaşındaki Zezé hemen her şeyi tek başına öğrenir: " +
                                  "sadece bilye oynamayı ve arabalara asılmayı değil, okumayı ve sokak şarkıcılarının ezgilerini de." +
                                  "En yakın sırdaşıysa,anlattıklarına kulak veren ve Minguinho adını verdiği bir şeker portakalı fidanıdır...",
                    NumberOfPages = 182,
                    ReleaseDate = new DateTime(2019, 09, 06),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 2,
                    Place = "A2",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 2,
                    PublisherId = 2,
                    NumberOfComments = 2,
                    NumberOfFavorites = 2,
                    NumberOfReads = 0,
                    RatingAverage = 3,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 3,
                    Name = "Babamın Battaniyesi",
                    Description = "İki kardeş babalarının battaniyesiyle öyle eğleniyorlar ki, zaman neşeyle akıp gidiyor, şiş göbekler iniyor. " +
                                  "Bu battaniye başka battaniyelere benzemiyor, türlü türlü maceraya götürüyor. " +
                                  "Babanın müthiş hayal gücüyle canlanan battaniye çocukların rengârenk hayalleriyle bir araya geliyor. " +
                                  "Babalar çocuklarıyla böyle vakit geçirirse, maceralar bitmez tükenmez. " +
                                  "Çocuklarla hep anneler ilgilenecek değil ya? Babayla yaşanan maceralar bir harika.",
                    NumberOfPages = 50,
                    ReleaseDate = new DateTime(2019, 01, 01),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 3,
                    Place = "A3",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 3,
                    PublisherId = 3,
                    NumberOfComments = 2,
                    NumberOfFavorites = 2,
                    NumberOfReads = 2,
                    RatingAverage = 5,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 4,
                    Name = "Cesur Yeni Dünya",
                    Description = "Cesur yeni Dünya bizi 'Ford'dan sonra 632 yılına' götürür. " +
                                  "Bu dünyanın cesur insanları kapısında Cemaat, Özdeşlik, İstikrar yazan Londra Merkez kuluçka ve Şartlandırma Merkezi'nde üretilirler. " +
                                  "Kadınların döllenmesi yasak ve ayıp olduğu için, 'annelik' ve 'babalık' pornografik birer kavram olarak görülür. " +
                                  "Toplumsal istikrarın temel güvencesi olan şartlandırma hipnopedya uykuda eğitim ile sağlanır. " +
                                  "Hipnopedya seyesinde herkes mutludur; herkes çalışır ve herkes eğlenir. Herkes herkes içindir.",
                    NumberOfPages = 272,
                    ReleaseDate = new DateTime(2020, 10, 07),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 4,
                    Place = "A4",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 4,
                    PublisherId = 4,
                    NumberOfComments = 2,
                    NumberOfFavorites = 2,
                    NumberOfReads = 0,
                    RatingAverage = 3,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 5,
                    Name = "Bilinmeyen Bir Kadının Mektubu",
                    Description = "Bilinmeyen Bir Kadının Mektubu'nun kadın kahramanını sadece uzun bir mektubun yazarı olarak tanıyoruz. " +
                                  "Kadının hayatı boyunca sevmiş olduğu erkek için kaleme aldığı bu mektubun 'gönderen'inin adı yoktur. " +
                                  "Mektubun başında tek bir hitap vardır: 'Sana, beni asla tanımamış olan sana'. " +
                                  "Kadın büyük tutkusunu hep bir 'bilinmeyen' olarak, yani tek başına yaşamaya razıdır, bu aşk öyküsünde 'taraflar' değil, sadece tek bir 'taraf' vardır. " +
                                  "Böylesine, gerçek anlamda aşk denilebilir mi? Zweig okurunu, bir kez daha, insan psikolojisinde eşine pek rastlanmayan bir yolculuğa davet ediyor. " +
                                  "Bu yeni yolculuğun sonunda 'mutlak aşk' kavramının şimdiye kadar bilinmeyen kıyılarına varmayı amaçlamış olması da bir ihtimal!",
                    NumberOfPages = 68,
                    ReleaseDate = new DateTime(2019, 02, 26),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 5,
                    Place = "A5",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 5,
                    PublisherId = 5,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 6,
                    Name = "Olağanüstü Bir Gece",
                    Description = "Olağanüstü Bir Gece, seçkin bir burjuva olarak rahat ve tasasız varoluşunu sürdürürken giderek duyarsızlaşan " +
                                  "bir adamın hayatındaki dönüştürücü deneyimin hikâyesidir. " +
                                  "Sıradan bir Pazar gününü at yarışlarında geçirirken, belki de ilk kez burjuva ahlakından saparak “suç” işler. " +
                                  "Böylece yeniden “hissetmeye” başladığını, kötücül ve ateşli hazları olan gerçek bir insan olduğunu fark eder. " +
                                  "İçindeki haz dolu esrime, aynı günün akşamında onu gece âleminin son atıklarının arasına, " +
                                  "“hayatın en dibindeki lağımlara” sürükleyecek, varış noktası ise ruhani bir uyanış olacaktır.",
                    NumberOfPages = 80,
                    ReleaseDate = new DateTime(2019, 04, 15),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 6,
                    Place = "B1",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 5,
                    PublisherId = 5,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 7,
                    Name = "Ay Işığı Sokağı",
                    Description = "Fransa’nın bir liman kentinin denizci mahallesinde gezinirken duyduğu arya söyleyen sesi izleyerek tanımadığı insanların marazi hayatlarına dalan bir gezgin; " +
                                  "patronuna kölece bağlılığı yüzünden korkunç bir eyleme sürüklenen karanlık, itici ve yabani bir hizmetçi; " +
                                  "1810 yılında İspanya’daki savaşta yaralanan, düşman bir ülkede amansız bir hayatta kalma mücadelesine girişen bir Fransız albay; " +
                                  "1918 yılının bir yaz gecesi Leman gölünde bulunup kurtarılan, ancak sonra yüreğini kavuran yurt özlemine yenik düşen bir Rus savaş esiri; " +
                                  "yaşıtları üniversiteye giderken hâlâ liseye devam eden avare bir gencin öğretmeninin otoritesine isyan ettikten sonra ödediği ağır bedel. " +
                                  "Zweig bu öykülerde insanı insanlıktan çıkarıp en uç noktalara sürükleyen deneyimlerin izini sürerken, " +
                                  "okuru da ister istemez karakterlerinin ruh çalkantılarının içine çekiyor…",
                    NumberOfPages = 80,
                    ReleaseDate = new DateTime(2019, 06, 14),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 2,
                    Place = "B2",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 5,
                    PublisherId = 5,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 8,
                    Name = "Satranç",
                    Description = "Satranç, Zweig’ın psikolojik birikimini bütünüyle devreye soktuğu bir öyküdür " +
                                  "ve bu öykünün baş kişileri, tamamen yazarın biyografilerinde ele aldığı kişileri işleyiş biçimiyle sergilenmiştir. " +
                                  "Zweig ölümünden hemen önce tamamladığı birkaç düzyazı metinden biri olan Satranç’ı kaleme aldığı sırada, " +
                                  "karısı Lotte Zweig ile birlikte göç ettiği Brezilya’da yaşamaktaydı. " +
                                  "Satranç’ta da, olay yeri olarak New York’dan Buenos Aires’e gitmekte olan bir yolcu gemisini seçmiştir. " +
                                  "Bu gemide tamamen rastlantı sonucu karşılaşan üç kişi: yeni dünya satranç şampiyonu Mirko Czentovic, " +
                                  "sıradan bir satranç oyuncusu olan anlatıcı ve bir zamanlar çok usta bir satranç oyuncusu olan, " +
                                  "ama hayli zamandır satrançtan uzak kalmış bulunan Dr. B., öykünün aktörleridir.",
                    NumberOfPages = 77,
                    ReleaseDate = new DateTime(2019, 02, 13),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 5,
                    Place = "B3",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 5,
                    PublisherId = 5,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 9,
                    Name = "Serenad",
                    Description = "Serenad, 60 yıldır süren bir aşkı ele alırken, ister herkesin bildiği Yahudi Soykırımı olsun isterse çok az kimsenin bildiği Mavi Alay, " +
                                  "bütün siyasi sorunlarda asıl harcananın, gürültüye gidenin hep insan olduğu gerçeğini de göz önüne seriyor. " +
                                  "Okurunu sımsıkı kavrayan Serenad'da Zülfü Livaneli’nin romancılığının en temel niteliklerinden biri yine başrolde: " +
                                  "İç içe geçmiş, kaynaşmış kişisel ve toplumsal tarihlerin kusursuz Dengesi.",
                    NumberOfPages = 484,
                    ReleaseDate = new DateTime(2016, 10, 25),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 1,
                    Place = "B4",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 6,
                    PublisherId = 6,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 10,
                    Name = "Kardeşimin Hikayesi",
                    Description = "Sakin bir balıkçı köyünde genç bir kadının cinayete kurban gitmesiyle başlar her şey. " +
                                  "Dünyadan elini eteğini çekmiş emekli inşaat mühendisiyle genç, güzel ve meraklı gazeteci kızın tanışmasına da bu cinayet vesile olur. " +
                                  "Kurguyla gerçeğin karıştığı, duyguların en karanlık, en kuytu bölgelerine girildiği hikâye, daha doğrusu hikâye içinde hikâye de böylece başlar. " +
                                  "Modern bir Binbir Gece Masalı’nın kapıları aralanır. Ancak bu kez Şehrazad erkektir. " +
                                  "Kardeşimin Hikâyesi aşkın mutlulukta ulaşılacak son nokta olduğuna inananları bir kez daha düşünmeye davet eden, " +
                                  "aşka, aşkın karmaşıklığına ve tehlikelerine dair nefes kesen bir roman. " +
                                  "Her sayfada yeni bir gerçekliği keşfedecek, kuşku ile kesinliğin sınırlarında dolaşacaksınız.",
                    NumberOfPages = 330,
                    ReleaseDate = new DateTime(2016, 01, 18),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 2,
                    Place = "B5",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 6,
                    PublisherId = 6,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 11,
                    Name = "Harry Potter ve Felsefe Taşı",
                    Description = "“Harry, elleri titreyerek zarfı çevirince mor balmumundan bir mühür gördü; " +
                                  "bir arma – koca bir ‘H’ harfinin çevresinde bir aslan, bir kartal, bir porsuk, bir de yılan.” " +
                                  "HARRY POTTER sıradan bir çocuk olduğunu sanırken, bir baykuşun getirdiği mektupla yaşamı değişir: " +
                                  "Başvurmadığı halde Hogwarts Cadılık ve Büyücülük Okulu’na kabul edilmiştir. " +
                                  "Burada birbirinden ilginç dersler alır, iki arkadaşıyla birlikte maceradan maceraya koşar. " +
                                  "Yaşayarak öğrendikleri sayesinde küçük yaşta becerikli bir büyücü olup çıkar.",
                    NumberOfPages = 274,
                    ReleaseDate = new DateTime(2019, 09, 06),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 0,
                    Place = "C1",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 7,
                    PublisherId = 3,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 12,
                    Name = "Harry Potter ve Sırlar Odası",
                    Description = "İki kardeş babalarının battaniyesiyle öyle eğleniyorlar ki, zaman neşeyle akıp gidiyor, şiş göbekler iniyor. " +
                                  "Bu battaniye başka battaniyelere benzemiyor, türlü türlü maceraya götürüyor. " +
                                  "Babanın müthiş hayal gücüyle canlanan battaniye çocukların rengârenk hayalleriyle bir araya geliyor. " +
                                  "Babalar çocuklarıyla böyle vakit geçirirse, maceralar bitmez tükenmez. " +
                                  "Çocuklarla hep anneler ilgilenecek değil ya? Babayla yaşanan maceralar bir harika.",
                    NumberOfPages = 314,
                    ReleaseDate = new DateTime(2019, 08, 29),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 1,
                    Place = "C2",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 7,
                    PublisherId = 3,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 13,
                    Name = "Harry Potter ve Azkaban Tutsağı",
                    Description = "“Mahsur kalmış cadıların ve büyücülerin acil durum taşıtı Hızır Otobüs’e hoş geldiniz. " +
                                  "Asanızı tuttuğunuz elinizi uzatın, otobüse atlayın, sizi istediğiniz yere götürelim.” " +
                                  "Sirius Black adında azılı bir katil, tüyler ürpertici Azkaban kalesinde tam on iki yıl boyunca tutsak kalmıştır. " +
                                  "Tek lanetle on üç kişiyi birden öldüren Black’in, Karanlık Lord Voldemort’un hizmetkârı olduğuna kesin gözüyle bakılmaktadır. " +
                                  "Bir yolunu bulup Azkaban’dan kaçan Black’in peşinde olduğu bir tek kişi vardır: " +
                                  "Harry Potter. Harry, büyücülük okulunun sihirli duvarları arasındayken, arkadaşları ve öğretmenleriyle birlikteyken bile güvende değildir. " +
                                  "Çünkü aralarında bir hain olabilir.",
                    NumberOfPages = 396,
                    ReleaseDate = new DateTime(2019, 10, 30),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 2,
                    Place = "C3",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 7,
                    PublisherId = 3,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 14,
                    Name = "Harry Potter ve Ateş Kadehi",
                    Description = "Hogwarts Cadılık ve Büyücülük Okulu'nda dördüncü sınıfa geçen Harry, " +
                                  "yaz tatilinde Dursley'lerden izin koparıp arkadaşlarıyla birlikte Quidditch Dünya Kupası finalini izlemeye gidiyor. " +
                                  "Bu yıl Hogwarts'taki en büyük yenilik ise, Üçbüyücü Turnuvası. " +
                                  "Üç rakip büyücülük okulunun katılımıyla gerçekleşen bu etkinlik yüz yıldan beri ilk kez düzenleniyor. " +
                                  "Harry, istemediği halde, yaşı bile tutmadığı halde, kendini bu Turnuva'nın içinde buluyor. " +
                                  "Oysa onun tek istediği, büyücülük standartları içinde olabildiğince 'normal' bir yaşam sürmek, " +
                                  "yeni büyüler öğrenerek kendini geliştirmek, Cho'yla ilgili hayaller kurmak, Ron ve Hermione'yle hoşça vakit geçirmek. " +
                                  "Ancak, alnındaki yara izinin ikide bir acıması, korkunç olayların yaklaşmakta olduğunun habercisi...",
                    NumberOfPages = 664,
                    ReleaseDate = new DateTime(2019, 10, 31),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 3,
                    Place = "C4",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 7,
                    PublisherId = 3,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 15,
                    Name = "Saatleri Ayarlama Enstitüsü",
                    Description = "Ahmet Hamdi Tanpınar'ın şiiri sembolist bir ifade üzerine kurulmuştur. " +
                                  "Aynı anlatım tarzı romanlarına da zaman zaman sirayet eder. " +
                                  "Ancak muhteva açısından metafizik eğilimleri ile estetik endişelerini şiire ayırdığı halde, sosyal temalar için nesri seçmiştir. " +
                                  "Romanları, zengin hayat hikayesinden taşarak Türkiye meselelerine kendine has yorumlar getirir.",
                    NumberOfPages = 382,
                    ReleaseDate = new DateTime(2017, 09, 15),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 6,
                    Place = "C5",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 8,
                    PublisherId = 7,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 16,
                    Name = "Masumiyet Müzesi",
                    Description = "“Hayatımın en mutlu ânıymış, bilmiyordum.” Nobel ödüllü büyük yazarımız Orhan Pamuk'un harikulade aşk romanı bu sözlerle başlıyor... " +
                                  "1975'te bir bahar günü başlayıp günümüze kadar gelen, İstanbullu zengin çocuğu Kemal ile uzak ve yoksul akrabası Füsun'un hikâyesi: " +
                                  "Hızı, hareketi, olaylarının ve kahramanlarının zenginliği, mizah duygusu ve insan ruhunun derinliklerindeki fırtınaları hissettirme gücüyle, " +
                                  "Masumiyet Müzesi, elinizden bırakamayacağınız ve yeniden okuyacağınız kitaplardan biri olacak.",
                    NumberOfPages = 465,
                    ReleaseDate = new DateTime(2019, 10, 25),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 3,
                    Place = "D1",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 9,
                    PublisherId = 3,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 17,
                    Name = "Kral Şakir 8 / Macera Adası",
                    Description = "Selam arkadaşlar ben Şakir. Herkesin bildiği nam-ı diğer Kral Şakir! " +
                                  "Bu kitapta daha önce hiçbir yerde yayımlanmamış iki yeni hikâyeyle karşınızdayız. " +
                                  "Dünyanın en eski sporunun peşine düşüp ta Kars’a kadar gidiyoruz. " +
                                  "Tabii ki Necati ağabeyin sürekli acıkması yüzünden yolculuğumuz oldukça uzun ve macera dolu geçiyor. " +
                                  "Ama Bilge dedeyle tanıştığımızda en eski sporu öğreniyoruz. Maceralarımız bununla bitmiyor. " +
                                  "Güneş sisteminin bir ucundan girip diğer ucundan çıkıyoruz. Derin denizlerden ormanlara varıp kahraman itfaiyeciler oluyoruz. " +
                                  "Ve hep beraber Lömpen Adası’na ulaşmaya çalışıyoruz. Bu macerada Necati Ağabey’in hakkını yiyemem, bize çok güzel rehberlik yapıyor. " +
                                  "Sürekli aç olduğu için bazı şeyleri karıştırıyor ama olsun. Necati Ağabey dur o yenmez! Macera adasına bir yolculuğa hazır mısınız?",
                    NumberOfPages = 208,
                    ReleaseDate = new DateTime(2020, 04, 02),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 0,
                    Place = "D2",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 10,
                    PublisherId = 8,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 18,
                    Name = "Kral Şakir 7 / Mor Bir Fil Gördüm Sanki",
                    Description = "Merhaba arkadaşlar ben Necati yaniii Fil Necati! Bu kitapta neler mi var? Yemek, dürüm, börek, sarma… " +
                                  "Yok, gene karıştırdım, bunlar değildi. Tanju sayesinde dinozor çağına zamanda yolculuk yaptık. Büyük büyük büyük babamla karşılaştım. " +
                                  "Çok sevdim kendisini, çok duygulandım. Mirket’le yeni bir gezegen keşfettik. " +
                                  "Derken Kadriye’nin canavara dönüşen saçıyla aklımız başımızdan gitti. " +
                                  "Tam bitti derken denizden çıkan bir lahmacunun peşinde balıkların kasabasına esir düştük. " +
                                  "Eğlence, macera, heyecan ve tabii ki dürüm, lahmacun, börek, sarma ne ararsanız. Yine muhtişim maceralar sizi bekliyor. " +
                                  "Ay yine acıktım. Kadriye bugün ne pişirdin?",
                    NumberOfPages = 208,
                    ReleaseDate = new DateTime(2019, 12, 11),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 2,
                    Place = "D3",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 10,
                    PublisherId = 8,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 19,
                    Name = "Tüfek, Mikrop ve Çelik",
                    Description = "Tüfek, Mikrop ve Çelik, insanlık tarihinin en can alıcı ve önemli sorularını soran ve bilimsel kanıtlarla yanıtlayan muhteşem bir eser. " +
                                  "Biyoloji, coğrafya, dilbilim ve tarih gibi birçok alandan yararlanarak yazılmış, " +
                                  "“Batılı” koşullandırmalardan arınmış, geleceği gösteren bir tarih kitabı. " +
                                  "Dinlerin nasıl doğduğu, devletlerin nasıl kurulduğu, mikropların ve onlara bağlı hastalıkların nasıl oluştuğu, " +
                                  "tarım ve hayvancılığın hayatımızdaki önemi, yazının neden icat edildiği, insanoğlunun teknolojiyi nasıl ve neden geliştirdiği, " +
                                  "insanlık tarihinin temellerinin neler olduğu ayrıntılarıyla bu kitapta inceleniyor. ",
                    NumberOfPages = 664,
                    ReleaseDate = new DateTime(2018, 09, 28),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 3,
                    Place = "D4",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 11,
                    PublisherId = 9,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 20,
                    Name = "İçimizdeki Şeytan",
                    Description = "'İsteyip istemediğimi doğru dürüst bilmediğim, " +
                                  "fakat neticesi aleyhime çıkarsa istemediğimi iddia ettiğim bu nevi söz ve fiillerimin daimi bir mesulünü bulmuştum: " +
                                  "Buna içimdeki şeytan diyordum, müdafaasını üzerime almaktan korktuğum bütün hareketlerimi ona yüklüyor ve kendi suratıma tüküreceğim yerde, " +
                                  "haksızlığa, tesadüfün cilvesine uğramış bir mazlum gibi nefsimi şefkat ve ihtimama layık görüyordum. " +
                                  "Halbuki ne şeytanı azizim, ne şeytanı? Bu bizim gururumuzun, salaklığımızın uydurması... " +
                                  "İçimizdeki şeytan pek de kurnazca olmayan bir kaçamak yolu... İçimizdeki şeytan yok... İçimizdeki aciz var... Tembellik var... " +
                                  "İradesizlik, bilgisizlik ve bunların hepsinden daha korkunç bir şey: hakikatleri görmekten kaçmak itiyadı var...'",
                    NumberOfPages = 267,
                    ReleaseDate = new DateTime(2019, 07, 09),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 0,
                    Place = "D5",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 12,
                    PublisherId = 3,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 21,
                    Name = "Kürk Mantolu Madonna",
                    Description = "Her gün, daima öğleden sonra oraya gidiyor, koridorlardaki resimlere bakıyormuş gibi ağır ağır, " +
                                  "fakat büyük bir sabırsızlıkla asıl hedefine varmak isteyen adımlarımı zorla zapt ederek geziniyor, " +
                                  "rastgele gözüme çarpmış gibi önünde durduğum 'Kürk Mantolu Madonna'yı seyre dalıyor, ta kapılar kapanıncaya kadar orada bekliyordum.",
                    NumberOfPages = 160,
                    ReleaseDate = new DateTime(2019, 10, 14),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 1,
                    Place = "E1",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 12,
                    PublisherId = 3,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 22,
                    Name = "İnsan Neyle Yaşar",
                    Description = "Lev Nikolayeviç Tolstoy (1828-1910): Anna Karenina, Savaş ve Barış, Kreutzer Sonat ve Diriliş’in büyük yazarı, " +
                                  "yaşamının son otuz yılında kendini insan, aile, din, devlet, toplum, özgürlük, boyun eğme, başkaldırma, sanat ve estetik konularında kuramsal çalışmalara verdi. " +
                                  "Bu dönemde yazdığı öykülerde yıllarca üzerinde düşündüğü insanlık sorunlarını edebi bir kurgu içinde ele aldı. " +
                                  "Tolstoy, insan sevgisi ve inanç konularını ustalığının bütün inceliğiyle işlerken, " +
                                  "İnsan Neyle Yaşar? ile gerçek hayatı yansıtan tabloların içinde yeni bir ahlak anlayışını ortaya koydu.",
                    NumberOfPages = 112,
                    ReleaseDate = new DateTime(2019, 10, 04),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 6,
                    Place = "E2",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 13,
                    PublisherId = 5,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 23,
                    Name = "Simyacı",
                    Description = "Simyacı, Brezilyalı eski şarkı sözü yazarı Paulo Coelho'nun, yayınlandığı 1988 yılından bu yana dünyayı birbirine katan, " +
                                  "eleştirmenler tarafından bir `fenomen' olarak değerlendirilen üçüncü romanı. " +
                                  "Simyacı, altı yılda kırk iki ülkede yedi milyondan fazla sattı. " +
                                  "Bu, Gabriel Garcia Marquez'den bu yana görülmemiş bir olay. " +
                                  "Yüreğinde, çocukluğunu yitirmemiş olan okurlar için bir `klasik' kimliği kazanan Simyacı'yı Saint-Exupery'nin Küçük Prens'i ve " +
                                  "Richard Bach'ın Martı Jonathan Livingston'u ile karşılaştıranlar var (Publishers Weekly). " +
                                  "Simyacı, İspanya'dan kalkıp Mısır Piramitlerinin eteklerinde hazinesini aramaya giden Endülüslü çoban Santiago'nun masalsı yaşamının felsefi öyküsü. " +
                                  "Sanki bir `nasihatnâme': `Yazgına nasıl egemen olacaksın, mutluluğunu nasıl kuracaksın?' sorularına yanıt arayan bir hayat ve ahlak kılavuzu.",
                    NumberOfPages = 184,
                    ReleaseDate = new DateTime(2019, 06, 17),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 0,
                    Place = "E3",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 14,
                    PublisherId = 2,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 24,
                    Name = "Veronika Ölmek İstiyor",
                    Description = "Veronika, her istediğine sahip görünen, renkli bir yaşam süren, yakışıklı erkeklerle gezip tozan genç bir kadın olmasına karşın, mutlu değildir. " +
                                  "Yaşamında bir şeylerin eksikliğini hissetmektedir. Başarısız bir intihar girişiminin ardından, kendine geldiği zaman bir akıl hastanesindedir. " +
                                  "Üstelik çok kısa bir ömrü kaldığını öğrenir. " +
                                  "Zaten ölmek isteyen Veronika bu süreçte, başka dünyaların insanlarını tanırken kendisini de keşfetmeye başlar…",
                    NumberOfPages = 198,
                    ReleaseDate = new DateTime(2019, 08, 06),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 2,
                    Place = "E4",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 14,
                    PublisherId = 2,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 25,
                    Name = "Fareler ve İnsanlar",
                    Description = "Fareler ve İnsanlar, birbirine zıt karakterdeki iki mevsimlik tarım işçisinin, " +
                                  "zeki George Milton ve onun güçlü kuvvetli ama akli dengesi bozuk yoldaşı Lennie Small’un öyküsünü anlatır. " +
                                  "Küçük bir toprak satın alıp insanca bir hayat yaşamanın hayalini kuran bu ikilinin öyküsünde dostluk ve dayanışma duygusu önemli bir yer tutar. " +
                                  "Steinbeck insanın insanla ilişkisini anlatmakla kalmaz insanın doğayla ve toplumla kurduğu ilişkileri de konu eder bu destansı romanında." +
                                  "Kitabın ismine ilham veren Robert Burns şiirindeki gibi; “En iyi planları farelerin ve insanların / Sıkça ters gider…",
                    NumberOfPages = 111,
                    ReleaseDate = new DateTime(2020, 05, 21),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 5,
                    Place = "E5",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 15,
                    PublisherId = 10,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 26,
                    Name = "Gazap Üzümleri",
                    Description = "John Steinbeck’in tartışmasız en büyük eseri olan ve ona Pulitzer ödülünü kazandıran Gazap Üzümleri, " +
                                  "1939’da ilk kez yayınlandığında şok etkisi yaratmış ve büyük tartışmalara yol açmıştı. " +
                                  "Tüm dünyayı etkileyen “Büyük Buhran” döneminde, " +
                                  "tarımın kapitalistleşmesi ve krizler yüzünden yoksullaşan ve mülksüzleşen yığınların ayakta kalma mücadelesinin anlatıldığı bu destansı romanda Steinbeck, " +
                                  "açlık, sefalet ve zorbalık yüzünden evlerini terk edip yollara düşmek zorunda kalan binlerce işçi ailesinden birine odaklanıyor. " +
                                  "Boşa çıkan umutların, hüzne dönüşen sevinçlerin arasında insanlığın direncini ve onurunu çarpıcı bir dille anlatan, " +
                                  "kapitalizmi iliklerine kadar eleştiren Gazap Üzümleri, 20. yüzyılın en önemli eserlerinden biridir.",
                    NumberOfPages = 556,
                    ReleaseDate = new DateTime(2020, 03, 25),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 3,
                    Place = "F1",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 15,
                    PublisherId = 10,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 27,
                    Name = "Bir Ömür Nasıl Yaşanır?",
                    Description = "“Bir Ömür Nasıl Yaşanır?”, ülkemizin medarıiftiharı olmuş bir tarihçinin gözünden, insanın hayattaki anlam arayışına, " +
                                  "bu arayışın tadını nasıl çıkaracağına ve süreç boyunca karşılaşacağı zorluklarla nasıl baş etmesi gerektiğine dair çok özel bir kılavuz…",
                    NumberOfPages = 288,
                    ReleaseDate = new DateTime(2020, 06, 01),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 1,
                    Place = "F2",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 16,
                    PublisherId = 11,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 28,
                    Name = "Toprak Ana",
                    Description = "Cengiz Aytmatov, Toprak Ana romanında erkekleri askere alınan bozkırın ortasındaki bir Kırgız köyünde geride kalanların çektiği sıkıntıları anlatıyor. " +
                                  "Eldeki yetersiz yiyeceğin muhtaç olandan başlanarak dağıtılması, " +
                                  "dört gözle beklenen hasat zamanları, umutların hasat zamanına ertelenmesi, savaş yüzünden ürünün hemen hepsinin merkezden istenmesi, " +
                                  "boşa çıkan umutlar, yine açlık, sefalet, bir yandan cepheden gelen ölüm haberleri, umutsuz bekleyişler, " +
                                  "savaşın uzun sürmesi üzerine aşağı çekilen cepheye çağrılma yaşı, anaların evlatlarını bir bir askere göndermesi, ayrılıklar, gözyaşları... " +
                                  "Yani tek kelimeyle ve bütün zulmetiyle; savaş. Cengiz Aytmatov, o her zamanki berrak ve akıcı üslûbuyla bizleri, " +
                                  "adeta insanları öğütür gibi harcayan savaş düzeneğinin yarattığı trajedilerle sarsıyor.",
                    NumberOfPages = 136,
                    ReleaseDate = new DateTime(2020, 10, 15),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 5,
                    Place = "F3",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 17,
                    PublisherId = 12,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 29,
                    Name = "Romeo ve Juliet",
                    Description = "Oyunları ve şiirlerinde insanlık durumlarını dile getiriş gücüyle yaklaşık 400 yıldır bütün dünya okur ve seyircilerini etkilemeyi sürdüren efsanevi yazar, " +
                                  "Romeo ve Juliet’de birbirinden farklı pek çok toplumda benzerleriyle karşılaşılan trajik bir ilişkiyi, " +
                                  "düşman ailelerin çocukları arasında doğan aşkı ele alır. " +
                                  "Romeo ile Juliet’in umutsuz aşkını romantik örgüsünün yarı karanlık örtüsüyle sarmalayan eser, " +
                                  "buna rağmen insan ilişkilerini gerçekçi bir anlayışla gözler önüne serer.",
                    NumberOfPages = 133,
                    ReleaseDate = new DateTime(2019, 06, 10),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 2,
                    Place = "F4",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 18,
                    PublisherId = 5,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 30,
                    Name = "Hamlet",
                    Description = "Oyunları ve şiirlerinde insanlık durumlarını dile getiriş gücüyle yaklaşık 400 yıldır bütün dünya okur " +
                                  "ve seyircilerini etkilemeyi sürdüren efsanevi yazar William Shakespeare bu kitabında da etkilemeye devam ediyor.",
                    NumberOfPages = 188,
                    ReleaseDate = new DateTime(2019, 09, 28),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 3,
                    Place = "F5",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 18,
                    PublisherId = 5,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 31,
                    Name = "Dönüşüm",
                    Description = "17 Ekim 1912’de Felice Bauer’e gönderdiği mektupta Kafka Amerika romanı üzerinde çalıştığını, " +
                                  "ilerleyemediğini görünce sıkıldığını ve yataktan kalkamaz hale geldiğini, bu nedenle bir öykü yazarak ara vermek istediğini yazar. " +
                                  "Dönüşüm işte böyle ortaya çıkar. " +
                                  "Kumaş pazarlamacısı olan Gregor Samsa’nın uykusundan kocaman bir böceğe dönüşerek uyanmasıyla başlayan Dönüşüm, " +
                                  "giderek gerçeklikle kurmacanın sınırlarını zorlayan müthiş bir anlatıma dönüşür.",
                    NumberOfPages = 74,
                    ReleaseDate = new DateTime(2019, 03, 01),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 0,
                    Place = "G1",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 19,
                    PublisherId = 5,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                },
                new Book
                {
                    Id = 32,
                    Name = "Kırmızı Pazartesi",
                    Description = "Kolombiyalı büyük yazar Gabriel García Márquez’in 1981’de yayımlanan yedinci romanı Kırmızı Pazartesi, " +
                                  "işleneceğini herkesin bildiği, engel olmak için kimsenin bir şey yapmadığı bir namus cinayetinin öyküsü. " +
                                  "Hem Kolombiya’da, hem de yayımlandığı dünyanın dört bir yanındaki pek çok ülkede sarsıcı etkileri olmuş bir roman. " +
                                  "Usta yazar, çocukluğunu geçirdiği kasabada yıllar önce yaşanmış bir cinayet olayını aktarıyor. " +
                                  "Romanın kahramanı Santiago Nasar’ın öldürüleceği daha ilk satırlardan belli. " +
                                  "Kırmızı Pazartesi, yalnızca bir cinayetin arka planını değil, bir halkın ortak davranış biçimlerinin potresini de çiziyor. " +
                                  "Böylece, sonuna dek ilgiyle okuyacağınız bu kısa ve ölümsüz roman, bir toplumsal ruhçözümü niteliği de kazanmış oluyor.",
                    NumberOfPages = 120,
                    ReleaseDate = new DateTime(2019, 04, 15),
                    Thumbnail = "bookImages/defaultBook.png",
                    Stock = 2,
                    Place = "G2",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    WriterId = 20,
                    PublisherId = 2,
                    NumberOfComments = 0,
                    NumberOfFavorites = 0,
                    NumberOfReads = 0,
                    RatingAverage = 0,
                    GeneralStatus = GeneralStatus.Active
                }
            });
            _context.BookCategories.AddRange(new List<BookCategory>
            {
                new BookCategory
                {
                    BookId = 1,
                    CategoryId = 1
                },
                new BookCategory
                {
                    BookId = 1,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 2,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 2,
                    CategoryId = 3,
                },
                new BookCategory
                {
                    BookId = 3,
                    CategoryId = 4,
                },
                new BookCategory
                {
                    BookId = 3,
                    CategoryId = 5,
                },
                new BookCategory
                {
                    BookId = 4,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 4,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 5,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 5,
                    CategoryId = 3,
                },
                new BookCategory
                {
                    BookId = 6,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 6,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 7,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 7,
                    CategoryId = 3,
                },
                new BookCategory
                {
                    BookId = 8,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 8,
                    CategoryId = 3,
                },
                new BookCategory
                {
                    BookId = 9,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 9,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 10,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 10,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 11,
                    CategoryId = 4,
                },
                new BookCategory
                {
                    BookId = 11,
                    CategoryId = 13,
                },
                new BookCategory
                {
                    BookId = 11,
                    CategoryId = 6,
                },
                new BookCategory
                {
                    BookId = 11,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 11,
                    CategoryId = 3,
                },
                new BookCategory
                {
                    BookId = 12,
                    CategoryId = 4,
                },
                new BookCategory
                {
                    BookId = 12,
                    CategoryId = 13,
                },
                new BookCategory
                {
                    BookId = 12,
                    CategoryId = 6,
                },
                new BookCategory
                {
                    BookId = 12,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 12,
                    CategoryId = 3,
                },
                new BookCategory
                {
                    BookId = 13,
                    CategoryId = 4,
                },
                new BookCategory
                {
                    BookId = 13,
                    CategoryId = 13,
                },
                new BookCategory
                {
                    BookId = 13,
                    CategoryId = 6,
                },
                new BookCategory
                {
                    BookId = 13,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 13,
                    CategoryId = 3,
                },
                new BookCategory
                {
                    BookId = 14,
                    CategoryId = 4,
                },
                new BookCategory
                {
                    BookId = 14,
                    CategoryId = 13,
                },
                new BookCategory
                {
                    BookId = 14,
                    CategoryId = 6,
                },
                new BookCategory
                {
                    BookId = 14,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 14,
                    CategoryId = 3,
                },
                new BookCategory
                {
                    BookId = 15,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 15,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 16,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 16,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 17,
                    CategoryId = 4,
                },
                new BookCategory
                {
                    BookId = 17,
                    CategoryId = 3,
                },
                new BookCategory
                {
                    BookId = 18,
                    CategoryId = 4,
                },
                new BookCategory
                {
                    BookId = 18,
                    CategoryId = 3,
                },
                new BookCategory
                {
                    BookId = 19,
                    CategoryId = 7,
                },
                new BookCategory
                {
                    BookId = 19,
                    CategoryId = 8,
                },
                new BookCategory
                {
                    BookId = 20,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 20,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 21,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 21,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 22,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 22,
                    CategoryId = 3,
                },
                new BookCategory
                {
                    BookId = 23,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 23,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 24,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 24,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 25,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 25,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 25,
                    CategoryId = 9,
                },
                new BookCategory
                {
                    BookId = 26,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 26,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 27,
                    CategoryId = 10,
                },
                new BookCategory
                {
                    BookId = 28,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 28,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 29,
                    CategoryId = 11,
                },
                new BookCategory
                {
                    BookId = 29,
                    CategoryId = 12,
                },
                new BookCategory
                {
                    BookId = 30,
                    CategoryId = 11,
                },
                new BookCategory
                {
                    BookId = 30,
                    CategoryId = 12,
                },
                new BookCategory
                {
                    BookId = 31,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 31,
                    CategoryId = 2,
                },
                new BookCategory
                {
                    BookId = 32,
                    CategoryId = 1,
                },
                new BookCategory
                {
                    BookId = 32,
                    CategoryId = 2,
                },
            });
            _context.Categories.AddRange(new List<Category>
            {
                new Category
                {
                    Id = 1,
                    ParentId = 0,
                    Name = "Edebiyat",
                    GeneralStatus = GeneralStatus.Active,
                },
                new Category
                {
                    Id = 2,
                    ParentId = 1,
                    Name = "Roman",
                    GeneralStatus = GeneralStatus.Active,
                },
                new Category
                {
                    Id = 3,
                    ParentId = 1,
                    Name = "Hikaye",
                    GeneralStatus = GeneralStatus.Active,
                },
                new Category
                {
                    Id = 4,
                    ParentId = 0,
                    Name = "Çocuk Kitapları",
                    GeneralStatus = GeneralStatus.Active,
                },
                new Category
                {
                    Id = 5,
                    ParentId = 4,
                    Name = "Masal",
                    GeneralStatus = GeneralStatus.Active,
                },
                new Category
                {
                    Id = 6,
                    ParentId = 0,
                    Name = "Gençlik Kitapları",
                    GeneralStatus = GeneralStatus.Active,
                },
                new Category
                {
                    Id = 7,
                    ParentId = 0,
                    Name = "Bilim & Mühendislik",
                    GeneralStatus = GeneralStatus.Active,
                },
                new Category
                {
                    Id = 8,
                    ParentId = 7,
                    Name = "Popüler Bilim",
                    GeneralStatus = GeneralStatus.Active,
                },
                new Category
                {
                    Id = 9,
                    ParentId = 1,
                    Name = "100 Temel Eser",
                    GeneralStatus = GeneralStatus.Active,
                },
                new Category
                {
                    Id = 10,
                    ParentId = 0,
                    Name = "Kişisel Gelişim",
                    GeneralStatus = GeneralStatus.Active,
                },
                new Category
                {
                    Id = 11,
                    ParentId = 0,
                    Name = "Sinema-Tiyatro",
                    GeneralStatus = GeneralStatus.Active,
                },
                new Category
                {
                    Id = 12,
                    ParentId = 11,
                    Name = "Oyun",
                    GeneralStatus = GeneralStatus.Active,
                },
                new Category
                {
                    Id = 13,
                    ParentId = 4,
                    Name = "6-12 Yaş",
                    GeneralStatus = GeneralStatus.Active,
                }
            });
            _context.Comments.AddRange(new List<Comment>
            {
                new Comment
                {
                    Id = 1,
                    UserId = 1,
                    BookId = 1,
                    CommentText = "Test Comment",
                    Rating = 3.0M,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active
                },
                new Comment
                {
                    Id = 2,
                    UserId = 1,
                    BookId = 4,
                    CommentText = "Test Comment",
                    Rating = 2.0M,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active
                },
                new Comment
                {
                    Id = 3,
                    UserId = 2,
                    BookId = 2,
                    CommentText = "Test Comment",
                    Rating = 5.0M,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active
                },
                new Comment
                {
                    Id = 4,
                    UserId = 2,
                    BookId = 3,
                    CommentText = "Test Comment",
                    Rating = 5.0M,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active
                },
                new Comment
                {
                    Id = 5,
                    UserId = 3,
                    BookId = 3,
                    CommentText = "Test Comment",
                    Rating = 5.0M,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active
                },
                new Comment
                {
                    Id = 6,
                    UserId = 3,
                    BookId = 2,
                    CommentText = "Test Comment",
                    Rating = 1.0M,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active
                },
                new Comment
                {
                    Id = 7,
                    UserId = 4,
                    BookId = 4,
                    CommentText = "Test Comment",
                    Rating = 4.0M,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active
                },
                new Comment
                {
                    Id = 8,
                    UserId = 4,
                    BookId = 1,
                    CommentText = "Test Comment",
                    Rating = 5.0M,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active
                }
            });
            _context.Contacts.AddRange(new List<Contact>
            {
                new Contact
                {
                    Id = 1,
                    UserId = 1,
                    Content = "Test Contact",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active
                },
                new Contact
                {
                    Id = 2,
                    UserId = 2,
                    Content = "Test Contact",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active
                },
                new Contact
                {
                    Id = 3,
                    UserId = 3,
                    Content = "Test Contact",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active
                },
                new Contact
                {
                    Id = 4,
                    UserId = 4,
                    Content = "Test Contact",
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active
                }
            });
            _context.FavoriteBooks.AddRange(new List<FavoriteBook>
            {
                new FavoriteBook
                {
                    UserId = 1,
                    BookId = 1
                },
                new FavoriteBook
                {
                    UserId = 1,
                    BookId = 2
                },
                new FavoriteBook
                {
                    UserId = 1,
                    BookId = 3
                },
                new FavoriteBook
                {
                    UserId = 1,
                    BookId = 4
                },
                new FavoriteBook
                {
                    UserId = 2,
                    BookId = 1
                },
                new FavoriteBook
                {
                    UserId = 2,
                    BookId = 2
                },
                new FavoriteBook
                {
                    UserId = 2,
                    BookId = 3
                },
                new FavoriteBook
                {
                    UserId = 2,
                    BookId = 4
                }
            });
            _context.Publishers.AddRange(new List<Publisher>
            {
                new Publisher
                {
                    Id = 1,
                    Name = "Kırmızı Kedi Yayınevi",
                    Description = "Kırmızı Kedi Yayınevi",
                    GeneralStatus = GeneralStatus.Active
                },
                new Publisher
                {
                    Id = 2,
                    Name = "Can Yayınları",
                    Description = "Can Yayınları",
                    GeneralStatus = GeneralStatus.Active
                },
                new Publisher
                {
                    Id = 3,
                    Name = "Yapı Kredi Yayınları",
                    Description = "Yapı Kredi Yayınları",
                    GeneralStatus = GeneralStatus.Active
                },
                new Publisher
                {
                    Id = 4,
                    Name = "İthaki Yayınları",
                    Description = "İthaki Yayınları",
                    GeneralStatus = GeneralStatus.Active
                },
                new Publisher
                {
                    Id = 5,
                    Name = "İş Bankası Kültür Yayınları",
                    Description = "İş Bankası Kültür Yayınları",
                    GeneralStatus = GeneralStatus.Active
                },
                new Publisher
                {
                    Id = 6,
                    Name = "Doğan Kitap",
                    Description = "Doğan Kitap",
                    GeneralStatus = GeneralStatus.Active
                },
                new Publisher
                {
                    Id = 7,
                    Name = "Dergah Yayınları",
                    Description = "Dergah Yayınları",
                    GeneralStatus = GeneralStatus.Active
                },
                new Publisher
                {
                    Id = 8,
                    Name = "Eksik Parça Çocuk",
                    Description = "Eksik Parça Çocuk",
                    GeneralStatus = GeneralStatus.Active
                },
                new Publisher
                {
                    Id = 9,
                    Name = "Pegasus Yaynları",
                    Description = "Pegasus Yaynları",
                    GeneralStatus = GeneralStatus.Active
                },
                new Publisher
                {
                    Id = 10,
                    Name = "Sel Yayıncılık",
                    Description = "Sel Yayıncılık",
                    GeneralStatus = GeneralStatus.Active
                },
                new Publisher
                {
                    Id = 11,
                    Name = "Kronik Kitap",
                    Description = "Kronik Kitap",
                    GeneralStatus = GeneralStatus.Active
                },
                new Publisher
                {
                    Id = 12,
                    Name = "Ötüken Neşriyat",
                    Description = "Yapı Kredi Yayınları",
                    GeneralStatus = GeneralStatus.Active
                }
            });
            _context.Users.AddRange(new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "User",
                    UserName = "admin",
                    Password = PasswordHelper.Encrypt("rootuser"),
                    Email = "adminuser@adminuser.com",
                    PhoneNumber = "+901111111111",
                    Gender = "Bot",
                    About = "Deneme amacıyla oluşturulmuştur.",
                    Picture = "userImages/defaultRoot.png",
                    DateBirth = new DateTime(2020,01,01),
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active,
                    AccessStatus = AccessStatus.Manager
                },
                new User
                {
                    Id = 2,
                    FirstName = "Member",
                    LastName = "User",
                    UserName = "member",
                    Password = PasswordHelper.Encrypt("testuser"),
                    Email = "memberuser@memberuser.com",
                    PhoneNumber = "+902222222222",
                    Gender = "Bot",
                    About = "Deneme amacıyla oluşturulmuştur.",
                    Picture = "userImages/defaultUser.png",
                    DateBirth = new DateTime(2020,01,01),
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active,
                    AccessStatus = AccessStatus.Member
                },
                new User
                {
                    Id = 3,
                    FirstName = "Visitor",
                    LastName = "User",
                    UserName = "visitor",
                    Password = PasswordHelper.Encrypt("testuser"),
                    Email = "visitoruser@tvisitoruser.com",
                    PhoneNumber = "+903333333333",
                    Gender = "Bot",
                    About = "Deneme amacıyla oluşturulmuştur.",
                    Picture = "userImages/defaultUser.png",
                    DateBirth = new DateTime(2020,01,01),
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active,
                    AccessStatus = AccessStatus.Visitor
                },
                new User
                {
                    Id = 4,
                    FirstName = "Personnel",
                    LastName = "User",
                    UserName = "personnel",
                    Password = PasswordHelper.Encrypt("testuser"),
                    Email = "personneluser@personneluser.com",
                    PhoneNumber = "+904444444444",
                    Gender = "Bot",
                    About = "Deneme amacıyla oluşturulmuştur.",
                    Picture = "userImages/defaultUser.png",
                    DateBirth = new DateTime(2020,01,01),
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    UpdatedByName = "InitialCreate",
                    UpdatedDate = DateTime.Now,
                    GeneralStatus = GeneralStatus.Active,
                    AccessStatus = AccessStatus.Personnel
                }

            });
            _context.UserBooks.AddRange(new List<UserBook>
            {
                new UserBook
                {
                    Id = 1,
                    UserId = 1,
                    BookId = 1,
                    BookStatus = BookStatus.Reading,
                    LendDate = DateTime.Now,
                    ReceiveDate = null,
                },
                new UserBook
                {
                    Id = 2,
                    UserId = 1,
                    BookId = 1,
                    BookStatus = BookStatus.Read,
                    LendDate = DateTime.Now,
                    ReceiveDate = DateTime.Now.AddHours(3),
                },
                new UserBook
                {
                    Id = 3,
                    UserId = 1,
                    BookId = 2,
                    BookStatus = BookStatus.Reading,
                    LendDate = DateTime.Now,
                    ReceiveDate = null,
                },
                new UserBook
                {
                    Id = 4,
                    UserId = 1,
                    BookId = 5,
                    BookStatus = BookStatus.Read,
                    LendDate = DateTime.Now,
                    ReceiveDate = DateTime.Now.AddHours(3),
                },
                new UserBook
                {
                    Id = 5,
                    UserId = 1,
                    BookId = 3,
                    BookStatus = BookStatus.Read,
                    LendDate = DateTime.Now,
                    ReceiveDate = DateTime.Now.AddHours(3),
                },
                new UserBook
                {
                    Id = 6,
                    UserId = 1,
                    BookId = 4,
                    BookStatus = BookStatus.Read,
                    LendDate = DateTime.Now,
                    ReceiveDate = DateTime.Now.AddHours(3),
                },
                new UserBook
                {
                    Id = 7,
                    UserId = 2,
                    BookId = 1,
                    BookStatus = BookStatus.Reading,
                    LendDate = DateTime.Now,
                    ReceiveDate = null,
                },
                new UserBook
                {
                    Id = 8,
                    UserId = 2,
                    BookId = 1,
                    BookStatus = BookStatus.Read,
                    LendDate = DateTime.Now,
                    ReceiveDate = DateTime.Now.AddHours(3),
                },
                new UserBook
                {
                    Id = 9,
                    UserId = 2,
                    BookId = 2,
                    BookStatus = BookStatus.Reading,
                    LendDate = DateTime.Now,
                    ReceiveDate = null,
                },
                new UserBook
                {
                    Id = 10,
                    UserId = 2,
                    BookId = 7,
                    BookStatus = BookStatus.Read,
                    LendDate = DateTime.Now,
                    ReceiveDate = DateTime.Now.AddHours(3),
                },
                new UserBook
                {
                    Id = 11,
                    UserId = 2,
                    BookId = 3,
                    BookStatus = BookStatus.Read,
                    LendDate = DateTime.Now,
                    ReceiveDate = DateTime.Now.AddHours(3),
                },
                new UserBook
                {
                    Id = 12,
                    UserId = 2,
                    BookId = 4,
                    BookStatus = BookStatus.Read,
                    LendDate = DateTime.Now,
                    ReceiveDate = DateTime.Now.AddHours(3),
                },
            });
            _context.Writers.AddRange(new List<Writer>
            {
                new Writer
                {
                    Id = 1,
                    Name = "Jose Saramago",
                    Biography = "Lizbon kentinin kuzeyindeki küçük bir köy olan Azinhaga'da (Ribatejo) doğdu. " +
                                "Yoksul bir köylü ailenin oğlu olarak büyüdü. Ailesiyle birlikte taşındığı Lizbon’da öğrenim gördü. " +
                                "Öğrenimi sırasında kırsal kesimde çalıştı. Ekonomik sorunları nedeniyle okulu bıraktı. " +
                                "Makinistlik eğitimi aldı. Teknik ressamlıktan redaktörlüğe, editörlüğe ve çevirmenliğe kadar birçok işte çalıştı. " +
                                "Bir yayınevinde, yayın hazırlığı ve üretim departmanında görev yaptı. " +
                                "Diario ve Lisboa gazetelerinde kültür editörü olarak çalıştı. Siyasi yorumlar yazdı. " +
                                "Portekiz Yazarlar Birliği’nin yönetim kurulunda görev üstlendi. 1976’dan sonra kendini tümüyle kitaplarına verdi. " +
                                "1993’te Kanarya Adaları’nda Lanzarote’ye yerleşti. Pilar del Rio ile evlendi. İlk romanı Günah Ülkesi(Terra do Pecado) 1947’de yayınlandı. " +
                                "Yazarın romanları ve denemelerinin yanı sıra iki şiir kitabı ve oyun kitapları da vardır. Saramago, 1998 Nobel Edebiyat Ödülü'ü kazandı. " +
                                "Yazarın biçemi gayet dikkate değerdir. Düz yazılarında, noktalama işareti olarak nokta ve virgülden başkasını kullanmaz. " +
                                "Anlatım dili de oldukça muzipçedir; bu da, okuyucuyu yazara bağlayan bir diğer etkendir. Ünlü yazar 87 yaşında hayatını kaybetmiştir.",
                    DateOfBirth = new DateTime(1922, 11, 16),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 1,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 2,
                    Name = "Jose Mauro De Vasconcelos",
                    Biography = "Rio de Janeiro yakınlarındaki Bangu'da doğdu. " +
                                "Kızılderili ve Portekizli kırması bir ailenin çocuğuydu. " +
                                "İki yıl tıp eğitimi gördü, ama bu eğitimini sonradan tamamladı. " +
                                "Çeşitli işlerde çalıştı. Boks antrenörlüğü, tarım işçiliği, balıkçılık yaptı. " +
                                "Kızılderililerin arasında yaşadı.",
                    DateOfBirth = new DateTime(1920, 02, 26),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 1,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 3,
                    Name = "Sara Şahinkanat",
                    Biography = "Çocukluk yılları ailesi, kız kardeşleri ve kuzenleri ile birlikte geçmiştir. " +
                                "Kendi oyuncaklarını kendileri yaptılar. Çocukluk yıllarında arkadaşlarını etrafında toplayarak doğaçlama tiyatro oyunları sergilerdi. " +
                                "İlkokul 2.Sınıftayken Andersen ve Grimm masallarını okurken yüksek zevk aldığını fark etti. " +
                                "11 yaşında girdiği sınavla Üsküdar Amerikan Kız Kolejine yazıldı. " +
                                "Burada iyi derecede İngilizce ve farklı kültürle tanışmanın avantajlarını gördü. " +
                                "Sara Şahinkanat edebiyat alanında eser üretmeye duygusal sorunları olan yeğenleri için küçük butik kitaplar hazırlayarak başladı. " +
                                "Reklam sektöründe olduğu için yerli kitapların görsel kalitelerini yetersiz buldu. " +
                                "2001 yılında oğlu Tan’ın dünyaya gelmesi ile yazmaya başladığı resimli kitapları çocuklar tarafından oldukça beğenilmektedir. " +
                                "Yazarın en sevilen çocuk kitabı olan Üç Kedi Bir Dilek İngilizce olarak Yapı Kredi Yayınları tarafından basıldı.",
                    DateOfBirth = new DateTime(1966, 01, 01),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 1,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 4,
                    Name = "Aldous Huxley",
                    Biography =
                        "Surrey’de doğdu. Genç yaşta yakalandığı bir hastalık sonucu görme yetisini büyük ölçüde yitirince, tıp öğrenimini yarıda bırakmak zorunda kaldı. " +
                        "Bundan sonra edebiyata yönelen Huxley, daha oxford’daki öğrencilik yıllarında iki şiir kitabı yazdı. " +
                        "1920’den itibaren peş peşe romanlar yayımlayan yazar, Batı medeniyetini alaycı bir dille eleştirdiği eserleriyle ün saldı. " +
                        "Deneysel romancılık tekniğiyle insan aklının işleyişini sorguladı ve uyuşturucu kullanımından mistisizme dek birçok konuyla ilgilendi. " +
                        "Başlıca eserleri şunlardır: Crome Yellow, Music at Night, Brave New World, Eyeless in Gaza.",
                    DateOfBirth = new DateTime(1894, 07, 26),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 1,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 5,
                    Name = "Stefan Zweig",
                    Biography = "Stefan Zweig 1881 yılında Viyana'da doğdu. " +
                                "Babası varlıklı bir sanayiciydi. Viyana ve Berlin'de eğitim gördü. B" +
                                "irçok ülkeyi dolaştıktan sonra Birinci Dünya Savaşı sırasında, Zürih'e geldi. " +
                                "Savaş karşıtı kişiliğiyle tanındı. " +
                                "1919-1934 yılları arasında Salzburg'da yaşadı, 1938'de İngiltere'ye, 1939'da New York'a gitti, birkaç ay sonra da Brezilya'ya yerleşti. " +
                                "Avrupa'nın içine düştüğü duruma dayanamayarak 1942 yılında karısıyla birlikte intihar etti. " +
                                "Çok sayıda denemesi, öyküsü, uzun öyküsü ve romanı yanında, büyük bir ustalıkla kaleme aldığı yaşam öyküleriyle de ünlüdür.",
                    DateOfBirth = new DateTime(1881, 11, 28),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 4,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 6,
                    Name = "Zülfü Livaneli",
                    Biography =
                        "Romanları 30 dilde yayımlanan Zülfü Livaneli, 1946 yılında doğdu. " +
                        "1972 yılında fikirlerinden dolayı askeri cezaevinde yattı, 11 yıl sürgünde yaşadı. Livaneli, 1999 yılında San Remo’da En İyi Besteci ödülüne layık görüldü. " +
                        "Müzik eserleri Londra, Moskova, Berlin, Atina, İzmir Senfoni orkestraları tarafından icra edildi ve Zubin Mehta, Simeon Kogan gibi şeflerce yönetildi." +
                        "Türkiye dışında Çin Halk Cumhuriyeti, İspanya, Kore ve Almanya’da da çok satanlar arasına giren romanlarıyla, " +
                        "Balkan Edebiyat Ödülü’ne, ABD’de Barnes and Noble Büyük Yazar Ödülü’ne, " +
                        "İtalya ve Fransa’da Yılın Kitabı Ödülü’ne, Türkiye’de ise Yunus Nadi Ödülü’ne ve Orhan Kemal Roman Ödülü’ne layık görüldü. " +
                        "Livaneli, dünya kültür ve barışına yaptığı katkılardan ötürü 1996 yılında Paris’te UNESCO tarafından Büyükelçilikle onurlandırıldı ve " +
                        "Genel Direktör danışmanlığına atandı.2002-2006 yılları arasında TBMM’de ve Avrupa Konseyi’nde milletvekilliği görevinde bulundu.",
                    DateOfBirth = new DateTime(1946, 06, 20),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 2,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 7,
                    Name = "J. K. Rowling",
                    Biography = "1965’te İngiltere’nin Bristol kenti yakınlarındaki Chipping Sodbury’de doğdu. " +
                                "Exeter Üniversitesi Fransız Dili ve Edebiyatı bölümünü bitirdikten sonra, yabancı dilini ilerletmek için bir yıl Paris’te kaldı. " +
                                "Ardından, Fransızca konuşulan Afrika ülkelerinde insan haklarıyla ilgili çalışmalar yaptı. " +
                                "1990 yılından itibaren Harry Potter kitap dizisini yazmaya başladı ve kısa sürede tüm dünyada büyük başarı kazandı.",
                    DateOfBirth = new DateTime(1965, 07, 31),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 4,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 8,
                    Name = "Ahmet Hamdi Tanpınar",
                    Biography =
                        "İstanbul'un Şehzadebaşı semtinde doğdu. " +
                        "Babası devletin çeşitli livâ ve vilâyetlerinde kadılık yapan, Antalya kadısı iken emekli olan ve 1935'de İstanbul'da ölen Hüseyin Fikri Efendi'dir. " +
                        "Aile, aslen Batumlu olup 'Mızrakçıoğulları' veya 'Müftizâdeler' diye bilinmektedir. " +
                        "(Sadeddin Nüshet Ergun'un Türk şairlerinde Ahmet Hamdi'ye ayrılan maddede, adının yanında 'Mızrakçıoğlu' lakabı konulmuş olduğuna göre soyadı kanunundan önce şairin bu aile ismini kullandığı anlaşılmaktadır). " +
                        "Annesi Nesime Bahriye Hanım ise, Trabzonlu 'Kansızzâdeler'den, deniz yüzbaşısı Ahmet Bey'in kızıdır. " +
                        "Ahmet Hamdi Tanpınar eserleriyle olduğu kadar şahsiyeti ve hayat tarzı ve bütün bunların arkaplanında sahip olduğu kültürün derinliği ile de, " +
                        "yakın devir edebiyatımızın önemli şahsiyetleri arasında hususi bir yer alır. " +
                        "Ondaki hülya ve kültür birikimini yakın dostlarının anekdotlarından çıkarabiliyoruz. " +
                        "Edebiyatın hemen her alanında (roman, hikâye, deneme, şiir, tenkit, inceleme, edebiyat tarihi) eser vermiş olmakla beraber daha çok şair tarafıyla tanınan Tanpınar, " +
                        "mektup ve hatıralarında kendisini değerlendirmesi de poetik bir karakter taşır. " +
                        "23 Ocak 1962 günü geçirdiği kalb krizi ile Haseki Hastahanesi'ne kaldırıldı. Ertesi sabah, ikinci bir krizle hayata veda etti.",
                    DateOfBirth = new DateTime(1901, 06, 23),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 1,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 9,
                    Name = "Orhan Pamuk",
                    Biography = "Orhan Pamuk 1952'de İstanbul'da doğdu. " +
                                "Cevdet Bey ve Oğulları ve Kara Kitap adlı romanlarında anlattığına benzer kalabalık bir ailede ve şehrin Batılılaşmış ve zengin semti Nişantaşı'nda büyüyüp yetişti. " +
                                "Otobiyografik kitabı İstanbul'da anlattığı gibi Pamuk çocukluğundan yirmi iki yaşına kadar yoğun bir şekilde resim yaparak ve ileride ressam olacağını düşleyerek yaşadı. " +
                                "Liseyi İstanbul'daki Amerikan lisesi Robert College'de okudu. " +
                                "İstanbul Teknik Üniversitesi'nde üç yıl mimarlık okuduktan sonra, mimar ve ressam olmayacağına karar verip bıraktı. " +
                                "İstanbul Üniversitesi'nde gazetecilik okudu, ama bu işi de hiç yapmadı. " +
                                "Pamuk, yirmi üç yaşından sonra romancı olmaya karar vererek başka her şeyi bıraktı ve kendini evine kapatıp yazmaya başladı. " +
                                "2006 yılında Nobel Ödülünü kazanarak bu ödülü alan en genç iki kişiden biri olmuştur.",
                    DateOfBirth = new DateTime(1952, 06, 07),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 1,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 10,
                    Name = "Varol Yaşaroğlu",
                    Biography =
                        "“Kendi yarattığımız hayal dünyasında her şeyi değiştirmek mümkün” söylemini yaşam tarzı yapmış; " +
                        "mizah, karikatür ve animasyona aşık, Koca Kafalar’ın yaratıcısı ve Grafi2000′in kurucusu. " +
                        "Bütün projelerde Berk Tokay ve kardeşi Vural Yaşaroğlu ile birlikte gerçekleştirmiş. " +
                        "2002-2005 yıllarında Kanal D'de ülkede hiç alışkın olmayan tarzdaki Grafi2000 programının yapımcılığını ve sunuculuğu yapmıştır. " +
                        "Programda yayınlanan skeçlerinde birinde Şahan Gökbakar da yer alır. " +
                        "Karikatür, illüstrasyon ve animasyon çalışmalarının hepsini ekibiyle birlikte kâğıt kaleme hiç dokunmadan bilgisayar ortamında oluşturan Varol Yaşaroğlu, " +
                        "çeşitli üniversitelerde Bilgisayar-internet ve mizah üzerine seminerler verirken, “Ekonomist” ve “Capital” dergilerinin karikatüristliğini ve illüstratörlüğünü yapmaya devam ediyor.",
                    DateOfBirth = new DateTime(1968, 03, 01),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 2,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 11,
                    Name = "Jared Diamond",
                    Biography = "Coğrafya profesörü olan Jared Diamond halen Kaliforniya Üniversitesi’nde öğretim üyesidir. " +
                                "Fizyoloji alanında başladığı akademik kariyerine daha sonra biocoğrafya alanında devam etti. " +
                                "Ulusal Bilim Madalyası, Tyler Çevre Başarısı Ödülü, Japonya Kozmoz Ödülü olmak üzere çeşitli ödüllere layık görüldü. " +
                                "Discover, Natural History, Nature ve Geo dergilerinde iki yüzden fazla makalesi yayınladı. " +
                                "Tüfek, Mikrop ve Çelik kitabıyla Pulitzer Ödülü’nü kazandı.",
                    DateOfBirth = new DateTime(1937, 09, 10),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 1,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 12,
                    Name = "Sabahattin Ali",
                    Biography =
                        "Gümülcine’de doğdu, 2 Nisan 1948’de Kırklareli’nde öldü. " +
                        "1948’de bir yazısı yüzünden tutuklandı, üç ay kadar hapis yattı. " +
                        "Sürekli izlendiği için yurtdışına kaçmak istedi, ancak Kırklareli dolaylarında bir kaçakçı tarafından öldürüldüğü iddia edildi. " +
                        "Şiirler, hikâyeler, romanlar yazdı, çeviriler yaptı.",
                    DateOfBirth = new DateTime(1907, 02, 25),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 2,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 13,
                    Name = "Lev N. Tolstoy",
                    Biography = "Toprak sahibi, soylu bir ailenin oğluydu. " +
                                "Çocuk yaşta anne ve babası öldüğü için, akrabaları tarafından yetiştirildi. " +
                                "16 yaşında Rusya’daki Kazan Üniversitesi’ne girdi ama bir süre sonra, resmi eğitime duyduğu tepki nedeniyle oradan ayrıldı " +
                                "ve topraklarını yöneterek kendi kendini eğitmeye karar verdi. " +
                                "1862 yılında Sofya Andreyevna Bers ile evlendi, on üç çocuğu oldu. " +
                                "Tolstoy, Shakespeare'den sonra dünya dillerine en çok tercümesi yapılan yazardır. " +
                                "Yirminci yüzyılın en önemli ahlakçı yazarlarından Lev Tolstoy, 1910 yılında, ıssız bir tren istasyonunda, zatürreden öldü.",
                    DateOfBirth = new DateTime(1828, 09, 09),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 1,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 14,
                    Name = "Paulo Coelho",
                    Biography =
                        "Brezilya'da doğdu. Unesco'nun Kültürlerarası Diyaloglar programında danışman olarak görev yapmaktadır. " +
                        "Aynı zamanda İsviçre'nin Davos kentindeki Dünya Ekonomik Formunu düzenleyen Schwab Vakfı'nın yönetim kurulundadır.",
                    DateOfBirth = new DateTime(1947, 08, 24),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 2,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 15,
                    Name = "John Steinbeck",
                    Biography = "1962 Nobel Edebiyat Ödülü sahibi John Steinbeck dünya edebiyatına ölümsüz yapıtlar kazandırmış bir yazardır. " +
                                "1902'de California'da doğan, John Steinbeck, 1968'de New York'ta öldü. " +
                                "İnsan-doğa ve insan-insan ilişkilerini, özellikle de, çalışan tüm kesimlerin yaşamlarını anlatmadaki başarısıyla ünlüdür.",
                    DateOfBirth = new DateTime(1902, 02, 27),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 2,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 16,
                    Name = "Prof. Dr. İlber Ortaylı",
                    Biography =
                        "Ankara Üniversitesi Siyasal Bilgiler Fakültesi (1969) ile Ankara Üniversitesi Dil Tarih Coğrafya Fakültesi Tarih Bölümü’nü bitirdi. " +
                        "Chicago Üniversitesi′nde master çalışmasını Prof. Halil İnalcık ile yaptı. " +
                        "“Tanzimat Sonrası Mahalli İdareler” adlı tezi ile doktor, “Osmanlı İmparatorluğu′nda Alman Nüfuzu” adlı çalışmasıyla da doçent oldu. " +
                        "Viyana, Berlin, Paris, Princeton, Moskova, Roma, Münih, Strasbourg, Yanya, Sofya, Kiel, Cambridge, Oxford ve Tunus üniversitelerinde misafir öğretim üyeliği yaptı, " +
                        "seminerler ve konferanslar verdi. " +
                        "Yerli ve yabancı bilimsel dergilerde Osmanlı tarihinin 16. ve 19. yüzyılı ve Rusya tarihiyle ilgili makaleler yayınladı. " +
                        "1989–2002 yılları arasında Siyasal Bilgiler Fakültesi′nde İdare Tarihi Bilim Dalı Başkanı olarak görev yapmış, 2002 yılında Galatasaray Üniversitesi′ne geçmiştir. " +
                        "Uluslararası Osmanlı Etüdleri Komitesi Yönetim Kurulu üyesi ve Avrupa Iranoloji Cemiyeti üyesidir.",
                    DateOfBirth = new DateTime(1947, 05, 21),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 1,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 17,
                    Name = "Cengiz Aytmatov",
                    Biography = "Cengiz Aytmatov Dünya Edebiyatının gelmiş geçmiş en büyük yazarlarından biridir. " +
                                "1928 yılında Kırgızistan’ın başkenti Bişkek’e bağlı olan ve Talas vadisinde yer alan Şeker Köyü’nde doğar. " +
                                "Babası Törekul Aytmatov, annesi Nagima Hamzayevna Aytmatova’dır. " +
                                "Memur olan babası 1937 yılında Stalin’in temizlik harekâtının kurbanları arasına katılır. " +
                                "Kemikleri 1991 yılında bulunur. Yazarı modern bir kadın olan annesi büyütür. " +
                                "Aytmatov, ilkokula kendi köyünde gider. Babaannesi Ayımkan beş altı yaşlarından itibaren torununu ninniler, masallar, efsanelerle besler.",
                    DateOfBirth = new DateTime(1928, 12, 12),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 1,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 18,
                    Name = "William Shakespeare",
                    Biography =
                        "William Shakespeare orta-batı İngiltere’de Warwickshire vilayetinin Stratford-on-Avon kasabasında doğmuştur. " +
                        "Stratford, Avon nehrinin kuzey kıyısına kurulmuş 1500 nüfuslu bir kasabaydı. " +
                        "Burada o devirde dokumacılık, dericilik, ayakkabıcılık, demircilik ve halıcılık gibi işlerin geliştiği anlaşılıyor. " +
                        "Kasabanın Oxford ve Londra ile yol irtibatı vardı. Kasabada orta derecede eğitim veren ve “Grammar School” denilen, bir okul bulunuyordu. " +
                        "İşte Shakespeare’in çocukluğu ve gençliği böyle bir çevrede geçmiştir. " +
                        "Shakespeare’in babası John Shakespeare’in Stratford‘un yerlisi olmadığı anlaşılıyor, çünkü kasabanın doğum kayıtlarında böyle bir isme rastlanmıyor. " +
                        "John Shakespeare ismine ilk olarak 29 Nisan 1552 tarihinde rastlıyoruz; bu da onun izin almadan evinin önüne çöp yığdığından dolayı " +
                        "1 şilin cezaya çarptırıldığı hakkındaki bir kayıtta görülüyor. " +
                        "Shakespeare’in babasının kim olduğu, nereden geldiği hakkındaki bütün araştırmalar kesin bir sonuç vermemiştir.",
                    DateOfBirth = new DateTime(1900, 04, 01),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 2,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 19,
                    Name = "Franz Kafka",
                    Biography = "Temmuz 1883'te Prag’da ufak moda eşyalar satan bir dükkan işleten Hermann ve Julie Kafka'nın 6 çocuğunun ilki olarak dünyaya gelmiştir. " +
                                "İki erkek kardeşi daha bebekken ölmüştür. 3 kız kardeşi de kendinden uzun yaşamıştır. Hukuk okumuş, boş zamanlarında yazmaya başlamıştır. " +
                                "Yazıları, ilk olarak Betrachtung, 1912 yılından itibaren yayımlanmaya başlamıştır. " +
                                "Kafka'nın duygusal deneyimleri ve ailesiyle olan ilişkileri eserlerinde özellikle günlük ve mektuplarında ifade bulmuştur. " +
                                "Babaya Mektup'ta (Almanca: Brief an den Vater) Kafka'nın bakış açısından babasıyla olan ilişkisi gözükmektedir. " +
                                "Hayatta olduğu süre içerisinde 7 kitap yazmıştır, bunların yanında 3 tamamlanmamış roman ve birçok mektup ve günlük bırakmıştır gerisinde. " +
                                "Kafka yakın arkadaşı Max Brod'dan öldüğünde tüm bu eserlerini yakmasını istemiştir. " +
                                "Max Brod'un Kafka'nın bu isteğini yerine getirmemesi sayesinde bugün bu eserleri okuma şansına sahibiz.",
                    DateOfBirth = new DateTime(1883, 07, 03),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 1,
                    GeneralStatus = GeneralStatus.Active
                },
                new Writer
                {
                    Id = 20,
                    Name = "Gabriel Garcia Marquez",
                    Biography =
                        "1928 yılında Kolombiya'da doğan García Márquez, büyükannesiyle büyükbabasının evinde, teyzelerinin yanında büyüdü. " +
                        "Boş inançlara bağlı, olağanüstü olayları doğallıkla anlatan, her söylenene inanan bu kadınların anlattıkları, García Marquez'in üslubunun biçimlenmesine yardımcı olmuştur. " +
                        "Roman yazmaya başlamadan önce gazetecilik yapan García Marquez, " +
                        "bu deneyimi sayesinde romanlarındaki büyülü gerçekçiliği, tuzağa düşmeden, ayaklarını yere sağlamca basarak işleyebilmiştir. " +
                        "García Marquez, romanlarının korsan basımlarının yüzbinleri bulması üzerine kitaplarının, anayurdu Kolombiya'da yayınlanmasını yasaklamıştır." +
                        "García Marquez, Latin Amerika'yı ilkel güzelliği ve el değmemişliği içinde tanıtırken, " +
                        "düş ile belleği, olayların akışını gösterişsiz, ama şaşırtıcı bir üslupla birbirine karıştırırken, tarihsel doğruluğa ve gerçekliğe bağlı kalmaya da özen gösteren bir yazar. " +
                        "1982 yılında Nobel Edebiyat Ödülünü almıştır. 17.04.2014 Meksiko'daki evinde 87 yaşında hayata veda etti.",
                    DateOfBirth = new DateTime(1927, 03, 06),
                    Picture = "writerImages/defaultWriter.jpg",
                    NumberOfBooks = 1,
                    GeneralStatus = GeneralStatus.Active
                }
            });
            SaveChanges();
        }

        #endregion Constructor

        #region BusinessSection

        /// <summary>
        /// İşlemlerin veritabanına kaydedilmesi bu method ile gerçekleşiyor..
        /// </summary>
        public int SaveChanges()
        {
            try
            {
                //Context boş ise hata fırlatıyoruz
                if (_context == null)
                    throw new ArgumentException("Context is null");
                
                //Save changes metodundan dönen int result ı yakalayarak geri dönüyoruz.
                var result = _context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error on save changes ", ex);
            }
        }
        public IGenericRepository<T> GetRepository<T>() where T : class, IEntity, new()
        {
            return new GenericRepository<T>(_context);
        }

        #endregion BusinessSection

        #region DisposingSection

        /// <summary>
        /// Context ile işimiz bittiğinde dispose edilmesini sağlıyoruz
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing) _context.Dispose();
            _disposed = true;
        }

        #endregion DisposingSection
    }
}