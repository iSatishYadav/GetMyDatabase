using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GetMyDatabase.API.Models
{
    public class Database : SQL
    {        
        public List<Database> GetAll()
        {
            using (var connection = new SqlConnection(new Connection().ConnectionString))
            {
                try
                {
                    connection.Open();
                    var dataTable = connection.GetSchema("Databases");
                    var dbList = new List<Database>(dataTable.Rows.Count);
                    foreach (DataRow database in dataTable.Rows)
                    {
                        try
                        {
                            var name = database.Field<String>("database_name");
                            var dbID = database.Field<short>("dbid");
                            var createdDate = database.Field<DateTime>("create_date");
                            dbList.Add(new Database() { Created = createdDate, Name = name, ID = dbID });
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                    return dbList;
                }
                catch (Exception)
                {
                    return null;
                }
            }

        }
    }
}