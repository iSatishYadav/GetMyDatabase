using GetMyDatabase.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GetMyDatabase.API.Controllers
{
    public class ColumnController : ApiController
    {
        public List<Column> GetAll([FromUri]string[] parameters)
        {
            var model = new Column().GetAll(parameters[0], parameters[1]);
            return model;            
        }
    }
}
