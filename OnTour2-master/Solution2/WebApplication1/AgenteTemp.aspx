<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgenteTemp.aspx.cs" Inherits="WebApplication1.AgenteTemp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #Text1 {
            width: 155px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    BIENVENIDO AGENTE

    </div>
        <p>
            identificacion de poliza:
            <asp:TextBox ID="txtIdentificacion" runat="server"></asp:TextBox>
            <asp:Button ID="BtnPoliza" runat="server" Height="20px" OnClick="BtnPoliza_Click" Text="consultar Poliza" Width="98px" />
        </p>
    </form>
</body>
</html>
