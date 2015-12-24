using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Drawing;

namespace WebSite.AX
{
    public partial class List : PageBase
    {
        #region Fields

        BLL.Voucher _bll = new BLL.Voucher();
        public bool ddd = false;

        #endregion Fields

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserAuthentication();

            if (!IsPostBack)
            {
                BindGVData("TRANSDATE DESC");
            }
        }

        #region Properties

        public LedgerCategory CurrentLedgerCategory
        {
            get
            {
                if (this.ddlCategory.SelectedValue == "1")
                {
                    return LedgerCategory.PurchaseLedger;
                }
                else if (this.ddlCategory.SelectedValue == "2")
                {
                    return LedgerCategory.SalesLedger;
                }
                if (this.ddlCategory.SelectedValue == "3")
                {
                    return LedgerCategory.GeneralLedger;
                }
                if (this.ddlCategory.SelectedValue == "4")
                {
                    return LedgerCategory.Fapiao;
                }
                else
                {
                    return LedgerCategory.Null;
                }
            }
        }

        public string Category
        {
            get
            {
                return this.ddlCategory.SelectedValue;
            }
        }
        #endregion Properties

        #region Events

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGVData("TRANSDATE DESC");
        }

        #endregion Events

        #region Methods

        void BindGVData(string order)
        {
            int totalRowCount = 0;

            DataSet ds = new DataSet();
            if (CurrentLedgerCategory == LedgerCategory.Null)
            {
                return;
            }

            ds = _bll.GetGVList((int)CurrentLedgerCategory, GetWhere(), order, ref totalRowCount);

            if (CurrentLedgerCategory == LedgerCategory.GeneralLedger)
            {
                this.gvVoucher.Visible = false;
                this.gvVoucherG.Visible = true;

                this.gvVoucherG.DataSource = ds;
                this.gvVoucherG.DataBind();
            }
            else
            {
                this.gvVoucherG.Visible = false;
                this.gvVoucher.Visible = true;

                this.gvVoucher.DataSource = ds;
                this.gvVoucher.DataBind();
            }


        }

        string GetWhere()
        {
            StringBuilder where = new StringBuilder();
            if (string.IsNullOrEmpty(this.txtVoucher.Text.Trim()))
            {
                return "1=2";
            }
            else
            {
                where.AppendFormat(" VOUCHER='{0}'", this.txtVoucher.Text.Trim().Replace("'", "''"));
            }

            return where.ToString();
        }


        #endregion Methods

    }

    public enum LedgerCategory
    {
        PurchaseLedger = 1,
        SalesLedger = 2,
        GeneralLedger = 3,
        Fapiao = 4,

        Null = 0
    }
}
