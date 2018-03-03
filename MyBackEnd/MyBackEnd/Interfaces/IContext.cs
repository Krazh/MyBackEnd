using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBackEnd.Assets;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MyBackEnd
{
    public interface IContext
    {
        int SaveChanges();
    }
}
