using MyBackEnd.Assets;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackEnd
{
    public interface IErrorSetContext : IDisposable, IContext
    {
        List<Error> ErrorSet { get; }
        void MarkAsChanged(Error error, EntityState state);
    }
}
