using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.AX
{
    public partial class Operate : PageBase
    {
        #region Fields

        BLL.Voucher _bll = new BLL.Voucher();
        string category = "0";
        string voucher = "";

        #endregion Fields

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserAuthentication();


            category = Request.QueryString["c"] == null ? "" : Request.QueryString["c"].ToString();
            voucher = Request.QueryString["v"] == null ? "" : Request.QueryString["v"].ToString();

            if (!IsPostBack)
            {
                InitializeData();
            }
        }

        #region Properties

        public LedgerCategory CurrentLedgerCategory
        {
            get
            {
                if (category == "1")
                {
                    return LedgerCategory.PurchaseLedger;
                }
                else if (category == "2")
                {
                    return LedgerCategory.SalesLedger;
                }
                if (category == "3")
                {
                    return LedgerCategory.GeneralLedger;
                }
                if (category == "4")
                {
                    return LedgerCategory.Fapiao;
                }
                else
                {
                    return LedgerCategory.Null;
                }
            }
        }

        #endregion Properties

        #region Events

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int c = int.Parse(category);
            Model.Voucher model = _bll.GetModel(c, voucher);

            if (model != null)
            {
                model.TXT = this.txtTXT.Text.Trim();

                int result = _bll.Update(c, model);

                if (result == 1)
                {
                    Tools.Common.JavaScript.MessageBox(this.Page, "Success!");

                }
                else if (result == 0)
                {
                    Tools.Common.JavaScript.MessageBox(this.Page, "Failed!");

                }
                else if (result == -1)
                {
                    Tools.Common.JavaScript.MessageBox(this.Page, "Not existed!");

                }
            }
            else
            {
                Tools.Common.JavaScript.MessageBox(this.Page, "Not existed!");
            }

        }

        #endregion Events

        #region Methods

        void InitializeData()
        {
            int c = int.Parse(category);
            Model.Voucher model = _bll.GetModel(c, voucher);

            if (model != null)
            {
                this.txtTXT.Text = model.TXT;
                this.lblDate.Text = model.TRANSDATE.ToString("MM/dd/yyyy");
                this.lblVOUCHER.Text = model.VOUCHER;
                this.lblCategory.Text = CurrentLedgerCategory == LedgerCategory.Null ? "" : CurrentLedgerCategory.ToString();
            }
            else
            {
                Tools.Common.JavaScript.MessageBox(this.Page, "Not Exist!");
            }

        }




        #endregion Methods
    }
}
