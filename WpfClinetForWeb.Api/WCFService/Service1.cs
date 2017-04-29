using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        //verjapes kpel em WCF-in :D

        public string GetData(int value)
        {
            // hima im en uxarkac tiv@, vor du asel eir tox 5 lini, ekela stex
            // qo asacov bazmapatkel em baic voch te 8-ov, ayl 23,46-ov
            return string.Format("Dear Tigran thank You and take our number 5 multiplied by 23,46: ----> {0}", value * 23.46);
        }




        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
