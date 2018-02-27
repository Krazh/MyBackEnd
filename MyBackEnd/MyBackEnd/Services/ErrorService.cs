using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharedPOCO;
using ModelError = SharedPOCO.Error;
using ModelUser = SharedPOCO.User;
using EfUser = MyBackEnd.Assets.User;

namespace MyBackEnd
{
    public partial class MyService : IService
    {
        public ModelError GetLastError()
        {
            return ErrorHandler.GetCurrentError();
        }

        public List<ModelError> GetCurrentErrorsForUser(ModelUser user)
        {
            return ErrorHandler.GetCurrentErrorsForUser(user);
        }
    }
}