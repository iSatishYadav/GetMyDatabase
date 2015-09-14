using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GetMyDatabase.API.Models
{
    public class Connection
    {
        public String ConnectionString
        {
            get
            {
                var connectionKey = ConfigurationManager.AppSettings["ConnectionString"];
                if (connectionKey != null)
                {
                    var connectionString = connectionKey.ToString();
                    return String.IsNullOrEmpty(connectionString) ? null : connectionString;
                }
                else
                    return null;
            }
        }
    }
}