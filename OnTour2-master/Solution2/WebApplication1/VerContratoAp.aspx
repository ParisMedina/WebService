<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerContratoAp.aspx.cs" Inherits="WebApplication1.VerContratoAp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="scripts/jquery-3.0.0.min.js"></script>
    <script src="scripts/popper.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <link href="Estilos/estiloRegistro.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
    </style>
</head>
<body style="background-image: url('images/cartagena.jpeg'); background-size: cover">
    <div runat="server">
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
                                <li class="nav-item active"></li>

                            </ul>




                        </div>
                    </nav>
                </td>
            </tr>
        </table>
        <br />

        <br />

        <br />

        <form id="form1" runat="server">
            <table align="center">

                <tr>
                    <td class="auto-style1">Nombre del Alumno</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="DdlNombreAl" runat="server" class="btn btn-primary" >
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblPrueba" runat="server" Text=""></asp:Label>
                     </td>
                    <td></td>
                    <td></td>
                </tr>
                 <tr>
                    <td>  <asp:HyperLink ID="hlAlumno" runat="server" NavigateUrl="ApoderadoTemp.aspx">Volver</asp:HyperLink></td>
                    <td>                        <asp:Button ID="VerContrato" runat="server" Text="Descargar Contrato" class="btn btn-outline-info" OnClick="VerContrato_Click"/>
                    </td>
                    <td></td>
                </tr>
            </table>
        </form>

    </div>
</body>
</html>
