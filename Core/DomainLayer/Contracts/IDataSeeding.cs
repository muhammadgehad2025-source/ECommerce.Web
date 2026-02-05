using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracts
{
    public interface IDataSeeding
    {
        // we need data seeding to test our database as it will be empty without it
        Task DataSeedAsync();
    }
}
