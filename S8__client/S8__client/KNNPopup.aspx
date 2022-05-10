<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KNNPopup.aspx.cs" Inherits="S8__client.KNNPopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>  
            <tr>  
                <td>  
                    <asp:Label ID="Label1" runat="server" Text="Algorithm"></asp:Label>
                </td>  
                <td>  
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="239px"></asp:DropDownList>
                </td>  
            </tr>  
            <tr>  
                <td>  
                    <asp:Label ID="Label2" runat="server" Text="Metric"></asp:Label>
                </td>  
                <td>  
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="239px"></asp:DropDownList>
                </td>  
            </tr>  
            <tr>  
                <td>  
                    <asp:Label ID="Label3" runat="server" Text="N_neighbors"></asp:Label>
                </td>  
                <td>  
                    <asp:TextBox ID="TextBox1" runat="server" Width="232px"></asp:TextBox>
                </td>  
            </tr>  
            <tr>  
                <td>  
                    <asp:Label ID="Label4" runat="server" Text="Weights"></asp:Label>
                </td>  
                <td>  
                    <asp:DropDownList ID="DropDownList4" runat="server" Width="239px"></asp:DropDownList>    
                </td>  
            </tr>  
    </table>  

    </form>
</body>
</html>
