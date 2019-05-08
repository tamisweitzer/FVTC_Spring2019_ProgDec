<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TSS.ProgDec.WFUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ProgDec</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
         <div class="form-row ml-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label1" runat="server" Text="Programs:"></asp:Label>
        </div>
        <div class="control-label col-md-3">
            <asp:DropDownList ID="ddlPrograms" runat="server">
            </asp:DropDownList>
        </div>
    </div>

    <div class="form-row ml-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label5" runat="server" Text="Students:"></asp:Label>
        </div>
        <div class="control-label col-md-3">
            <asp:DropDownList ID="ddlStudents" runat="server">
            </asp:DropDownList>
        </div>
    </div>

    <div class="form-group mt-3 ml-5">
        <asp:Button ID="btnInsert" runat="server" CssClass="btn btn-primary btn-lg ml-3" Text="Insert" OnClick="btnInsert_Click" />
    </div>
    </div>

</asp:Content>
