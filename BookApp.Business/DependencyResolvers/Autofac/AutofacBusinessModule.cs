using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BookApp.Business.Abstract;
using BookApp.Business.Concrete;
using BookApp.DataAccess.Abstract;
using BookApp.DataAccess.Concrete.EntityFramework;

namespace BookApp.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfBookRepository>().As<IBookRepository>().SingleInstance();
            builder.RegisterType<EfGenreRepository>().As<IGenreRepository>().SingleInstance();
            builder.RegisterType<EfContactRepository>().As<IContactRepository>().SingleInstance();
            builder.RegisterType<EfWriterRepository>().As<IWriterRepository>().SingleInstance();

            builder.RegisterType<BookManager>().As<IBookService>().SingleInstance();
            builder.RegisterType<GenreManager>().As<IGenreService>().SingleInstance();
            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<WriterManager>().As<IWriterService>().SingleInstance();


        }
    }
}
