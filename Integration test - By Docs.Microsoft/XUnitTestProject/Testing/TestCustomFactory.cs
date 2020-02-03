using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Services;
using Xunit;

namespace XUnitTestProject.Custom_Factory_Testing
{
    public class TestCustomFactory:IClassFixture<CustomFactory>
    {
        private readonly CustomFactory factory;

        public TestCustomFactory(CustomFactory customFactoryx)
        {
            this.factory = customFactoryx;
        }


        /// <summary>
        /// Такое же метод есть в TestDefaultFactory где мы полчаем фактори по умолчанию
        /// Но даже если мы в этом методе имеет наш кастомный фактори, HttpClient всеравно работает также
        /// Зачет
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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







        /// <summary>
        /// ISomeService настроен в CustomFactory
        /// </summary>
        [Fact]
        public void TestSomeService()
        {
            using (var scope = factory.Services.CreateScope())
            {
                var someService = scope.ServiceProvider.GetService<ISomeService>();
                string someData = someService.GiveSomeData();
                Assert.NotNull(someData);
            }
        }


        /// <summary>
        /// Не смотря на то что в CustomFactory мы добавили только один сервис ISomeService
        /// Мы всеравно можем вытянуть сервис IDataService настроенный в Startup
        /// НО мы можем в CustomFactory добавить свою IDataService и ниже получить ее
        /// </summary>
        [Fact]
        public void TestDataService()
        {
            using (var scope = factory.Services.CreateScope())
            {
                var dataService = scope.ServiceProvider.GetService<IDataService>();
                string someData = dataService.GiveSomeData();
                Assert.Equal("Revival", someData);
            }
        }
    }
}
