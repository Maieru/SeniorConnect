using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Negocio.Database;
using Negocio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Test.Repository
{
    public class BaseEntityTest<T> where T : BaseEntityRepository
    {
        protected readonly ApplicationContext _applicationContext;
        protected readonly T _repository;

        public BaseEntityTest()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            _applicationContext = new ApplicationContext(dbOptions.Options);
            _repository = (T)Activator.CreateInstance(typeof(T), _applicationContext);
        }
    }
}
