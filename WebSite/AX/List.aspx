<%@ Page Title="AX" Language="C#" MasterPageFile="~/MasterPages/List.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="WebSite.AX.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title" runat="server">
    Vouchers
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="search" runat="server">
    <table style="width: 67%; margin-left: 60px" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="7%" style="text-align: right; font-weight: bold;">
                Type:
            </td>
            <td width="35%" align="left" style="padding-left: 10px">
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="select1">
                    <asp:ListItem Text="Purchase ledger" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Sales ledger" Value="2"></asp:ListItem>
                    <asp:ListItem Text="General ledger" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Fapiao" Value="4"></asp:ListItem>

                </asp:DropDownList>
            </td>
            <td width="7%" style="text-align: right; font-weight: bold;">
                Vouche:
            </td>
            <td width="35%" style="padding-left: 10px">
                <asp:TextBox ID="txtVoucher" runat="server" Width="98%" MaxLength="100"></asp:TextBox>
            </td>
            <td align="center">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                    CssClass="bt2" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="operation" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="gridView" runat="server">
    <div style="width: 70%; margin-left: 60px">
        <asp:GridView ID="gvVoucher" runat="server" AllowSorting="True" DataKeyNames="VOUCHER"
            Width="70%" BorderWidth="1">
            <Columns>
                <asp:BoundField DataField="VOUCHER" HeaderText="Voucher" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="TRANSDATE" HeaderText="Date" />
                <asp:BoundField DataField="TXT" HeaderText="Description" />
                <asp:BoundField DataField="LASTSETTLECOMPANY" HeaderText="Company accounts" />
                <asp:BoundField DataField="LASTSETTLEACCOUNTNUM" HeaderText="Account" />
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <a href="Operate.aspx?v=<%#Eval("VOUCHER")+"&c="+ Category %>">Edit</a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" ForeColor="Blue" CssClass="GridViewTemplateField" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvVoucherG" runat="server" AllowSorting="True" DataKeyNames="VOUCHER"
            Width="70%" BorderWidth="1">
            <Columns>
                <asp:BoundField DataField="VOUCHER" HeaderText="Voucher" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="TRANSDATE" HeaderText="Date" />
                <asp:BoundField DataField="TXT" HeaderText="Description" />
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <a href="Operate.aspx?v=<%#Eval("VOUCHER")+"&c="+ Category %>">Edit</a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" ForeColor="Blue" CssClass="GridViewTemplateField" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="pager" runat="server">
</asp:Content>
