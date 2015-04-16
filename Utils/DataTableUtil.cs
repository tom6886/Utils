using System.Collections;
using System.Data;

namespace Utils
{
    public class DataTableUtil
    {
        /// <summary>
        /// 汤波
        /// 2015-4-16 17:06:07
        /// 从 DataTable 获取一列并去重
        /// </summary>
        /// <param name="dTable">DataTable</param>
        /// <param name="colName">列名</param>
        /// <returns></returns>
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
