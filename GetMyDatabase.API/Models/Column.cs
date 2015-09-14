using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GetMyDatabase.API.Models
{
    public class Column
    {
        public String Name { get; set; }

        public List<Column> GetAll(string db, string table)
        {
            using (var connection = new SqlConnection(new Connection().ConnectionString))
            {
                try
                {
                    connection.Open();
                    var dataTable = connection.GetSchema("Columns");
                    var dbList = new List<Column>(dataTable.Rows.Count);
                    foreach (DataRow database in dataTable.Rows)
                    {
                        try
                        {
                            var name = database.Field<String>("database_name");
                            var dbID = database.Field<short>("dbid");
                            var createdDate = database.Field<DateTime>("create_date");
                            dbList.Add(new Column()
                            //{ Created = createdDate, Name = name, ID = dbID }
                            );
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

            return null;
        }
    }
}