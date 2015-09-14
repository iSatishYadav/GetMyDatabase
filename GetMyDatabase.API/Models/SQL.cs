using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GetMyDatabase.API.Models
{
    public class SQL
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public DateTime Created { get; set; }
    }
}