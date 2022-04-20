using NAGP.Services.ServiceAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NAGP.Services.ServiceAPI.Repositories
{
    public class ServiceRepository
    {
        private List<Service> services;

        public ServiceRepository()
        {
            services = new List<Service>
            {
                new Service { Id = 1, Name = "plumber", Description = "Provide all the plumber related services.", Charges="1000" },
                new Service { Id = 2, Name = "beautician", Description = "Provide beauty related services", Charges="1500" },
                new Service { Id = 3, Name = "housekeeping", Description = "Provide housekeeping services.", Charges="600"  },
                new Service { Id = 4, Name = "Ac & Appliance repair", Description = "Provide Ac & Appliance repair services", Charges="500"  },
                new Service { Id = 5, Name = "Cleaning & Pest Control", Description = "Provides Cleaning & Pest Control related services.", Charges="700"  }
            };
        }

        public List<Service> GetServices()
        {
            return services;
        }

        public Service GetServiceById(int id)
        {
            return services.FirstOrDefault(x => x.Id == id);
        }

    }
}
