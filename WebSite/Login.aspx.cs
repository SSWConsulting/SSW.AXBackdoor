using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class Login : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Events

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginID = this.txtLoginID.Text.Trim();
            string pwd = this.txtPwd.Text.Trim();

            if (loginID == "axadmin" && pwd == "Perfect2009!")
            {
                //Session
                Session["currentSUser_ID"] = loginID;

                Tools.Common.JavaScript.Redirect(this, "AX/List.aspx");

            }
            else //
            { }

        }

        #endregion Events
    }
}
