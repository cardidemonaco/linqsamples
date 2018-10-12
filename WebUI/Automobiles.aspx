<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Automobiles.aspx.cs" Inherits="WebUI.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Make:
        <asp:DropDownList ID="ddlMake" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Model:
        <asp:DropDownList ID="ddlModel" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:GridView ID="gvAutomobiles" runat="server">
        </asp:GridView>
    </p>
</asp:Content>
