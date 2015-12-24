using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CommonModel
    {
        private string _fields;
        private string _values;
        private string _tables;
        private string _where;
        private string _primaryKey;
        private string _orderByFields;
        private int _pageSize;
        private int _pageIndex;
        private int _isPage;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CommonModel()
            : this("*", "", "")
        {

        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strTable">表名</param>
        public CommonModel(string strTable)
            : this("*", strTable, "")
        {

        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strTable">表名</param>
        /// <param name="strWhere">where条件</param>
        public CommonModel(string strTable, string strWhere)
            : this("*", strTable, strWhere)
        {

        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strFields">字段</param>
        /// <param name="strTable">表名</param>
        /// <param name="strWhere">where条件</param>
        public CommonModel(string strFields, string strTable, string strWhere)
        {
            _fields = strFields;
            _values = "";
            _tables = strTable;
            _where = strWhere;
            _primaryKey = "";
            _orderByFields = "";
            _pageSize = 0;
            _pageIndex = 1;
            _isPage = 0;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strFields">字段</param>
        /// <param name="strTable">表名</param>
        /// <param name="strWhere">where条件</param>
        /// <param name="strOrder">排序</param>
        public CommonModel(string strFields, string strTable, string strWhere, string strOrder)
        {
            _fields = strFields;
            _values = "";
            _tables = strTable;
            _where = strWhere;
            _primaryKey = "";
            _orderByFields = strOrder;
            _pageSize = 0;
            _pageIndex = 1;
            _isPage = 0;
        }


        /// <summary>
        /// 分页构造函数
        /// </summary>
        /// <param name="pageSize">分页大小</param>
        public CommonModel(int pageSize)
        {
            _fields = "*";
            _values = "";
            _tables = "";
            _where = "";
            _primaryKey = "";
            _orderByFields = "";
            _pageSize = pageSize;
            _pageIndex = 1;
            _isPage = 1;
        }


        /// <summary>
        /// 检索的字段 ： field1,field2
        /// 添加的字段 ： field1,field2
        /// 注：多个字段之间用半角逗号分割
        /// </summary>
        public string Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }


        /// <summary>
        /// 添加的值 ：value1,value2
        /// 更新的字段和值 field1=value1,field2=value2
        /// 注：多个值之间用半角逗号分割
        /// </summary>
        public string Values
        {
            get { return _values; }
            set { _values = value; }
        }


        /// <summary>
        /// 检索的表名： table1,table2
        /// 注：多个表名之间用半角逗号分割 
        /// </summary>
        public string Tables
        {
            get { return _tables; }
            set { _tables = value; }
        }

        /// <summary>
        /// 检索的where条件 
        /// 注：不加"where"
        /// </summary>
        public string Where
        {
            get { return _where; }
            set { _where = value; }
        }

        /// <summary>
        /// 检索的主键
        /// </summary>
        public string PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }

        /// <summary>
        /// 排序字段 ：field1 desc ,field2 asc
        /// 注：多个排序以逗号分割，不加" order by "
        /// </summary>
        public string OrderByFields
        {
            get { return _orderByFields; }
            set { _orderByFields = value; }
        }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// 当前页索引
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        /// <summary>
        /// 是否分页 
        /// 注：1、分页；0、不分页
        /// </summary>
        public int IsPage
        {
            get { return _isPage; }
            set { _isPage = value; }
        }
    }
}
