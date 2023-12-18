<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms._Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASMX Service Test</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: flex; flex-direction:row; width: 150px">
            <div>
                <asp:TextBox runat="server" ID="firstString"/>
                <asp:TextBox runat="server" ID="firstInt"/>
                <asp:TextBox runat="server" ID="firstFloat"/>
            </div>
            <div style="margin-left:50px">
                <asp:TextBox runat="server" ID="secondString"/>
                <asp:TextBox runat="server" ID="secondInt"/>
                <asp:TextBox runat="server" ID="secondFloat"/>
            </div>
        </div>
    <div style="margin-left:160px; margin-top:50px">
        <asp:button runat="server" Text="Sum opertaion" ID="SumButton" OnClick="SumButton_Click"></asp:button>
        <asp:Label ID="sumOutput" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>