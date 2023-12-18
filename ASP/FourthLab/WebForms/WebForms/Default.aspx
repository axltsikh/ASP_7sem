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
                <asp:Label ID="Label1" runat="server">A1 string</asp:Label>
                <asp:TextBox runat="server" ID="firstString"/>
                <asp:Label ID="Label2" runat="server">A1 int</asp:Label>
                <asp:TextBox runat="server" ID="firstInt"/>
                <asp:Label ID="Label3" runat="server">A1 float</asp:Label>
                <asp:TextBox runat="server" ID="firstFloat"/>
            </div>
            <div style="margin-left:50px">
                <asp:Label ID="Label4" runat="server">A2 string</asp:Label>
                <asp:TextBox runat="server" ID="secondString"/>
                <asp:Label ID="Label5" runat="server">A2 int</asp:Label>
                <asp:TextBox runat="server" ID="secondInt"/>
                <asp:Label ID="Label6" runat="server">A2 float</asp:Label>
                <asp:TextBox runat="server" ID="secondFloat"/>
            </div>
        </div>
    <div style="margin-left:160px; margin-top:50px">
        <asp:button runat="server" Text="Sum opertaion" ID="SumButton" OnClick="SumButton_Click"></asp:button>
        <asp:Label ID="sumOutput" runat="server"></asp:Label>
    </div>
        <br />
        <div style="display: flex; flex-direction:row; width: 150px">
            <div>
                <asp:Label runat="server">X</asp:Label>
                <asp:TextBox runat="server" ID="addX"/>
            </div>
            <div style="margin-left:50px">
                <asp:Label runat="server">Y</asp:Label>
                <asp:TextBox runat="server" ID="addY"/>
            </div>
        </div>
    <div style="margin-left:160px; margin-top:50px">
        <asp:button runat="server" Text="Add opertaion" ID="addButton" OnClick="AddButton_Click"></asp:button>
        <asp:Label ID="addOutput" runat="server"></asp:Label>
    </div>
        <br />
        <div style="display: flex; flex-direction:row; width: 150px">
            <div>
                <asp:Label runat="server">S</asp:Label>
                <asp:TextBox runat="server" ID="concatS"/>
            </div>
            <div style="margin-left:50px">
                <asp:Label runat="server">D</asp:Label>
                <asp:TextBox runat="server" ID="concatD"/>
            </div>
        </div>
    <div style="margin-left:160px; margin-top:50px">
        <asp:button runat="server" Text="Concat opertaion" ID="concatButton" OnClick="ConcatButton_Click"></asp:button>
        <asp:Label ID="concatOutput" runat="server"></asp:Label>
    </div>
    </form>

</body>
</html>