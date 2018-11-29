<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoTemp.aspx.cs" Inherits="WebApplication1.EncargadoTemp" %>

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
            height: 26px;
        }

        .auto-style2 {
            height: 27px;
        }

        .auto-style3 {
            height: 28px;
        }

        .auto-style4 {
            width: 1043px;
        }

        .auto-style5 {
            height: 26px;
            width: 1043px;
        }

        .auto-style6 {
            height: 28px;
            width: 1043px;
        }
    </style>
</head>
<body style="background-image: url('images/rovinj.jpg'); background-size: cover">

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
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">
                        <div align="right">
                        </div>
                        <asp:Label ID="txtUser" runat="server" Text="Bienvenido"></asp:Label>

                    </td>
                    <td>
                        <asp:Button ID="btnCerraSesion" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click" class="btn btn-outline-dark" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style5"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">Mis Alumnos:</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">

                        <asp:GridView ID="gvAlumnos" runat="server" HeaderStyle-BackColor="Green" HeaderStyle-CssClass="text-white" CssClass="gv1"></asp:GridView>




                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style6">
                        <asp:Label ID="lblFormulario" runat="server" Text="Formulario de Pago" Enabled="False" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style5">
                        <asp:Label ID="lblMonto" runat="server" Text="Ingrese Monto" Enabled="False" Visible="False"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style5">
                        <asp:TextBox ID="tbxMonto" runat="server" CssClass="form-control" Enabled="False" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:RequiredFieldValidator ID="rfvPago" runat="server" ErrorMessage="*Dato Obligatorio" ForeColor="Red" ControlToValidate="tbxMonto" Enabled="False" Visible="False"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion" Enabled="False" Visible="False"></asp:Label>
                        &nbsp;
               <asp:TextBox ID="tbxDescripcion" runat="server" CssClass="form-control" Enabled="False" Visible="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="*Dato Obligatorio" Enabled="False" Visible="False" ForeColor="Red" ControlToValidate="tbxDescripcion"></asp:RequiredFieldValidator>
                    </td>
                    <td></td>

                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style5">
                        <asp:Button ID="btnPagar" runat="server" Text="Confirmar Pago" class="btn btn-outline-info" OnClick="btnPagar_Click" Enabled="False" Visible="False" />
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style5"></td>
                    <td class="auto-style1"></td>
                </tr>
                   <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style5">
                        <asp:Label ID="lblContrato" runat="server" Text="Contrato" Enabled="False" Visible="False"></asp:Label>
                       </td>
                    <td class="auto-style1"></td>
                </tr>
                 <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style5">
                        <asp:GridView ID="gvContrato" runat="server" HeaderStyle-BackColor="Green" HeaderStyle-CssClass="text-white" CssClass="gv1" Enabled="False" Visible="False">
                        </asp:GridView>
                     </td>
                    <td class="auto-style1"></td>
                </tr>
                 <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style5">
                        <asp:Label ID="lblEstado" runat="server" Text=""></asp:Label>
                     </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btnArmaContrato" runat="server" Text="Arma tu Contrato" class="btn btn-outline-success" OnClick="btnArmaContrato_Click" />
                        <asp:Button ID="btnRealizarPago" runat="server" Text="Realizar Pago" class="btn btn-outline-danger" OnClick="btnRealizarPago_Click" />
                        <asp:Button ID="btnRevisarContrato" runat="server" Text="Revisar Contrato" class="btn btn-outline-info" OnClick="btnRevisarContrato_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
