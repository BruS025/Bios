﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Materia.aspx.cs" Inherits="_2bSolAdoNew.Materia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <link href="styles/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header clearfix">
                <nav>
                  <ul class="nav nav-pills pull-right">
                    <li role="presentation">
                        <asp:HyperLink ID="lnkDefault" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
                    </li>
                    <li role="presentation"  class="active">
                        <asp:HyperLink ID="lnkMaterias" runat="server" NavigateUrl="~/Materia.aspx">Materias</asp:HyperLink>
                    </li>
                    <li role="presentation">
                        <asp:HyperLink ID="lnkAlumnos" runat="server" NavigateUrl="~/Alumnos.aspx">Alumnos</asp:HyperLink>
                    </li>
                  </ul>
                </nav>
                <h3 class="text-muted">Academia 2b! <i class="glyphicon glyphicon-thumbs-up"></i></h3>
            </div>
            <div class="container">
                <div class="row marketing">
                    <div class="col-lg-12">
                        <h1>Materias</h1>
                    </div>
                </div>
                <div class="row marketing">
                    <div class="col-lg-12">
                        <asp:Label ID="lblResultado" runat="server" CssClass="label label-info" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row marketing">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label for="txtNumero">Número</label>
                            <div class="row">
                                <div class="col-lg-5">
                                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-7">
                                    <asp:Button ID="btnBuscarConectado" runat="server" 
                                        CssClass="btn btn-sm btn-success" Text="Buscar Materia (Conectado)" 
                                        onclick="btnBuscarConectado_Click" />
                                    <asp:Button ID="btnBuscarDesconectado" runat="server" 
                                        CssClass="btn btn-sm btn-info" Text="Buscar Materia (Desconectado)" 
                                        onclick="btnBuscarDesconectado_Click" />
                                </div>
                            </div>
                            
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label for="txtNombre">Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label for="txtCargaHoraria">Carga horaria</label>
                            <asp:TextBox ID="txtCargaHoraria" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group">
                            <asp:Button ID="btnAgregarConSQL" runat="server" 
                                CssClass="btn btn-sm btn-success" Text="Agregar (Conectado SQL)" 
                                onclick="btnAgregarConSQL_Click" />
                            <asp:Button ID="btnAgregarConSP" runat="server" 
                                CssClass="btn btn-sm btn-success" Text="Agregar (Conectado SP)" 
                                onclick="btnAgregarConSP_Click" />
                            <asp:Button ID="btnModificarCon" runat="server" CssClass="btn btn-sm btn-info" 
                                Text="Modificar (Conectado sin SP)" onclick="btnModificarCon_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="jumbotron">
                <div class="row">
                    <asp:ListBox ID="lstMaterias" runat="server"></asp:ListBox>
                </div>
                <div class="row">
                    <asp:Button ID="btnListarMateriasCon" runat="server" 
                        CssClass="btn btn-sm btn-info" Text="Listar Materias (Conectado)" 
                        onclick="btnListarMateriasCon_Click" />
                </div>
                <div class="row">
                    <asp:GridView ID="grdMaterias" runat="server"></asp:GridView>
                </div>
                <div class="row">
                    <asp:Button ID="btnListarMateriasDesc" runat="server" 
                        CssClass="btn btn-sm btn-info" Text="Listar Materias (Desconectado)" 
                        onclick="btnListarMateriasDesc_Click" />
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.1.1.min.js" integrity="sha256-hVVnYaiADRTO2PzUGmuLJr8BLUSjGIZsDYGmIJLv2b8=" crossorigin="anonymous"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
</body>
</html>
