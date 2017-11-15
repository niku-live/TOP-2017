using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lecture_10_WS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OurFirstWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OurFirstWebService.svc or OurFirstWebService.svc.cs at the Solution Explorer and start debugging.
    public class OurFirstWebService : IOurFirstWebService
    {


        public string GetHelloMessage(string myName)
        {
            return $"Hello, my friend {myName}";
        }
    }
}
