<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="scripts/jquery-3.0.0.min.js"></script>
    <script src="scripts/popper.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <link href="Estilos/estiloRegistro.css" rel="stylesheet" />

</head>
<body style="background-image: url('images/london.jpg'); background-size:cover">
 
        <div>
            <table>
                <tr>
                    <td class="auto-style2">
                        <nav class="navbar navbar-expand-md navbar-dark bg-dark fixed-top">
                            <a class="navbar-brand" href="Inicio.aspx">OnTour - Viajes de Estudio</a>
                            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
                                <span class="navbar-toggler-icon"></span>
                            </button>

                            <div class="collapse navbar-collapse" id="navbarsExampleDefault">
                                <ul class="navbar-nav mr-auto">
                                    <li class="nav-item active">
                                        <a class="nav-link" href="DestinosPreferidos.aspx">Destinos Preferidos <span class="sr-only">(current)</span></a>
                                    </li>

                                </ul>
                               
                            </div>
                        </nav>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
       <form id="form1" runat="server">
            <table align="center">

                <tr>
                    <td>Iniciar Sesion</td>

                </tr>


                <tr>
                    <td>Usuario:</td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server" Width="156px" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" Width="156px" CssClass="form-control" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" Width="86px" OnClick="btnIngresar_Click" class="btn btn-success" /></td>
                </tr>
                <tr>
                    
                    <td>
                        <asp:HyperLink ID="hlLogin" runat="server" NavigateUrl="Inicio.aspx">Volver</asp:HyperLink></td>
                </tr>

               <tr>
                    <td>
                <asp:Label ID="Estado" runat="server" Text=""></asp:Label></td>

                </tr>


            </table>
        </div>
    </form>
</body>
</html>
