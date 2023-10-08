using Negocio.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository
{
    public abstract class BaseRepository
    {
        private readonly ApplicationContext _applicationContext;
        public BaseRepository(ApplicationContext applicationContext) => _applicationContext = applicationContext;
    }
}
