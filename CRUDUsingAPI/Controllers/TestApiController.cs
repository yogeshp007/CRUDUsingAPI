using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDUsingAPI.Controllers
{
    public class TestApiController : ApiController
    {
        [HttpGet]
        public string HelloWorld()
        {
            return "hello";
        }
    }
}
