<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="S8_Client.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-12">
                <center>
                    <h3>Predictions history</h3>
                    <br />
                    <br />
                </center>
            </div>
        </div>
    </div>
    <asp:GridView class="table table-striped table-bordered" ID="GridViewHistory" runat="server"></asp:GridView>
</asp:Content>
