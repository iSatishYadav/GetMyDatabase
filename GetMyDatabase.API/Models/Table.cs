using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GetMyDatabase.API.Models
{
    public class Table
    {
        public String Database { get; set; }
        public String Schema { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }

        public IEnumerable<IGrouping<String, Table>> GetAll(String[] databaseNames)
        {
            using (var connection = new SqlConnection(new Connection().ConnectionString))
            {
                try
                {
                    connection.Open();
                    var dbList = new List<Table>();
                    foreach (var db in databaseNames)
                    {
                        connection.ChangeDatabase(db);
                        var dataTable = connection.GetSchema("Tables");
                        foreach (DataRow database in dataTable.Rows)
                        {
                            try
                            {
                                var databaseName = database.Field<String>("TABLE_CATALOG");
                                var schema = database.Field<String>("TABLE_SCHEMA");
                                var tableName = database.Field<String>("TABLE_NAME");
                                var tableType = database.Field<String>("TABLE_TYPE");
                                dbList.Add(new Table() { Database = databaseName, Schema = schema, Name = tableName, Type = tableType });
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                    }
                    var groupList = dbList.GroupBy(x => x.Database);
                    return groupList;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}