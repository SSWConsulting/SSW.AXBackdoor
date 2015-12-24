<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Operate.Master"
    CodeBehind="Operate.aspx.cs" Inherits="WebSite.AX.Operate" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Edit Voucher
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="operate" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" style="line-height: 30px; margin-left:60px">
        <tr>
            <td width="15%" style="font-weight: bold; text-align: right">
                Voucher:
            </td>
            <td align="left" style=" padding-left:10px">
                <asp:Label ID="lblVOUCHER" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold; text-align: right">
                Date:
            </td>
            <td align="left" style=" padding-left:10px">
                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold; text-align: right">
                Category:
            </td>
            <td align="left" style=" padding-left:10px">
                <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold; text-align: right">
                Description:
            </td>
            <td align="left" style=" padding-left:10px">
                <asp:TextBox ID="txtTXT" runat="server" Width="300px"></asp:TextBox>
                <span style="color: Red">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="txtTXT"
                    Display="Dynamic" ErrorMessage="Can not be empty!"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                    ControlToValidate="txtTXT" Display="Dynamic" ErrorMessage="60 charactors at most!"
                    ValidationExpression="^[\s\S]{0,60}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-left: 10%; padding-top: 10px; text-align: left">
                <asp:Button ID="btnbtnSave" runat="server" Text="Save" CssClass="bt2" OnClick="btnSave_Click"
                    OnClientClick="return confirm('Are you sure?')" />
                &nbsp;<input id="hrbtnReset" type="reset" value="Reset" class="bt2" />&nbsp;
                <input id="hbtnBack" type="button" value="Back" onclick='javascript:window.location = "List.aspx"'
                    class="bt2" />
            </td>
        </tr>
    </table>
</asp:Content>
