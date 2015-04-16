using System.Collections;
using System.Data;

namespace Utils
{
    public class DataTableUtil
    {
        public static object[] GetDistinctValues(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();

            foreach (DataRow drow in dTable.Rows)
            {
                try
                {
                    hTable.Add(drow[colName].ToString(), string.Empty);
                }
                catch { }
            }

            object[] objArray = new object[hTable.Keys.Count];
            hTable.Keys.CopyTo(objArray, 0);

            return objArray;
        }
    }
}
