using NAGP.Services.ProviderAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NAGP.Services.ProviderAPI.Repositories
{
    public class ProviderRepository
    {
        private readonly List<Provider> providers;

        public ProviderRepository()
        {
            providers = new List<Provider>
            {
                new Provider{Id = 1, Name ="roahn", Username="roahn@123", Password="roahn@123", ContactNumber="9871778941", ServiceArea="Haryana", ServiceId=1},
                new Provider{Id = 2, Name ="sujeet", Username="sujeet@123", Password="sujeet@123", ContactNumber="9871778931", ServiceArea="Delhi",ServiceId=2},
                new Provider{Id = 3, Name ="gaurav", Username="gaurav@123", Password="gaurav@123", ContactNumber="9871778942", ServiceArea="Haryana",ServiceId=3},
                new Provider{Id = 4, Name ="himanshu", Username="tina@123", Password="tina@123", ContactNumber="9871778932", ServiceArea="UP",ServiceId=4},
            };
        }

        public List<Provider> Providers()
        {
            return providers;
        }
        public List<Provider> AvailableProviders(int serviceId)
        {
            return providers.FindAll(x=> x.IsAvailable && x.ServiceId == serviceId);
        }

        public Provider GetProviderById(int id)
        {
            return providers.FirstOrDefault(x=> x.Id == id);   
        }

        public bool IsValidProvider(string username, string password)
        {
            Provider provider = providers.FirstOrDefault(x => x.Username == username && x.Password == password);
            return provider != null;
        }
    }
}
