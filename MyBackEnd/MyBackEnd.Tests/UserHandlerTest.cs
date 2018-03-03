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
        #region Get User
        [TestMethod]
        public void GetUser_ShouldThrowExceptionIfIdIsNull()
        {
            UserHandler handler = new UserHandler(new UserTestContext());

            try
            {
                var result = handler.GetUser(0);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("ID is not set or 0", ex.Message);
            }
        }

        [TestMethod]
        public void GetUser_ShouldThrowExceptionIfUserIdDoesNotExist()
        {
            UserHandler handler = new UserHandler(new UserTestContext());

            ModelUser u1 = new ModelUser()
            {
                Id = 1,
                FirstName = "lol",
                LastName = "more lol",
                PhoneNumber = "123"
            };

            try
            {
                var u2 = handler.CreateUser(u1);
                var result = handler.GetUser(2);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("User doesn't exist", ex.Message);
            }
        }
        #endregion
        #region Update User

        /// <summary>
        /// Not currently working correctly. UserHandler doesn't update an object currently when it's not connected to an actual dbcontext file.
        /// TestMethod should either be updated to implement a test database or UserHandler should be changed to take account for testing.
        /// Add [TestMethod] when finished
        /// </summary>
        public void UpdateUser_ShouldUpdateValues()
        {
            UserHandler handler = new UserHandler(new UserTestContext());

            ModelUser u1 = new ModelUser()
            {
                FirstName = "Tester",
                LastName = "Person 1",
                PhoneNumber = "123",
                Id = 1
            };

            try
            {
                var result = handler.CreateUser(u1);

                u1.LastName = "Person 2";

                var r2 = handler.UpdateUser(u1);

                if (!r2)
                    Assert.Fail();

                var newUser = handler.GetUser(u1.Id);
                Assert.AreEqual(u1.LastName, newUser.LastName);
            }
            catch (Exception ex)
            {
            }
        }

        [TestMethod]
        public void UpdateUser_ShouldFailIfUserDoesNotExist()
        {
            UserHandler handler = new UserHandler(new UserTestContext());

            try
            {
                ModelUser u1 = new ModelUser()
                {
                    Id = 1,
                    FirstName = "Lol",
                    LastName = "more lol",
                    PhoneNumber = "123"
                };
                var result = handler.UpdateUser(u1);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("User doesn't exist", ex.Message);
            }
        }

        [TestMethod]
        public void UpdateUser_ShouldFailOnNullParameter()
        {
            UserHandler handler = new UserHandler(new UserTestContext());

            try
            {
                var result = handler.UpdateUser(null);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Parameter is null", ex.Message);
            }
        }
        #endregion
        #region Delete User
        [TestMethod]
        public void DeleteUser_ShouldFailIfUserDoesNotExist()
        {
            UserHandler handler = new UserHandler(new UserTestContext());

            try
            {
                ModelUser u = new ModelUser();
                u.Id = 1;

                var result = handler.DeleteUser(u);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("User doesn't exist", ex.Message);
            }
        }

        [TestMethod]
        public void DeleteUser_ShouldFailOnNullObject()
        {
            UserHandler handler = new UserHandler(new UserTestContext());

            try
            {
                var result = handler.DeleteUser(null);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Parameter is null", ex.Message);
            }
        }
        #endregion
        #region Login
        [TestMethod]
        public void Login_ShouldReturnNullObjectOnWrongValues()
        {
            UserHandler handler = new UserHandler(new UserTestContext());

            ModelUser u1 = new ModelUser()
            {
                FirstName = "Tester",
                LastName = "Person 1",
                PhoneNumber = "123",
                Id = 1,
                UserName = "test",
                Password = "test"
            };

            handler.CreateUser(u1);

            var result = handler.Login(u1.UserName, "123");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Login_ShouldFailOnNullParameters()
        {
            UserHandler handler = new UserHandler(new UserTestContext());

            ModelUser u1 = new ModelUser()
            {
                FirstName = "Tester",
                LastName = "Person 1",
                PhoneNumber = "123",
                Id = 1,
                UserName = "test",
                Password = "test"
            };

            handler.CreateUser(u1);

            try
            {
                handler.Login("", "123");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("All fields must be filled", ex.Message);
            }

            try
            {
                handler.Login("123", "");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("All fields must be filled", ex.Message);
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
