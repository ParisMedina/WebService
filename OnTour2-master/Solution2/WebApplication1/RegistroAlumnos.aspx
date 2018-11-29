<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroAlumnos.aspx.cs" Inherits="WebApplication1.RegistroAlumnos" %>

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
            height: 229px;
        }

        .auto-style2 {
            height: 62px;
        }
    </style>
</head>
<body style="background-image: url('images/lisboa.jpg'); background-size:cover">
    
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
                    
                        <a class="nav-link text-white" href="ApoderadoTemp.aspx">Atras </a>

                </div>
            </nav>
            <br />
            <br />
    <form id="form1" runat="server">
        <div>
            <div>
            <table class="auto-style1" align="center">
                <tr>
                    <td>
                        Registrar Alumno
                    </td>
                </tr>
                <tr>
                    <td>Nombre</td>
                    <td>
                        <asp:TextBox ID="tbxNombre" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="* Campo Obligatorio" ControlToValidate="tbxNombre" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvNombre" runat="server" ErrorMessage="* Ingrese nombre valido" ControlToValidate="tbxNombre" Display="Dynamic" ForeColor="Red" Type="String" Operator="DataTypeCheck"></asp:CompareValidator>

                    </td>
                </tr>
                <tr>
                    <td>Apellido Paterno</td>
                    <td>
                        <asp:TextBox ID="tbxApellidoP" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvApellidoP" runat="server" ErrorMessage="* Campo Obligatorio" ControlToValidate="tbxApellidoP" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvApellidoP" runat="server" ErrorMessage="* Ingrese un Apellido valido" ControlToValidate="tbxApellidoP" Display="Dynamic" ForeColor="Red" Type="String" Operator="DataTypeCheck"></asp:CompareValidator>

                    </td>
                </tr>
                <tr>
                    <td>Apellido Materno</td>
                    <td>
                        <asp:TextBox ID="tbxApellidoM" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:CompareValidator ID="cvApellidoM" runat="server" ErrorMessage="* Ingrese un Apellido valido" ControlToValidate="tbxApellidoM" Display="Dynamic" ForeColor="Red" Type="String" Operator="DataTypeCheck"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>RUT</td>
                    <td>
                        <asp:TextBox ID="tbxRut" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="* Campo Obligatorio" ControlToValidate="tbxRut" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Fecha Nacimiento</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="tbxFecha" runat="server" placeholder="DD/MM/AAAA" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ErrorMessage="* Campo Obligatorio" ControlToValidate="tbxFecha" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Colegio</td>
                    <td>
                        <asp:DropDownList ID="DdlColegio" runat="server" class="btn btn-primary" AutoPostBack="True" OnSelectedIndexChanged="DdlColegio_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>



                </tr>
                <tr>
                    <td>Curso</td>
                    <td>
                        <asp:DropDownList ID="ddlCursos" runat="server" class="btn btn-primary" AutoPostBack="True"></asp:DropDownList></td>
                    <td></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" Width="128px" OnClick="btnRegistrar_Click"  class="btn btn-success" /></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:HyperLink ID="hlAlumno" runat="server" NavigateUrl="ApoderadoTemp.aspx">Volver</asp:HyperLink></td>
                    <td>
                        <asp:Label ID="Estado" runat="server" Text=""></asp:Label></td>
                </tr>


            </table>
            </div>
        </div>
    </form>
</body>
</html>
