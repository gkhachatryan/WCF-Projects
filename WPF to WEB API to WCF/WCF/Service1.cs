using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        
        public IEnumerable<Person> GetData()
        {
            return PersonDataClass.list;
        }

        public string PostData(Person info)
        {
            PersonDataClass.list.Add(info);

            return info.Name + "  added to list";
        }
    }
}
