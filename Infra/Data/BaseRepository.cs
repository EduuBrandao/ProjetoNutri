using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data
{
    public class BaseRepository<T>
    {
        protected NutriContext Context { get; set; }

        public BaseRepository(NutriContext context)
        {
            this.Context = context;
        }
    }
}
