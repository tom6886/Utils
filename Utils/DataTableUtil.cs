using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

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
                hTable.Add(drow[colName].ToString(), string.Empty);
            }

            object[] objArray = new object[hTable.Keys.Count];

            hTable.Keys.CopyTo(objArray, 0);

            return objArray;
        }

        /// <summary>
        /// 汤波
        /// 2017年3月8日16:44:40
        /// 将集合转化为DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IEnumerable<T> list)
        {
            List<PropertyInfo> pList = new List<PropertyInfo>();

            Type type = typeof(T);

            DataTable dt = new DataTable();

            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });

            foreach (var item in list)
            {
                DataRow row = dt.NewRow();

                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
