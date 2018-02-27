using System;
using System.Collections.Generic;
using SharedPOCO;
using ModelUser = SharedPOCO.User;
using EfUser = MyBackEnd.Assets.User;
using System.Linq;
using System.Data.Entity;

namespace MyBackEnd
{
    public class UserHandler
    {
        private IUserSetContext db = new UserSetContext();

        #region Constructors
        public UserHandler()
        {
        }

        public UserHandler(IUserSetContext context)
        {
            db = context;
        }
        #endregion

        public bool UserExists(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("ID is not set or 0");
                }

                var result = (from t in db.UserSet
                              where t.Id == id
                              select t).Count();
                if (result == 0) return false;

                return true;
            }
            catch (Exception e)
            {
                //_errorHandler.ReportError(e, CurrentUser.ConvertObj<ModelUser, User>());
                return false;
            }
        }

        #region CRUD
        public ModelUser CreateUser(ModelUser user)
        {

            if (user == null)
                throw new Exception("Parameter is null");
            if (UserNameExists(user.UserName))
                throw new Exception("Username already exists");
            EfUser u = user.ConvertObj<ModelUser, EfUser>();
            var s = db.UserSet.Add(u);
            db.SaveChanges();
            return u.ConvertObj<EfUser, ModelUser>();
        }

        public ModelUser GetUser(int id)
        {
            if (id == 0)
                throw new Exception("ID is not set or 0");
            if (!UserExists(id))
                throw new Exception("User doesn't exist");
            EfUser user = db.UserSet.Find(id);
            ModelUser returnUser = new ModelUser();
            returnUser = user.ConvertObj<EfUser, ModelUser>();
            return returnUser;
        }

        public List<ModelUser> GetAllUsers()
        {
            List<ModelUser> list = new List<ModelUser>();
            List<EfUser> users = db.UserSet.ToList();
            foreach (EfUser user in users)
            {
                list.Add(user.ConvertObj<EfUser, ModelUser>());
            }
            return list;
        }

        public bool UpdateUser(ModelUser user)
        {
            if (user == null)
                throw new Exception("Parameter is null");
            if (!UserExists(user.Id))
                throw new Exception("User doesn't exist");
            db.MarkAsChanged(user.ConvertObj<ModelUser, EfUser>(), EntityState.Modified);
            db.SaveChanges();
            return true;
        }

        public bool DeleteUser(ModelUser user)
        {
            if (!UserExists(user.Id))
                throw new Exception("User doesn't exist");
            EfUser u = user.ConvertObj<ModelUser, EfUser>();
            db.UserSet.Attach(u);
            db.MarkAsChanged(u, EntityState.Deleted);
            db.SaveChanges();
            return true;
        }

        #endregion

        #region Private Methods
        private bool UserNameExists(string username)
        {
            var user = db.UserSet.SingleOrDefault(x => x.UserName == username);
            if (user == null)
                return false;
            return true;
        }

        #endregion
    }
}