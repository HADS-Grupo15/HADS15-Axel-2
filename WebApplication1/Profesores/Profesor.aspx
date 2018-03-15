<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profesor.aspx.vb" Inherits="WebApplication1.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<div>
<div style="text-align:center;float:left;background-color:cornflowerblue;width:25%; height: 570px;">
    <form ID="columnaIZQ" runat="server">
     <br /><br /<br /><br /><br /><!-- AGRANDAR-->
        <asp:LinkButton ID="LinkButton1" style="font-size:35px" runat="server">Asignaturas</asp:LinkButton>
    <br /><br />
        <asp:LinkButton ID="LinkButton2"  style="font-size:35px" runat="server">Tareas</asp:LinkButton> 
    <br /><br />
     <asp:LinkButton ID="LinkButton3"  style="font-size:35px" runat="server">Grupos</asp:LinkButton>
    <br /><br />
     <asp:LinkButton ID="LinkButton4"  style="font-size:35px" runat="server">Importar v. XML Document</asp:LinkButton>
    <br /><br />
     <asp:LinkButton ID="LinkButton5"  style="font-size:35px" runat="server">Exportar</asp:LinkButton>
    <br /><br />
    <asp:LinkButton ID="LinkButton6"  style="font-size:35px" runat="server">Importar v. Dataset</asp:LinkButton>
    <br /><br />
    </form>
</div>
<div style="text-align:center;float:right;background-color:Highlight;width:75%; height: 570px;">
    <br /><br /><br /><br /><br /><br />
    <h1>Gestión Web de Tareas-Dedicación</h1>
    <br /><br />
    <h1>Profesores</h1>
</div>
</div>
</body>
</html>
