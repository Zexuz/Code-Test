using Autofac;
using Microsoft.Extensions.Configuration;
using Startsys.Core.Loggers;
using Stratsys.WebApi.Loggers;
using Stratsys.WebApi.Middlewares;

namespace Stratsys.WebApi
{
    public class WebApiModel:Module
    {
        
        private readonly IConfiguration _configuration;

        public WebApiModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsoleLogger>().As<ILogger>();
        } 
        
    }
}