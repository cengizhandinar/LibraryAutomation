using System.Configuration;
using System.Data.Entity;
using Library.Entities.Entities.Concrete;

namespace Library.Data.EntityFramework.Context
{
    /// <summary>
    /// Bu sınıf bizim DbContext sınıfımız yani database ile ilgili tanımlamaların ve bağlantıların bulunduğu sınıftır.
    /// </summary>
    public class AppDbContext : DbContext
    {
        #region Constructor

        /// <summary>
        /// Constructor yani yapıcı method bizim için bu sınıf türetildiğinde devreye ilk girecek olan kısımdır.
        /// </summary>
        public AppDbContext() : base(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString)
        {
        }

        #endregion Constructor

        #region DbSets

        /// <summary>
        /// Projemiz içerisinde kullanacağımız tüm entity sınıflarımızı bu kısımda DbSet ile tanımlıyoruz
        /// Bu sayede migration yaparken bu sınıflar veritabanında birer tablo olarak oluşturulacak ve yapacağımız CRUD işlemler veritabanına yansıyacak.
        /// </summary>

        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FavoriteBook> FavoriteBooks { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<Writer> Writers { get; set; }

        #endregion DbSets

        #region ModelCreating

        /// <summary>
        /// Veritabanı oluşurken tablolar ile ilgili validasyon ayarlarını yapıyoruz.
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>().HasKey(bc => new { bc.BookId, bc.CategoryId });

            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Book>().Property(b => b.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(b => b.Description).IsRequired().HasColumnType("NVARCHAR(MAX)");
            modelBuilder.Entity<Book>().Property(b => b.Thumbnail).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<Book>().Property(b => b.ReleaseDate).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.NumberOfPages).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Stock).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Place).IsRequired().HasMaxLength(4);
            modelBuilder.Entity<Book>().Property(b => b.CreatedDate).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.UpdatedDate).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.GeneralStatus).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.CreatedByName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(b => b.UpdatedByName).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.ParentId).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).HasName("CategoryNameIndex").IsUnique();
            modelBuilder.Entity<Category>().Property(c => c.GeneralStatus).IsRequired();

            modelBuilder.Entity<Comment>().HasKey(c => c.Id);
            modelBuilder.Entity<Comment>().Property(c => c.CommentText).IsRequired().HasMaxLength(300);
            modelBuilder.Entity<Comment>().Property(c => c.UserId).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.BookId).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.CreatedDate).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.UpdatedDate).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.GeneralStatus).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.CreatedByName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Comment>().Property(c => c.UpdatedByName).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Contact>().HasKey(c => c.Id);
            modelBuilder.Entity<Contact>().Property(c => c.UserId).IsRequired();
            modelBuilder.Entity<Contact>().Property(c => c.Content).IsRequired().HasMaxLength(750);
            modelBuilder.Entity<Contact>().Property(c => c.CreatedDate).IsRequired();
            modelBuilder.Entity<Contact>().Property(c => c.UpdatedDate).IsRequired();
            modelBuilder.Entity<Contact>().Property(c => c.GeneralStatus).IsRequired();
            modelBuilder.Entity<Contact>().Property(c => c.CreatedByName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Contact>().Property(c => c.UpdatedByName).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<FavoriteBook>().HasKey(fb => new { fb.UserId, fb.BookId });

            modelBuilder.Entity<Publisher>().HasKey(p => p.Id);
            modelBuilder.Entity<Publisher>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Publisher>().HasIndex(p => p.Name).HasName("PublisherNameIndex").IsUnique();
            modelBuilder.Entity<Publisher>().Property(p => p.Description).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Publisher>().Property(p => p.GeneralStatus).IsRequired();

            modelBuilder.Entity<UserBook>().HasKey(ub => ub.Id );

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.FirstName).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(u => u.LastName).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(u => u.UserName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(75).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.PhoneNumber).IsRequired().HasMaxLength(13);
            modelBuilder.Entity<User>().Property(u => u.Gender).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<User>().Property(u => u.About).IsRequired().HasMaxLength(1000);
            modelBuilder.Entity<User>().Property(u => u.Picture).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<User>().Property(u => u.DateBirth).IsRequired();
            modelBuilder.Entity<User>().Property(c => c.CreatedDate).IsRequired();
            modelBuilder.Entity<User>().Property(c => c.UpdatedDate).IsRequired();
            modelBuilder.Entity<User>().Property(c => c.GeneralStatus).IsRequired();
            modelBuilder.Entity<User>().Property(c => c.AccessStatus).IsRequired();
            modelBuilder.Entity<User>().Property(c => c.CreatedByName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(c => c.UpdatedByName).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Writer>().HasKey(w => w.Id);
            modelBuilder.Entity<Writer>().Property(w => w.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Writer>().HasIndex(w => w.Name).HasName("WriterNameIndex").IsUnique();
            modelBuilder.Entity<Writer>().Property(w => w.Biography).IsRequired().HasMaxLength(1500);
            modelBuilder.Entity<Writer>().Property(w => w.Picture).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<Writer>().Property(w => w.DateOfBirth).IsRequired();
            modelBuilder.Entity<Writer>().Property(w => w.NumberOfBooks).IsRequired();
            modelBuilder.Entity<Writer>().Property(w => w.GeneralStatus).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        #endregion ModelCreating
    }
}