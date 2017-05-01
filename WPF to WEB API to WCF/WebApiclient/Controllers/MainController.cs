using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiclient.ServiceReference1;

namespace WebApiclient.Controllers
{
    public class MainController : ApiController
    {
        // Sarqel em WCF-i clienti instance-@
        Service1Client wcfclinet = new Service1Client();

        // Get@ arden veradardznuma  personneri collection
        public IEnumerable<Person> Get()
        {
            // Hima im Get Responce-@ ekel u gtela Get funkcian
            // personresult-ov, vor@ wcfclient-ov kpnuma WCF-in kanchuma WCF-i  GetData funkcian
            IEnumerable<Person> personresult = wcfclinet.GetData();

            // u poxancum em ayd collection@ wpf-in
            return personresult;
        }


        // Post-na, sranov nor person-in uxarkum em wcf, u i patasxan asuma` stacvela te voch
        public IHttpActionResult Post([FromBody]Person info)
        {

            // infon-n wpf-ic ekac nor personna, iran vorpes parametr talis em wcf-i postdata funkciayin
            // vor@ patasxaneluya stringov ete amen inch lav gna, ete che urem response-@ null klini
            string responce = wcfclinet.PostDataAsync(info).Result;

            //  wpf-in asum em amen inch lava @ntacel te voch
            if (responce != null)
            {
                return Ok(responce);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
