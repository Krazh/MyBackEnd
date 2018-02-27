using SharedPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using ModelError = SharedPOCO.Error;
using EfError = MyBackEnd.Assets.Error;
using System.Web;

namespace MyBackEnd
{
    public class ErrorHandler
    {
        private ModelError currentError = new ModelError();
        private IErrorSetContext db = new ErrorSetContext();

        #region Constructors

        public ErrorHandler()
        {
        }

        public ErrorHandler(IErrorSetContext context)
        {
            db = context;
        }

        #endregion

        public ModelError GetCurrentError()
        {
            if (currentError == null)
                return null;

            return currentError;
        }

        public List<ModelError> GetCurrentErrorsForUser(User user)
        {
            if (user == null)
                return null;
            List<ModelError> list = (from e in db.ErrorSet
                             where e.UserId == user.Id
                             select e.ConvertObj<EfError, ModelError>()).ToList();
            return list;
        }

        public void ReportError(Exception ex, int userId)
        {
            try
            {
                if (ex == null)
                    throw new Exception("Null value passed as argument");

                if (userId == 0)
                    throw new Exception("UserId is null");

                EfError error = new EfError()
                {
                    Message = ex.Message,
                    UserId = userId
                };
                db.ErrorSet.Add(error);
                db.SaveChanges();
                currentError = error.ConvertObj<EfError, ModelError>();
            }
            catch (Exception e)
            {

            }
        }
    }
}