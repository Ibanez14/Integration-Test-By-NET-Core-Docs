using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IDataService
    {
        string GiveSomeData();
        string GiveMeNull();
    }

    public class DataService : IDataService
    {
        public string GiveMeNull()
        {
            return null;
        }

        public string GiveSomeData()
        {
            return "Creedence";
        }
    }
}
