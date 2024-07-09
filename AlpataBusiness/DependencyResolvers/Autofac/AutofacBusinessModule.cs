using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using AlpataBusiness.Abstract;
using AlpataData.Abstract;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using AlpataBusiness.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register services and dependencies
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            // Register data access layer
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            // Enable interception for classes that implement interfaces
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                   .AsImplementedInterfaces()
                   .EnableInterfaceInterceptors();

            // Register the interceptor selector
            builder.RegisterType<AspectInterceptorSelector>().As<IInterceptorSelector>().SingleInstance();
        }
    }
}
