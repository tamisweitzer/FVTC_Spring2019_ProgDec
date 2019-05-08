<%@ Page Title="Maintain Program Declaration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaintainProgDec.aspx.cs" Inherits="TSS.ProgDec.WFUI.MaintainProgDec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="header rounded-top">
        <h3>Maintain Program Declaration</h3>
    </div>

    <p></p>

    <div class="form-row ml-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label1" runat="server" Text="Programs:"></asp:Label>
        </div>

        <div class="control-label col-md-3">
            <asp:DropDownList ID="ddlPrograms" runat="server"></asp:DropDownList>
        </div>
    </div>

    <div class="form-row ml-2 m-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label3" runat="server" Text="Student:"></asp:Label>
        </div>

        <div class="control-label col-md-3">
            <asp:DropDownList ID="ddlStudents" runat="server"></asp:DropDownList>
        </div>
    </div>

    

    <div class="form-group mt-2 ml-5">
        <asp:Button ID="btnInsert" runat="server" Text="Insert" CssClass="btn btn-primary btn-lg" OnClick="btnInsert_Click" />
    </div>
</asp:Content>
