using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBackEnd;
using MyBackEnd.Assets;
using SharedPOCO;
using System.Linq;
using User = MyBackEnd.Assets.User;
using ModelUser = SharedPOCO.User;
using System.Data.Entity;

namespace MyBackEnd.Tests
{
    [TestClass]
    public class UserHandlerTest
    {
        #region Create User
        [TestMethod]
        public void CreateUser_ShouldReturnSameUser()
        {
            var handler = new UserHandler(new UserTestContext());

            var user = handler.GetTestUser();

            var result = handler.CreateUser(user.ConvertObj<User, ModelUser>()).ConvertObj<ModelUser, User>();

            Assert.IsNotNull(result);
            Assert.AreEqual(user.FullName, result.FullName);
            Assert.AreEqual(user.Id, result.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUser_ShouldFailOnNullObject()
        {
            var handler = new UserHandler(new UserTestContext());

            ModelUser user = null;
            var result = handler.CreateUser(user);
        }

        [TestMethod]
        public void CreateUser_ShouldFailOnNullProperties()
        {
            var handler = new UserHandler(new UserTestContext());

            ModelUser user = new ModelUser()
            {
                FirstName = null
            };

            try
            {
                var result = handler.CreateUser(user);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Non nullable properties are null", ex.Message);
            }
        }

        [TestMethod]
        public void CreateUser_ShouldFailIfUserNameExists()
        {
            var handler = new UserHandler(new UserTestContext());

            var testUser = handler.GetTestUser().ConvertObj<User, ModelUser>();
            handler.CreateUser(testUser);

            try
            {
                var test = handler.CreateUser(testUser);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Username already exists", ex.Message);                
            }
        }
        #endregion

    }

    public class UserTestContext : IUserSetContext
    {
        public DbSet<User> UserSet { get; set; }

        public UserTestContext()
        {
            UserSet = new TestUserDbSet();
        }


        public void Dispose()
        {
            
        }

        public void MarkAsChanged(User user, EntityState state)
        {
            
        }

        public int SaveChanges()
        {
            return 0;
        }
    }

    public class TestUserDbSet : TestDbSet<User>
    {
        public override User Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.Id == (int)keyValues.Single());
        }
    }
}
