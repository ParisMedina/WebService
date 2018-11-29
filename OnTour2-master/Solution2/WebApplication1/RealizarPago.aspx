<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RealizarPago.aspx.cs" Inherits="WebApplication1.RealizarPago" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Realizar Pago</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="scripts/jquery-3.0.0.min.js"></script>
    <script src="scripts/popper.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <link href="Estilos/estiloRegistro.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            height: 26px;
            width: 163px;
        }
        .auto-style3 {
            width: 163px;
        }
        .auto-style4 {
            height: 26px;
            width: 125px;
        }
        .auto-style5 {
            width: 125px;
        }
    </style>
</head>
<body style="background-image: url('images/cartagena.jpeg'); background-size: cover">
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

    <form id="form1" runat="server">
        <div>
            <table align="center">
                <tr>
                    <td class="auto-style4">Realizar Pago</td>
                    <td ></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style5">Escojer Alumno</td>
                    <td>
                        <asp:DropDownList ID="DdAlumno" runat="server" class="btn btn-primary"></asp:DropDownList></td>
                    <td class="auto-style3">
                        
                    </td>
                </tr>
                   <tr>
                    <td class="auto-style5">Ingrese Monto</td>
                    <td>
                        <asp:TextBox ID="tbxMonto" runat="server" CssClass="form-control" Width="159px"></asp:TextBox></td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="rfvMonto" runat="server" ErrorMessage="*Ingrese Monto Valido" ForeColor="Red" ControlToValidate="tbxMonto"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>Descripcion</td>
                    <td>
                        <asp:TextBox ID="tbxDescripcion" runat="server" CssClass="form-control" Width="160px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="*Dato Obligatorio" ForeColor="Red" ControlToValidate="tbxDescripcion"></asp:RequiredFieldValidator>
                    </td>
                    

                </tr>
                   <tr>
                    <td class="auto-style5"></td>
                    <td>
                        <asp:Button ID="btnPagar" runat="server" Text="Confirmar Pago" class="btn btn-primary" OnClick="btnPagar_Click" />
                       </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td></td>
                    <td class="auto-style3"><a class="nav-link" href="ApoderadoTemp.aspx">Volver</a></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
