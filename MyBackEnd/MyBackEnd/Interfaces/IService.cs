﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ModelUser = SharedPOCO.User;
using ModelError = SharedPOCO.Error;
using System.Web;

namespace MyBackEnd
{
    [ServiceContract]
    public interface IService
    {
        #region UserService
        [OperationContract]
        ModelUser GetTestUser();

        [OperationContract]
        ModelUser GetUser(int id);

        [OperationContract]
        List<ModelUser> GetAllUsers();

        [OperationContract]
        bool UpdateUser(ModelUser user);

        [OperationContract]
        ModelUser CreateUser(ModelUser user);

        [OperationContract]
        bool DeleteUser(ModelUser user);
        #endregion

        #region ErrorService
        ModelError GetLastError();
        List<ModelError> GetCurrentErrorsForUser(ModelUser user);
        #endregion
    }
}