<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArmarContrato.aspx.cs" Inherits="WebApplication1.ArmarContrato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Arma tu Viaje - OnTour</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="scripts/jquery-3.0.0.min.js"></script>
    <script src="scripts/popper.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <link href="Estilos/estiloRegistro.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 317px;
        }

        .auto-style2 {
            height: 25px;
        }
        .auto-style3 {
            height: 25px;
            width: 317px;
        }
    </style>
</head>
<body style="background-image: url('images/opatija.jpg'); background-size: cover">
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
        &nbsp;<div>
            <table align="center">
                <tr>
                    <td>Arma tu viaje de ensueño</td>
                    <td class="auto-style1"></td>
                    <td>
                        <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Escoge tu Colegio</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="DdlColegio" runat="server" class="btn btn-primary dropdown-toggle">
                             <asp:ListItem Selected="True" Value="Seleccione">Seleccione </asp:ListItem>

                        </asp:DropDownList></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDdlColegio" runat="server" ErrorMessage="*Elige una opcion correcta" ForeColor="Red" ControlToValidate="DdlColegio"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>Destino</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="DdlDestino" runat="server" class="btn btn-primary dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="DdlDestino_SelectedIndexChanged">
                         <asp:ListItem Selected="True" Value="Seleccione">Seleccione </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDestino" runat="server" ErrorMessage="*Elige una opcion correcta" ForeColor="Red" ControlToValidate="DdlDestino"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Tour </td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="DdlTour" runat="server" class="btn btn-primary dropdown-toggle" OnSelectedIndexChanged="DdlTour_SelectedIndexChanged"  AutoPostBack="True">
                         <asp:ListItem Selected="True" Value="Seleccione">Seleccione </asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="tbxPrecioTour" runat="server" Width="111px" Enabled="false" CssClass="form-control" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvTour" runat="server" ErrorMessage="*Elige una opcion" ForeColor="Red" ControlToValidate="DdlTour"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Seguro</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="DdlSeguro" runat="server" class="btn btn-primary dropdown-toggle" OnSelectedIndexChanged="DdlSeguro_SelectedIndexChanged" AutoPostBack="True">
                         <asp:ListItem Selected="True" Value="Seleccione">Seleccione </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSeguro" runat="server" ErrorMessage="*Elige una opcion" ForeColor="Red" ControlToValidate="DdlSeguro"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Info Seguro</td>
                    <td class="auto-style1">
                        <asp:Label ID="lblInfoSeguro" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>Fecha del Viaje</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="tbxFechaViaje" runat="server" CssClass="form-control" placeholder="DD/MM/AAAA"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvFechaViaje" runat="server" ErrorMessage="*Dato Obligatorio" ForeColor="Red" ControlToValidate="tbxFechaViaje"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>SubTotal</td>
                    <td class="auto-style1">
                        <asp:Label ID="lblSubTotal" runat="server" Text=""></asp:Label>
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style3"></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td>Servicio Adicional</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="DdlServicio" runat="server" class="btn btn-primary dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="DdlServicio_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style1"></td>
                    <td></td>
                </tr>
                <tr>
                    <td>Total</td>
                    <td class="auto-style1">
                        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEstado" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style1"></td>

                    <td>
                        <asp:Button ID="btnRegistrarContrato" runat="server" Text="Registrar Contrato" class="btn btn-success" OnClick="btnRegistrarContrato_Click" /></td>

                </tr>
            </table>
        </div>
    </form>
</body>
</html>
