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
        //Sa Get-na
        public IEnumerable<Person> GetData()
        {
            // Im ognakan classic vercnuma tvyalner@ u poxancuma  web.api-in, sa el ir hertin` wpf-in
            return PersonDataClass.list;
        }


        //Sa Post-na
        public string PostData(Person info)
        {
            // Vercnuma ekac personin(im mot info-na) u avelacnuma en ognakan static class-i listi mej
            PersonDataClass.list.Add(info);

            // Veradardzuma string vor amen lava, avelacrel em, ete iharke 19-rd toxum bug chi linum 
            return info.Name + "  added to list";
        }
    }
}
