using Backend.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
        public interface IServiceRepository
        {
            List<Service> GetAll();
            Service GetById(int id);
            void Add(Service service);
            void Update(Service service);
            void Delete(Service service);
            bool SaveChanges();
        }
    }



