<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LRPopup.aspx.cs" Inherits="S8__client.LRPopup" %>

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
                    <asp:Label ID="Label1" runat="server" Text="Penalty"></asp:Label>
                </td>  
                <td>  
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="239px"></asp:DropDownList>
                </td>  
            </tr>   
            <tr>  
                <td>  
                    <asp:Label ID="Label3" runat="server" Text="C"></asp:Label>
                </td>  
                <td>  
                    <asp:TextBox ID="TextBox1" runat="server" Width="232px"></asp:TextBox>
                </td>  
            </tr>  
            <tr>  
                <td>  
                    <asp:Label ID="Label4" runat="server" Text="Solver"></asp:Label>
                </td>  
                <td>  
                    <asp:DropDownList ID="DropDownList4" runat="server" Width="239px"></asp:DropDownList>    
                </td>  
            </tr>  
    </table>  

    </form>
</body>
</html>
