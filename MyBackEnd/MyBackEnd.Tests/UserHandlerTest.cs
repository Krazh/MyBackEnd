using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBackEnd;
using MyBackEnd.Assets;
using SharedPOCO;

namespace MyBackEnd.Tests
{
    [TestClass]
    public class UserHandlerTest
    {
        private UserHandler Handler;
        private UserTestContext context;

        [TestInitialize]
        public void TestInitialize()
        {
            context = new UserTestContext();
            Handler = new UserHandler(context);
        }

        [TestMethod]
        public void TestMethod1()
        {
            
        }
    }

    public class UserTestContext : IUserSetContext
    {
        public System.Data.Entity.DbSet<Assets.User> UserSet => throw new NotImplementedException();

        public void Dispose()
        {
            
        }

        public System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void MarkAsChanged(Assets.User user, System.Data.Entity.EntityState state)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
