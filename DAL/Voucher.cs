using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using Microsoft.Dynamics.BusinessConnectorNet;

namespace DAL
{
    public class Voucher
    {
        public Voucher()
        { }

        public Model.Voucher GetModel(int category, string voucher)
        {
            Model.Voucher model = new Model.Voucher();

            int rowCount = 0;
            DataSet ds = GetGVList(category, "VOUCHER='" + voucher + "'", "", ref rowCount);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["VOUCHER"].ToString() != "")
                {
                    model.VOUCHER = ds.Tables[0].Rows[0]["VOUCHER"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TRANSDATE"].ToString() != "")
                {
                    model.TRANSDATE = DateTime.Parse(ds.Tables[0].Rows[0]["TRANSDATE"].ToString());
                }
                model.TXT = ds.Tables[0].Rows[0]["TXT"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        public int Update(int category, Model.Voucher model)
        {
            //SqlParameter[] parameters = {
            //        new SqlParameter("@category", SqlDbType.Int),
            //        new SqlParameter("@voucher", SqlDbType.NVarChar),
            //        new SqlParameter("@TXT", SqlDbType.NVarChar),
            //    };
            //parameters[0].Value = category;
            //parameters[1].Value = model.VOUCHER;
            //parameters[2].Value = model.TXT;


            //DataSet dt = DbHelperSQL.RunProcedureAdditional("ModifyPostedJournal", parameters);



            Axapta ax;
            AxaptaRecord axRecord;
            //string tableName = "CustStatisticsGroup";
            try
            {
                // Login to Microsoft Dynamics AX.
                ax = new Axapta();
                ax.Logon(null, null, null, null);
                // Update the ‘High Priority Customer’    table record.

                if (category != 1 && category != 2 && category != 3 && category != 4)
                {
                    return -1;
                }

                long CREATEDTRANSACTIONID = 0;


                ax.TTSBegin();

                if (category == 1)
                {
                    using (axRecord = ax.CreateAxaptaRecord("VENDTRANS"))
                    {

                        // Execute a query to retrieve an editable record where the StatGroupName is “High Priority Customer”.
                        axRecord.ExecuteStmt("SELECT forupdate *  FROM %1  WHERE %1.VOUCHER=='" + model.VOUCHER + "'");
                        // If the record is found then update the record.
                        if (axRecord.Found)
                        {
                            // Start a transaction that can be committed.
                            CREATEDTRANSACTIONID = long.Parse(axRecord.get_Field("CREATEDTRANSACTIONID").ToString());
                            axRecord.set_Field("TXT", model.TXT);
                            axRecord.Update();
                            // Commit the transaction.
                        }
                    }
                }
                else if (category == 2 || category == 4)
                {
                    using (axRecord = ax.CreateAxaptaRecord("CUSTTRANS"))
                    {

                        // Execute a query to retrieve an editable record where the StatGroupName is “High Priority Customer”.
                        axRecord.ExecuteStmt("SELECT forupdate *  FROM %1  WHERE %1.VOUCHER=='" + model.VOUCHER + "'");
                        // If the record is found then update the record.
                        if (axRecord.Found)
                        {
                            // Start a transaction that can be committed.
                            CREATEDTRANSACTIONID = long.Parse(axRecord.get_Field("CREATEDTRANSACTIONID").ToString());
                            axRecord.set_Field("TXT", model.TXT);
                            axRecord.Update();
                            // Commit the transaction.
                        }
                    }
                }
                else if (category == 3)
                {
                    using (axRecord = ax.CreateAxaptaRecord("GENERALJOURNALENTRY"))
                    {

                        // Execute a query to retrieve an editable record where the StatGroupName is “High Priority Customer”.
                        axRecord.ExecuteStmt("SELECT forupdate *  FROM %1  WHERE %1.SUBLEDGERVOUCHER=='" + model.VOUCHER + "'");
                        // If the record is found then update the record.
                        if (axRecord.Found)
                        {
                            // Start a transaction that can be committed.
                            CREATEDTRANSACTIONID = long.Parse(axRecord.get_Field("CREATEDTRANSACTIONID").ToString());
                            //axRecord.set_Field("TXT", model.VOUCHER);
                            //axRecord.Update();
                            // Commit the transaction.
                        }
                    }
                }

                using (axRecord = ax.CreateAxaptaRecord("GENERALJOURNALACCOUNTENTRY"))
                {

                    // Execute a query to retrieve an editable record where the StatGroupName is “High Priority Customer”.
                    axRecord.ExecuteStmt("SELECT forupdate *  FROM %1  WHERE %1.CREATEDTRANSACTIONID==" + CREATEDTRANSACTIONID);
                    // If the record is found then update the record.
                    //if (axRecord.Found)
                    //{
                    //    // Start a transaction that can be committed.
                    //    axRecord.set_Field("TEXT", model.TXT);
                    //    axRecord.Update();
                    //    // Commit the transaction.
                    //}

                    UpdateRecord(axRecord, model.TXT);
                }

                if (category != 4)
                {
                    using (axRecord = ax.CreateAxaptaRecord("LEDGERJOURNALTRANS"))
                    {

                        // Execute a query to retrieve an editable record where the StatGroupName is “High Priority Customer”.
                        axRecord.ExecuteStmt("SELECT forupdate *  FROM %1  WHERE %1.VOUCHER=='" + model.VOUCHER + "'");
                        // If the record is found then update the record.
                        if (axRecord.Found)
                        {
                            // Start a transaction that can be committed.
                            axRecord.set_Field("TXT", model.TXT);
                            axRecord.Update();
                            // Commit the transaction.
                        }
                    }

                    using (axRecord = ax.CreateAxaptaRecord("BANKACCOUNTTRANS"))
                    {

                        // Execute a query to retrieve an editable record where the StatGroupName is “High Priority Customer”.
                        axRecord.ExecuteStmt("SELECT forupdate *  FROM %1  WHERE %1.VOUCHER=='" + model.VOUCHER + "'");
                        // If the record is found then update the record.
                        if (axRecord.Found)
                        {
                            // Start a transaction that can be committed.
                            axRecord.set_Field("TXT", model.TXT);
                            axRecord.Update();
                            // Commit the transaction.
                        }
                    }
                }

                ax.TTSCommit();

            }
            catch (Exception e)
            {
                return 0;
                //Console.WriteLine("Error encountered: {0}", e.Message);
                // Take other error action as needed.
            }
            return 1;

        }

        void UpdateRecord(AxaptaRecord axRecord, string text)
        {
            if (axRecord.Found)
            {
                // Start a transaction that can be committed.
                axRecord.set_Field("TEXT", text);
                axRecord.Update();
                // Commit the transaction.
                axRecord.Next();
                if (axRecord.Found)
                {
                    UpdateRecord(axRecord, text);
                }
            }
        }

        public DataSet GetGVList(int category, string strWhere, string order, ref int totalRowCount)
        {
            string table = "";
            string fields = "";

            switch (category)
            {
                case 1:
                    table = "VENDTRANS";
                    fields = "VOUCHER,CONVERT(VARCHAR(10), TRANSDATE, 101) TRANSDATE,TXT,LASTSETTLECOMPANY,LASTSETTLEACCOUNTNUM";
                    break;
                case 2:
                case 4:
                    table = "CUSTTRANS";
                    fields = "VOUCHER,CONVERT(VARCHAR(10), TRANSDATE, 101) TRANSDATE,TXT,LASTSETTLECOMPANY,LASTSETTLEACCOUNTNUM";
                    break;
                case 3:
                    table = "BANKACCOUNTTRANS";
                    fields = "VOUCHER,CONVERT(VARCHAR(10), TRANSDATE, 101) TRANSDATE,TXT";
                    break;
                default:
                    return new DataSet();
            }

            Model.CommonModel model = new Model.CommonModel();
            model.Fields = fields;
            model.Tables = table;
            model.Where = strWhere;
            model.IsPage = 0;
            model.PrimaryKey = "VOUCHER";
            model.OrderByFields = order;
            return new CommonDAL().GetList(model, ref totalRowCount);
        }
    }
}
