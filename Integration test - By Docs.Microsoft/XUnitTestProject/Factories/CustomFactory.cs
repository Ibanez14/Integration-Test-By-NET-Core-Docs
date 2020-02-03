using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Text;
using WebApp;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace XUnitTestProject.Custom_Factory_Testing
{

    /// <summary>
    /// By Intereting from WebAppplicationFactory you can define your own services
    /// and Delete services you dont want
    /// </summary>
    public class CustomFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IRoleService, RoleService>();
                services.AddScoped<ISomeService, SomeService>();
                services.AddScoped<IDataService, MyDataService>();


                // This way you can delete service from collection

                // throw Exception if more that one IRolService is registered
                // so ensure that only one service is registered

                var serviceToDelete = services.SingleOrDefault(c => c.ServiceType == typeof(IRoleService));
                services.Remove(serviceToDelete);
                // Now IRoleService in unavaliable


                // for examples delete DbContextOptions<AppContext>
                // and add your own one

                var descriptor = services.SingleOrDefault( d => d.ServiceType ==
                                          typeof(DbContextOptions<ApplicationDbContext>));

                if (descriptor != null)
                    services.Remove(descriptor);
                

                // Add ApplicationDbContext using an in-memory database for testing.
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });
            });
        }
    }

}


