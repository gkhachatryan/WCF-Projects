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

        [OperationContract]
        string PutData(Person info);
    }

    // Sa mer person classna, u ays nuyn class-is WPF-um el ka, vor  ABC keterin bavarari?
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

    // pastoren, vor SQl-in lav tirapetenq el nman ognakan classner mez petq chen lini?
    // stexcum em im ognakan class@, vori mijocov person-neri list em stanalu
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
