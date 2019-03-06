<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaintainPrograms.aspx.cs" Inherits="TSS.ProgDec.WFUI.MaintainPrograms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header rounded-top">
        <h3>Maintain Programs</h3>
    </div>

    <hr />

    <div class="form-row ml-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label1" runat="server" Text="Programs:"></asp:Label>
        </div>

        <div class="control-label col-md-3">
             <asp:DropDownList ID="ddlPrograms" runat="server" OnSelectedIndexChanged="ddlPrograms_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>

    <div class="form-row ml-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label3" runat="server" Text="Description:"></asp:Label>
        </div>

        <div class="control-label col-md-3">
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-row ml-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label6" runat="server" Text="Degree Types:"></asp:Label>
        </div>

        <div class="control-label col-md-3">
             <asp:DropDownList ID="ddlDegreeTypes" runat="server"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group mt-3 ml-5">
        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary btn-lg" Text="Delete" OnClick="btnDelete_Click" />
        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary btn-lg" Text="Update" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnInsert" runat="server" CssClass="btn btn-primary btn-lg" Text="Insert" OnClick="btnInsert_Click" />
    </div>
    
</asp:Content>
