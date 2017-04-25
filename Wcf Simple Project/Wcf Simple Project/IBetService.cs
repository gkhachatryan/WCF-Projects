using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFSimpleProject
{
    
    [ServiceContract]
    public interface IBetService
    {
        [OperationContract]
        string GetValue(int i);

        [OperationContract]
        List<double> CalculateSin(double[] x);

        [OperationContract]
        List<Person> GetPerson();
    }
}
