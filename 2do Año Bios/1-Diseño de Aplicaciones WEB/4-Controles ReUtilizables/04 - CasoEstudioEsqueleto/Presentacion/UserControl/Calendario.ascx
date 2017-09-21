<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calendario.ascx.cs" Inherits="UserControl_Calendario" %>
<asp:Button ID="AnioAtras" runat="server" Text=" &lt; Año" OnClick="AnioAtras_Click" /> 
&nbsp;<asp:LinkButton ID="lbtnEnero" runat="server">1</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lbtnFebrero" runat="server">2</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lbtnMarzo" runat="server">3</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lbtnAbril" runat="server">4</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lbtnMayo" runat="server">5</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lbtnJunio" runat="server">6</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lbtnJulio" runat="server">7</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lbtnAgosto" runat="server">8</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lbtnSetiembre" runat="server">9</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lbtnOctube" runat="server">10</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lbtnNoviembre" runat="server">11</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lbtnDiciembre" runat="server">12</asp:LinkButton>
&nbsp;
<asp:Button ID="AnioAdelante" runat="server" Text="Año &gt;" OnClick="AnioAdelante_Click" /> 

<asp:Calendar ID="cFecha" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
    <DayStyle BackColor="#CCCCCC" />
    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
    <OtherMonthDayStyle ForeColor="#999999" />
    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
    <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
    <TodayDayStyle BackColor="#999999" ForeColor="White" />
</asp:Calendar>
 
