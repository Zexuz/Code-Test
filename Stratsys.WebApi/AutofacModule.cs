using Autofac;
using Microsoft.Extensions.Configuration;
using Stratsys.WebApi.Loggers;
using Stratsys.WebApi.Middlewares;

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
            builder.RegisterType<ConsoleLogger>().As<ILogger>();
        } 
        
    }
}