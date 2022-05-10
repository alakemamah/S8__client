<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RFPopup.aspx.cs" Inherits="S8_Client.LRPopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>  
                <td>  
                    <asp:Label ID="Label3" runat="server" Text="N_estimators"></asp:Label>
                </td>  
                <td>  
                    <asp:TextBox ID="TextBox1" runat="server" Width="232px"></asp:TextBox>
                </td>  
            </tr>  
            <tr>  
                <td>  
                    <asp:Label ID="Label4" runat="server" Text="Max depth"></asp:Label>
                </td>  
                <td>  
                    <asp:TextBox ID="TextBox2" runat="server" Width="232px"></asp:TextBox>
                </td>  
            </tr>  
    </table>  

    </form>
</body>
</html>
