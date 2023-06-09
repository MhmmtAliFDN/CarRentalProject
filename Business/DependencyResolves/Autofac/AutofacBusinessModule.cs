using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<CarImageManager>().As<ICarImageService>();
            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<RentalManager>().As<IRentalService>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
        }
    }
}
