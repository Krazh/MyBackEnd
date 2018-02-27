using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyBackEnd
{
    public partial class MyService : IService 
    {
        public MyService()
        {
            ErrorHandler = new ErrorHandler();
            UserHandler = new UserHandler();
        }

        public UserHandler UserHandler;
        public ErrorHandler ErrorHandler;
    }
}
