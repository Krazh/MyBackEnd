using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyBackEnd.Assets;
using System.Data.Entity.Infrastructure;

namespace MyBackEnd
{
    public interface IUserSetContext : IDisposable, IContext
    {
        DbSet<User> UserSet { get; }
        void MarkAsChanged(User user, EntityState state);
    }
}
