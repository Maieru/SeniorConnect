using Negocio.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public abstract class BaseEntityRepository
    {
        protected readonly ApplicationContext _applicationContext;
        public BaseEntityRepository(ApplicationContext applicationContext) => _applicationContext = applicationContext;
    }
}
