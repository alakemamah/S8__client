<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Prediction.aspx.cs" Inherits="S8__client.WebForm4" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">  
    </asp:ScriptManager>  
    <div class="container-fluid">
       <div class="row">
           <div class="col-md-4 ">
                   <h5>Choose your data</h5>
                   <asp:DropDownList ID="DropDownList1" runat="server" Width="239px">
                   </asp:DropDownList>
           </div>

            <div class="col-md-4 ml-auto">
                    <h5>Choose your models</h5>
                    <div class="form-check">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <label class="form-check-label" for="flexCheckDefault">
                            Analytical Method
                        </label>
                    </div>

                    <div class="form-check">
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                        <label class="form-check-label" for="flexCheckDefault">
                            Logistic Regression
                        </label>
                    </div>

                    <div class="form-check">
                        <asp:CheckBox ID="CheckBox3" runat="server" />
                        <label class="form-check-label" for="flexCheckDefault">
                            KNN
                        </label>
                    </div>
                    <div class="form-check">
                        <asp:CheckBox ID="CheckBox4" runat="server" />
                        <label class="form-check-label" for="flexCheckDefault">
                            Random Forest
                        </label>
                    </div>
           </div>
       </div>
       <br />
       <br />
       <div class="row">
           <div class="col-12">
               <center>
                    <asp:Button class="btn btn-danger btn-block" style="background-color: #a30c0c" ID="Button2" runat="server" Text="Predict" />
               </center>
           </div>
       </div>
   </div>
    
        <%--Pop up for KNN --%>
        <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="CheckBox3"  
            CancelControlID="Button3" BackgroundCssClass="Background">  
        </ajaxToolkit:ModalPopupExtender>  
        <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">  
            <iframe style=" width: 350px; height: 300px;" id="irm1" src="KNNPopup.aspx" runat="server"></iframe>  
           <br/>  
            <asp:Button ID="Button3" runat="server" Text="Close" />  
            <asp:Button ID="Button5" runat="server" Text="submit" />
        </asp:Panel>
        <ajaxToolkit:Accordion ID="Accordion1" runat="server"></ajaxToolkit:Accordion>
     
    <%--Pop up for Logistic regression --%>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1" TargetControlID="CheckBox2"  
            CancelControlID="Button1" BackgroundCssClass="Background">  
        </ajaxToolkit:ModalPopupExtender>  
        <asp:Panel ID="Panel1" runat="server" CssClass="Popup" align="center" style = "display:none">  
            <iframe style=" width: 350px; height: 300px;" id="Iframe1" src="LRPopup.aspx" runat="server"></iframe>  
           <br/>  
            <asp:Button ID="Button1" runat="server" Text="Close" /> 
            <asp:Button ID="Button6" runat="server" Text="submit" />
        </asp:Panel>
        <ajaxToolkit:Accordion ID="Accordion2" runat="server"></ajaxToolkit:Accordion>

    <%--Pop up for Random forest --%>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel2" TargetControlID="CheckBox4"  
            CancelControlID="Button4" BackgroundCssClass="Background">  
        </ajaxToolkit:ModalPopupExtender>  
        <asp:Panel ID="Panel2" runat="server" CssClass="Popup" align="center" style = "display:none">  
            <iframe style=" width: 350px; height: 300px;" id="Iframe2" src="RFPopup.aspx" runat="server"></iframe>  
           <br/>  
            <asp:Button ID="Button4" runat="server" Text="Close" />
            <asp:Button ID="Button7" runat="server" Text="submit" />
        </asp:Panel>
        <ajaxToolkit:Accordion ID="Accordion3" runat="server"></ajaxToolkit:Accordion>
</asp:Content>
