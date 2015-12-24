using System;
using System.Collections.Generic;
using System.Web;

namespace WebSite
{
    public class PageBase : System.Web.UI.Page
    {
        /// <summary>
        /// 如果当前用户没有登录，则跳转到登陆页
        /// </summary>
        /// <param name="pageGuid"></param>
        public void UserAuthentication()
        {
            if (Session["currentSUser_ID"] == null)
            {
                if (!this.Page.ClientScript.IsStartupScriptRegistered("LogonJavascript"))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "LogonJavascript", @"window.location='/Login.aspx';", true);
                }
            }
            else
            { }
        }

    }

    /// <summary>
    /// Operate Status（Add or Edit）
    /// </summary>
    public enum Status
    {
        Add,
        Edit
    }
}
