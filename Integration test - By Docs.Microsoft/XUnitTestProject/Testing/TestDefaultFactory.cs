using Microsoft.AspNetCore.Mvc.Testing;
using System;
using WebApp;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApp.Services;
using Microsoft.AspNetCore.Http;
using XUnitTestProject.Custom_Factory_Testing;
using System.Threading.Tasks;

namespace XUnitTestProject
{

    // Test classes implement a class fixture interface (IClassFixture)
    // to indicate the class contains tests and provide shared object 
    // instances across the tests in the class.

    // Here we use WebApplicationFactory that is .NET Core cretaed by default
    // WebApplicationFactory<TEntryPoint> is used to create a TestServer for the integration tests.



    public class TestDefaultFactory : IClassFixture<WebApplicationFactory<Startup>>
    {
        WebApplicationFactory<Startup> factory;

        public TestDefaultFactory(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }


       
        [Theory]
        [InlineData("/api/values")]
        [InlineData("/api/product")]
        public async Task ValuesController_Return200(string url)
        {
            // Arrange
            // This httpClient is create by .NET core default WebApplicationFactory
            // CreateClient creates an instance of HttpClient that automatically follows redirects and handles cookies.
            var httpClient = factory.CreateClient();

            // Act
            var response = await httpClient.GetAsync(url);

            // Assert
            // Response.EnsureSuccessStatusCode();
            Assert.True(response.IsSuccessStatusCode);
        }




        [Fact]
        public void DataServiceReturnNull()
        {
            using (var scope = factory.Services.CreateScope())
            {
                var dataService = scope.ServiceProvider.GetService<IDataService>();
                string someData = dataService.GiveSomeData();
                Assert.Equal("Creedence", someData);
            }
        }
    }
}
