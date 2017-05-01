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
        Service1Client wcfclinet = new Service1Client();

        public IEnumerable<Person> Get()
        {
            IEnumerable<Person> personresult = wcfclinet.GetData();
            return personresult;
        }

        public IHttpActionResult Post([FromBody]Person info)
        {
            string responce = wcfclinet.PostDataAsync(info).Result;

            if(responce!=null)
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
