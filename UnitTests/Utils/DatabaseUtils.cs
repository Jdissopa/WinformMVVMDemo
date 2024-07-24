using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Utils
{
    public static class DatabaseUtils
    {
        public static DataTable ToDataTable(IEnumerable<dynamic> items)
        {
            var dataTable = new DataTable();

            if (items == null || !items.Any())
                return dataTable;

            // Add columns to the DataTable
            foreach (string property in ((IDictionary<string, object>)items.First()).Keys)
            {
                dataTable.Columns.Add(property);
            }

            // Add rows to the DataTable
            foreach (var item in items)
            {
                var row = dataTable.NewRow();
                foreach (var property in ((IDictionary<string, object>)item).Keys)
                {
                    row[property] = ((IDictionary<string, object>)item)[property];
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
