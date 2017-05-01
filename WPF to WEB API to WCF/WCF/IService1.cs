using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        IEnumerable<Person> GetData();

        [OperationContract]
        string PostData(Person info);
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }
    }

    public static class PersonDataClass
    {
        public static List<Person> list = new List<Person>();

        static PersonDataClass()
        {
            list.Add(new Person() { ID = 1, Name = "Teacher Tigran", Age = 18 });
            list.Add(new Person() { ID = 2, Name = "Van", Age = 18 });
            list.Add(new Person() { ID = 3, Name = "Lusine", Age = 18 });
            list.Add(new Person() { ID = 4, Name = "Tsovinar", Age = 18 });
            list.Add(new Person() { ID = 5, Name = "Narek", Age = 18 });
        }
    }
}
