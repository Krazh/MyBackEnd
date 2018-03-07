using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharedPOCO;
using ModelUser = SharedPOCO.User;
using EfUser = MyBackEnd.Assets.User;
using MyBackEnd.Assets;

namespace MyBackEnd
{
    public partial class MyService : IService
    {
        public ModelUser CurrentUser;

        public ModelUser Login(string userName, string password)
        {
            try
            {
                var result = UserHandler.Login(userName, password);
                if (result == null)
                    throw new Exception("Username or Password is wrong");
                result.Password = string.Empty;
                SetCurrentUser(result);
                return result;
            }
            catch (Exception ex)
            {
                ErrorHandler.ReportError(ex, CurrentUser.Id);
                return null;
            }
        }

        public bool UserExists(int id)
        {
            try
            {
                return UserHandler.UserExists(id);
            }
            catch (Exception e)
            {
                ErrorHandler.ReportError(e, CurrentUser.Id);
                return false;
            }
            
        }

        public void SetCurrentUser(ModelUser user)
        {
            try
            {
                if (!UserExists(user.Id))
                    throw new Exception("No User found");
                CurrentUser = user;
            }
            catch (Exception e)
            {
                if (!UserExists(user.Id))
                    user.Id = CurrentUser.Id;
                ErrorHandler.ReportError(e, user.Id);
            }
        }

        public ModelUser GetUser(int id)
        {
            try
            {
                return UserHandler.GetUser(id);
            }
            catch (Exception ex)
            {
                ErrorHandler.ReportError(ex, CurrentUser.Id);
                return new ModelUser();
            }
        }

        public ModelUser GetTestUser()
        {
            return UserHandler.GetTestUser().ConvertObj<EfUser, ModelUser>();
        }

        public List<ModelUser> GetAllUsers()
        {
            try
            {
                return UserHandler.GetAllUsers();
            }
            catch (Exception e)
            {
                ErrorHandler.ReportError(e, CurrentUser.Id);
                return new List<ModelUser>();
            }
        }

        public bool UpdateUser(ModelUser user)
        {
            try
            {
                return UserHandler.UpdateUser(user);
            }
            catch (Exception e)
            {
                ErrorHandler.ReportError(e, CurrentUser.Id);
                return false;
            }
        }

        public ModelUser CreateUser(ModelUser user)
        {
            try
            {
                return UserHandler.CreateUser(user);
            }
            catch (Exception e)
            {
                if (CurrentUser != null)
                    ErrorHandler.ReportError(e, CurrentUser.Id);
                else
                    ErrorHandler.ReportError(e, 5);
                return null;
            }
        }

        public bool DeleteUser(ModelUser user)
        {
            try
            {
                return UserHandler.DeleteUser(user);
            }
            catch (Exception e)
            {
                ErrorHandler.ReportError(e, CurrentUser.Id);
                return false;
            }
        }
    }
}