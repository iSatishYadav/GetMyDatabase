using GetMyDatabase.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GetMyDatabase.API.Controllers
{
    public class DatabaseController : ApiController
    {
        public List<Database> Get()
        {
            var model = new Database().GetAll();
            return model;
        }
    }
}
