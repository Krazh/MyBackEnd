using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MyBackEnd.Assets;

namespace MyBackEnd
{
    public class ErrorSetContext : DbContext, IErrorSetContext
    {
        public List<Error> ErrorSet { get; set; }

        public void MarkAsChanged(Error error, EntityState state)
        {
            Entry(error).State = state;
        }
    }
}