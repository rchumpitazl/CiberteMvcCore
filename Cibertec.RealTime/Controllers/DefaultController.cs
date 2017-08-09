
using System.Collections.Generic;
using System.Web.Http;

namespace Cibertec.RealTime.Controllers
{
    public class DefaultController : ApiController
    {
        public IHttpActionResult Get()
        {
            var list = new List<Test>();

            for(int i=0; i < 3000; i++)
            {
                list.Add(new Test { Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" } );
            }

            return Ok(list);
        }

        public class Test
        {
            public string Text { get; set; }
        }
    }
}
