<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReservationsByDate.aspx.cs" Inherits="SamplePages_ReservationsByDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<h1> Special Events Reservations by Date (Repeater)</h1>
    <table align="center" style="width: 70%">
        <tr>
            <td align="right">Enter Reservation Date (mm/dd/yyyy):</td>
            <td>
                <asp:TextBox ID="ReservationDateArg" runat="server"
                     ToolTip="Format mm/dd/yyyy" Text="01/01/1900"></asp:TextBox>
                &nbsp;<asp:LinkButton ID="FetchReservatons" runat="server">Fetch Reservations</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
           
        </tr>
        <tr>
            <td colspan="2">
                <div class="row col-md-12">
                    <asp:Repeater ID="EventReservationList" runat="server"
                             DataSourceID="ODSReservationsByDate">
                        <ItemTemplate>
                            <h3> <%# Eval("Description") %></h3>
                            <asp:Repeater ID="ReservationList" runat="server"
                                DataSource ='<%#Eval("Reservations") %>' >
                                <ItemTemplate>
                                    <h4>
                                        <%# Eval("CustomerName") %>
                                        <%# Eval("contactPhone") %>
                                    </h4>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </td>
           
        </tr>
    </table>
    <asp:ObjectDataSource ID="ODSReservationsByDate" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationsByDate" TypeName="eRestaurantSystem.BLL.AdminController">
        <SelectParameters>
            <asp:ControlParameter ControlID="ReservationDateArg" Name="reservationdate" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

