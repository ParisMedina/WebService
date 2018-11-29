<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrate.aspx.cs" Inherits="WebApplication1.Registrate" %>

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

        .auto-style2 {
            width: 236px;
        }

        .auto-style3 {
            height: 27px;
            width: 237px;
        }

        .auto-style4 {
            width: 237px;
        }

        .auto-style5 {
            height: 26px;
        }

        .auto-style6 {
            width: 237px;
            height: 26px;
        }
    </style>

</head>
<body style="background-image: url('images/banner.jpg'); background-size: cover">

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

                        <a class="nav-link text-white" href="Login.aspx">LogIn </a>

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
                <td class="auto-style4">Registo de Cuenta</td>
            </tr>


            <tr>

                <td class="auto-style4">Tipo de usuario</td>
                <td>
                    <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipoUsuario_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="Seleccione">Seleccione </asp:ListItem>
                        <asp:ListItem Value="2" Text="Encargado"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Apoderado"></asp:ListItem>
                    </asp:DropDownList></td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvTipoUsuario" runat="server" ErrorMessage="* Debe seleccionar un Tipo de usuario" ControlToValidate="ddlTipoUsuario" ForeColor="Red" InitialValue="Seleccione"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style4">Nombre</td>
                <td>
                    <asp:TextBox ID="tbxNombre" runat="server" CssClass="form-control"></asp:TextBox></td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="* Campo Obligatorio" ControlToValidate="tbxNombre" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvNombre" runat="server" ErrorMessage="* Ingrese nombre valido" ControlToValidate="tbxNombre" Display="Dynamic" ForeColor="Red" Type="String" Operator="DataTypeCheck"></asp:CompareValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style4">Apellido Paterno</td>
                <td>
                    <asp:TextBox ID="tbxApellidoP" runat="server" CssClass="form-control"></asp:TextBox></td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvApellidoP" runat="server" ErrorMessage="* Campo Obligatorio" ControlToValidate="tbxApellidoP" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvApellidoP" runat="server" ErrorMessage="* Ingrese un Apellido valido" ControlToValidate="tbxApellidoP" Display="Dynamic" ForeColor="Red" Type="String" Operator="DataTypeCheck"></asp:CompareValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style3">Apellido Materno</td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbxApellidoM" runat="server" CssClass="form-control"></asp:TextBox></td>
                <td class="auto-style1">
                    <asp:CompareValidator ID="cvApellidoM" runat="server" ErrorMessage="* Ingrese un Apellido valido" ControlToValidate="tbxApellidoM" Display="Dynamic" ForeColor="Red" Type="String" Operator="DataTypeCheck"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Nombre Usuario</td>
                <td>
                    <asp:TextBox ID="tbxUsername" runat="server" CssClass="form-control"></asp:TextBox></td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="* Campo Obligatorio" ControlToValidate="tbxUsername" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Contraseña</td>
                <td>
                    <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox></td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="* Campo Obligatorio" ControlToValidate="tbxPassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Correo</td>
                <td>
                    <asp:TextBox ID="tbxEmail" runat="server" CssClass="form-control"></asp:TextBox></td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="* Campo Obligatorio" ControlToValidate="tbxEmail" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="* Ingrese un correo valido" ControlToValidate="tbxEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style4">Celular</td>
                <td>
                    <asp:TextBox ID="tbxCelular" runat="server" CssClass="form-control"></asp:TextBox></td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvCelular" runat="server" ErrorMessage="* Campo Obligatorio" ControlToValidate="tbxCelular" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Telefono Fijo</td>
                <td>
                    <asp:TextBox ID="tbxTelefono" runat="server" CssClass="form-control"></asp:TextBox>

                </td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ErrorMessage="* Campo Obligatorio" ControlToValidate="tbxTelefono" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblColegio" runat="server" Text="Colegio" Enabled="False" Visible="False"></asp:Label></td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlColegio" runat="server" class="btn btn-primary" Enabled="False" Visible="False" AutoPostBack="True" DataTextField="NOMBRE_COLEGIO" DataValueField="NOMBRE_COLEGIO" OnSelectedIndexChanged="ddlColegio_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="Seleccione">Seleccione </asp:ListItem>
                    </asp:DropDownList></td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvColegio" runat="server" ErrorMessage="* Debe seleccionar un Colegio" ControlToValidate="ddlColegio" ForeColor="Red" InitialValue="Seleccione" Enabled="False" Visible="False"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style6">
                    <asp:Label ID="Pregunta1" runat="server" Text="¿Tu colegio aparece en la lista?" Enabled="False" Visible="False"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="auto-style4"></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Enabled="False" Visible="False">
                        <asp:ListItem Selected="True" Text="Si"></asp:ListItem>
                        <asp:ListItem Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvListaColegio" runat="server" ErrorMessage="*Seleccione una opcion" ForeColor="Red" ControlToValidate="RadioButtonList1" Enabled="False" Visible="False"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblNombreColegio" runat="server" Text="Nombre Colegio" Enabled="False" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxNombreColegio" runat="server" CssClass="form-control"  Enabled="False" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvNombreColegio" runat="server" ErrorMessage="*Campo Obligatorio" ForeColor="Red" ControlToValidate="tbxNombreColegio"  Enabled="False" Visible="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDireccion" runat="server" Text="Direccion"  Enabled="False" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxDireccion" runat="server" CssClass="form-control"  Enabled="False" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ErrorMessage="*Campo Obligatorio" ForeColor="Red" ControlToValidate="tbxDireccion"  Enabled="False" Visible="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTelefonoColegio" runat="server" Text="Telefono"  Enabled="False" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxTelefonoColegio" runat="server" CssClass="form-control"  Enabled="False" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvFonoColegio" runat="server" ErrorMessage="*Campo Obligatorio" ForeColor="Red" ControlToValidate="tbxTelefonoColegio"  Enabled="False" Visible="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnGuardarColegio" runat="server" Text="Registrar Colegio" class="btn btn-secondary" OnClick="btnGuardarColegio_Click"  Enabled="False" Visible="False" />
                </td>
                <td>
                    <asp:Label ID="lblMensajeC" runat="server" Text=""  Enabled="False" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblCurso" runat="server" Text="Curso" Enabled="False" Visible="False"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlCurso" runat="server" class="btn btn-primary" Enabled="False" Visible="False" DataTextField="NOMBRE_CURSO" DataValueField="NOMBRE_CURSO">
                        <asp:ListItem Selected="True" Value="Seleccione">Seleccione </asp:ListItem>
                    </asp:DropDownList></td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="rfvCurso" runat="server" ErrorMessage="* Debe seleccionar un Curso" ControlToValidate="ddlCurso" ForeColor="Red" InitialValue="Seleccione" Enabled="False" Visible="False"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="Pregunta2" runat="server" Text="¿Tu curso aparece en la lista?" Enabled="False" Visible="False"></asp:Label>
                </td>
                <td></td>

            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server"  RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" Enabled="False" Visible="False">
                        <asp:ListItem Selected="True" Text="Si"></asp:ListItem>
                        <asp:ListItem Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvListaCurso" runat="server" ControlToValidate="RadioButtonList2" ErrorMessage="*Seleccione una opcion" ForeColor="Red" Enabled="False" Visible="False"></asp:RequiredFieldValidator >
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblNombreCurso" runat="server" Text="Nombre Curso"  Enabled="False" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbxNombreCurso" runat="server" CssClass="form-control"  Enabled="False" Visible="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvNombreCurso" runat="server" ErrorMessage="*Campo Obligatorio" ForeColor="Red" ControlToValidate="tbxNombreCurso"  Enabled="False" Visible="False"></asp:RequiredFieldValidator>
                </td>

            </tr>
           
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnGuardarCurso" runat="server" Text="Registrar Curso"  class="btn btn-secondary" OnClick="btnGuardarCurso_Click"   Enabled="False" Visible="False"/>
                </td>
                <td>
                    <asp:Label ID="lblMensajeCu" runat="server" Text=""  Enabled="False" Visible="False"></asp:Label>
                </td>

            </tr>

            <tr>
                <td class="auto-style4">

                    <asp:HyperLink ID="hlLogin" runat="server" NavigateUrl="Inicio.aspx">Volver</asp:HyperLink>
                </td>
                <td>
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" Width="128px" OnClick="btnRegistrar_Click" class="btn btn-success" />

                </td>
                <td class="auto-style1">

                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </td>
            </tr>


        </table>




    </form>
</body>
</html>
