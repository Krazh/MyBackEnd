﻿using System;
using System.Collections.Generic;
using SharedPOCO;
using ModelUser = SharedPOCO.User;
using EfUser = MyBackEnd.Assets.User;
using System.Linq;
using System.Data.Entity;
using CryptSharp;
using System.Text;

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

        #region Public Methods

        #region CRUD
        public ModelUser CreateUser(ModelUser user, string password, string repeatedPassword)
        {
            if (user == null)
                throw new ArgumentException("Parameter is null");
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repeatedPassword))
                throw new ArgumentException("Parameter is null");
            if (password != repeatedPassword)
                throw new ArgumentException("Passwords doesn't match");
            if (!CheckNonNullablePropertiesAreNotNull(user))
                throw new ArgumentException("Non nullable properties are null");
            if (UserNameExists(user.UserName))
                throw new Exception("Username already exists");
            EfUser u = user.ConvertObj<ModelUser, EfUser>();
            u.Password = new Assets.Password();
            u.Password.Salt = Crypter.Blowfish.GenerateSalt();
            u.Password.Hash = HashPassword(password, u.Password.Salt);
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
            if (user == null)
                throw new Exception("Parameter is null");
            if (!UserExists(user.Id))
                throw new Exception("User doesn't exist");
            EfUser u = user.ConvertObj<ModelUser, EfUser>();
            db.UserSet.Attach(u);
            db.MarkAsChanged(u, EntityState.Deleted);
            db.SaveChanges();
            return true;
        }
        #endregion

        #region Login
        public ModelUser Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                throw new Exception("All fields must be filled");

            var user = db.UserSet.FirstOrDefault(x => x.UserName == userName);

            if (string.IsNullOrEmpty(user.Password.Hash))
                throw new Exception("User password is not set");
            if (string.IsNullOrEmpty(user.Password.Salt))
                throw new Exception("No Salt found");
            if (user.Password.Hash != HashPassword(password, user.Password.Salt))
                throw new Exception("Wrong password entered");

            return user.ConvertObj<EfUser, ModelUser>();
        }
        #endregion

        public EfUser GetTestUser()
        {
            return new EfUser()
            {
                AccessRightsId = 3,
                Address = "lolstreet 14",
                BusinessId = 3,
                Email = "lol@lol.dk",
                FirstName = "Morten",
                LastName = "The Champ",
                Id = 17,
                PhoneNumber = "12345678",
                UserName = "krazh",
                FullName = "Morten The Champ",
                CityId = 1
            };
        }

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

        #endregion

        #region Private Methods
        private string HashPassword(string password, string salt)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(salt))
                throw new Exception("Parameter is null");
            byte[] b = Encoding.UTF8.GetBytes(password);

            string s = Crypter.Blowfish.Crypt(b, salt);
            
            return s;
        }

        private bool UserNameExists(string username)
        {
            var user = db.UserSet.SingleOrDefault(x => x.UserName == username);
            if (user == null)
                return false;
            return true;
        }

        private bool CheckNonNullablePropertiesAreNotNull(ModelUser user)
        {
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.PhoneNumber))
                return false;
            return true;
        }
        #endregion
    }
}