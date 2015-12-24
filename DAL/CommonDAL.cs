using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Model;

namespace DAL
{
    public class CommonDAL
    {
        public CommonDAL()
        {

        }

        /// <summary>
        /// 取记录集
        /// </summary>
        /// <param name="strTable">表名</param>
        /// <returns></returns>
        public DataSet GetListSql(string strSql)
        {
            return DbHelperSQL.Query(strSql);
        }

        /// <summary>
        /// 取记录集
        /// </summary>
        /// <param name="strTable">表名</param>
        /// <returns></returns>
        public DataSet GetList(string strTable)
        {
            return this.GetList(new CommonModel(strTable));
        }

        /// <summary>
        /// 取记录集
        /// </summary>
        /// <param name="strTable">表名</param>
        /// <param name="strWhere">where条件</param>
        /// <returns></returns>
        public DataSet GetList(string strTable, string strWhere)
        {
            return this.GetList(new CommonModel(strTable, strWhere));
        }

        /// <summary>
        /// 取记录集
        /// </summary>
        /// <param name="strFields">字段</param>
        /// <param name="strTable">表名</param>
        /// <param name="strWhere">where条件</param>
        /// <returns></returns>
        public DataSet GetList(string strFields, string strTable, string strWhere)
        {
            return this.GetList(new CommonModel(strFields, strTable, strWhere));
        }

        /// <summary>
        /// 取记录集
        /// </summary>
        /// <param name="strFields">字段</param>
        /// <param name="strTable">表名</param>
        /// <param name="strWhere">where条件</param>
        /// <returns></returns>
        public DataSet GetList(string strFields, string strTable, string strWhere, string strOrder)
        {
            return this.GetList(new CommonModel(strFields, strTable, strWhere, strOrder));
        }

        /// <summary>
        /// 取记录列表（不返回记录数）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet GetList(CommonModel model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@select_list", SqlDbType.VarChar, 1000),
                    new SqlParameter("@table_name",SqlDbType.VarChar,1000),
                    new SqlParameter("@where", SqlDbType.VarChar,1000),
					new SqlParameter("@primary_key", SqlDbType.VarChar,100),
                	new SqlParameter("@order_by", SqlDbType.VarChar,100),
					new SqlParameter("@page_size", SqlDbType.Int),
					new SqlParameter("@page_index", SqlDbType.Int),
					new SqlParameter("@bl_page", SqlDbType.Int),
					};
            parameters[0].Value = model.Fields;
            parameters[1].Value = model.Tables;
            parameters[2].Value = model.Where;
            parameters[3].Value = model.PrimaryKey;
            parameters[4].Value = model.OrderByFields;
            parameters[5].Value = model.PageSize;
            parameters[6].Value = model.PageIndex;
            parameters[7].Value = model.IsPage;
            return DbHelperSQL.RunProcedureAdditional("Common_PageList", parameters);
        }

        /// <summary>
        ///  取记录列表（返回记录数）
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public DataSet GetList(CommonModel model, ref int rowCount)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@select_list", SqlDbType.VarChar, 1000),
                    new SqlParameter("@table_name",SqlDbType.VarChar,1000),
                    new SqlParameter("@where", SqlDbType.VarChar,1000),
					new SqlParameter("@primary_key", SqlDbType.VarChar,100),
                	new SqlParameter("@order_by", SqlDbType.VarChar,100),
					new SqlParameter("@page_size", SqlDbType.Int),
					new SqlParameter("@page_index", SqlDbType.Int),
					new SqlParameter("@bl_page", SqlDbType.Int),
	                new SqlParameter("@return_Value", SqlDbType.Int),	
					};
            parameters[0].Value = model.Fields;
            parameters[1].Value = model.Tables;
            parameters[2].Value = model.Where;
            parameters[3].Value = model.PrimaryKey;
            parameters[4].Value = model.OrderByFields;
            parameters[5].Value = model.PageSize;
            parameters[6].Value = model.PageIndex;
            parameters[7].Value = model.IsPage;
            parameters[8].Direction = ParameterDirection.ReturnValue;
            return DbHelperSQL.RunProcedureAdditional("Common_PageList", parameters, ref rowCount);
        }


        /// <summary>
        /// 取单个值
        /// </summary>
        /// <param name="filed"></param>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public Object GetSingle(string filed, string table, string where)
        {
            string strSQL = string.Format("select {0} from {1} where {2}", filed, table, where);
            return DbHelperSQL.GetSingle(strSQL);

        }


        /// <summary>
        /// 更新数据表某个值
        /// </summary>
        /// <param name="filed"></param>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int UpdateSingle(string filed, string table, string where)
        {
            string strSQL = string.Format("Update {0} Set {1} Where {2}", table, filed, where);
            return DbHelperSQL.ExecuteSql(strSQL);

        }
    }
}
