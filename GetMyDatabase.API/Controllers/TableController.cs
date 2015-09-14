using GetMyDatabase.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GetMyDatabase.API.Controllers
{
    public class TableController : ApiController
    {
        public IEnumerable<IGrouping<String, Table>> Get([FromUri]String [] databases)
        {
            var model = new Table().GetAll(databases);
            return model;
        }
    }
}
