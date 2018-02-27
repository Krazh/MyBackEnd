using MyBackEnd.Assets;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyBackEnd
{
    public class UserSetContext : DbContext, IUserSetContext
    {
        public UserSetContext() : base("name = SalesCommEntities")
        {

        }

        public DbSet<User> UserSet { get; set; }

        public void MarkAsChanged(User user, EntityState state)
        {
            Entry(user).State = state;
        }
    }
}