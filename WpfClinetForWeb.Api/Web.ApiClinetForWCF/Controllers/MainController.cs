using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.ApiClinetForWCF.ServiceReference1; //avelacrel em WCF-service-i namespace-@

namespace Web.ApiClinetForWCF.Controllers
{
    public class MainController : ApiController
    {
        // Ay amenakarevor@, sarqel em WCF-i clienti instance-@  :))))
        Service1Client wcfclient = new Service1Client();

        // GET api/main
        public string GetNumber()
        {
            // Hima im Responce-@ ekel u gtela GetNumber funkcian
            // result-ov, vor@ wcfclient-ov kpnuma WCF-in kanchuma WCF-i  GetData funkcian, vor@ stanuma qo entadracov 5 tiv@
            string result = wcfclient.GetData(5);

            // u veradardznuma string, vor@ GetNumber funkcian result-ov heta uxarkum WPF-in
            return result;

        }



        // GET api/main/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/main
        public void Post([FromBody]string value)
        {
        }

        // PUT api/main/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/main/5
        public void Delete(int id)
        {
        }
    }
}
