using Autofac;
using Microsoft.Extensions.Configuration;
using Startsys.Core;
using Startsys.Core.Loggers;
using Startsys.Core.Models;
using Startsys.Core.Services.Impl;
using Startsys.Core.Services.Interfaces;
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

            var validAgeRange = new Range(Config.MinAge, Config.MaxAge);
            var validHeightRange = new Range(Config.MinHeight, Config.MaxHeight);
            
            builder.RegisterType<ConsoleLogger>().As<ILogger>();

            builder.Register(context => new SkiService(validAgeRange, validHeightRange)).As<ISkiService>();
        } 
        
    }
}