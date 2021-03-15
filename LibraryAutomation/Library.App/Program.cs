using System;
using System.Windows.Forms;
using Library.App.General;
using Library.Data.Abstract;
using Library.Data.EntityFramework.UnitOfWork;
using Library.Data.ImageHelper;
using Library.Services.Abstract;
using Library.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Library.App
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var pageMain = serviceProvider.GetRequiredService<Main>();
                Application.Run(pageMain);
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<Main>()
                .AddScoped<IBookService, BookManager>()
                .AddScoped<IBookCategoryService, BookCategoryManager>()
                .AddScoped<ICategoryService, CategoryManager>()
                .AddScoped<ICommentService, CommentManager>()
                .AddScoped<IContactService, ContactManager>()
                .AddScoped<IFavoriteBookService, FavoriteBookManager>()
                .AddScoped<IPublisherService, PublisherManager>()
                .AddScoped<IUserService, UserManager>()
                .AddScoped<IUserBookService, UserBookManager>()
                .AddScoped<IWriterService, WriterManager>()
                .AddScoped<IImageHelper, ImageHelper>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}