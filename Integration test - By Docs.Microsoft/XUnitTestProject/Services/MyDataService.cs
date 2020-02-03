using System;
using WebApp.Services;

namespace XUnitTestProject.Custom_Factory_Testing
{
    // By inhereting from IDataService and registering it in CustomFactory 
    // you override the IDataService registration in Startup
    public class MyDataService : IDataService
    {
        public string GiveMeNull()
        {
            throw new NotImplementedException();
        }

        public string GiveSomeData()
        {
            return "Revival";
        }
    }

}


