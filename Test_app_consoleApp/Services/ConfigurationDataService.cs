using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Test_app_consoleApp.Models;

namespace Test_app_consoleApp.Services
{
    public class ConfigurationDataService
    {
        private readonly ConfigurationDataModel _data;
        private static ConfigurationDataService _instance;
        private ConfigurationDataService() 
        {
            var config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            _data = config.Get<ConfigurationDataModel>();
        }
        public static ConfigurationDataService Instance => _instance ?? (_instance = new ConfigurationDataService());

        public ConfigurationDataModel Data 
        {
            get 
            {
                return Instance._data;
            }
        }
    }
}
