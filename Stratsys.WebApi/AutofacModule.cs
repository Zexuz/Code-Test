using Autofac;
using Microsoft.Extensions.Configuration;

namespace Stratsys.WebApi
{
    public class AutofacModule:Module
    {
        
        private readonly IConfiguration _configuration;

        public AutofacModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
//            builder.RegisterType<UserService>().As<IUserService>();
        } 
        
    }
}