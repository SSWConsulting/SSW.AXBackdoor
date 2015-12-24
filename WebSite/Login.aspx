<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebSite.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="text-align: center;">
    <form id="form1" runat="server" style="width: 950px; text-align: center;">
    <div class="Login">
        <ul style="margin: 40px; padding: 0">
            <li style="padding-bottom: 15px">Username：
                <asp:TextBox ID="txtLoginID" runat="server" CssClass="LoginBottom" MaxLength="50"></asp:TextBox>
            </li>
            <li style="padding-bottom: 15px">&nbsp;Password：
                <asp:TextBox ID="txtPwd" runat="server" CssClass="LoginBottom" TextMode="Password"></asp:TextBox>
            </li>
            <li>
                &nbsp;<asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" CssClass="bt2"
                    Height="22" Style="cursor: pointer;" />
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
