<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Listview.aspx.cs" Inherits="SamplePages_Listview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Listview Query Display</h1>
    <table align="center" style="width: 70%">
        <tr>
            <td align="right">Special Event Code:&nbsp;</td>
            <td>
                <asp:DropDownList ID="SpecialEventList" runat="server" AppendDataBoundItems="True" DataSourceID="ODSSpecialEvents" DataTextField="Description" DataValueField="EventCode">
                    <asp:ListItem Value="z">Select an event</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;

  

                <asp:LinkButton ID="FetchReservations" runat="server">Fetch Reservations</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>           


            <td colspan="2">
                <asp:ListView ID="ReservationList" runat="server" DataSourceID="ODSReservations">
                    <AlternatingItemTemplate>
                        <tr style="background-color:#FFF8DC;">
                           

                            <td>
                                <asp:Label ID="CustomerNameLabel" runat="server" Text='<%# Eval("CustomerName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ReservationDateLabel" runat="server" Text='<%# Eval("ReservationDate", "{0:MMM dd, yyyy h:mm tt}") %>' />
                            </td>

                            <td align="right">

                                <asp:Label ID="NumberInPartyLabel" runat="server" Text='<%# Eval("NumberInParty") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ContactPhoneLabel" runat="server" Text='<%# Eval("ContactPhone") %>' />
                            </td>

                            <td align="center">
                                <asp:Label ID="ReservatonStatusLabel" runat="server" Text='<%# Eval("ReservationStatus") %>' />
                            </td>
                         
                        </tr>
                    </AlternatingItemTemplate>


                    <EmptyDataTemplate>
                        <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                            <tr>
                                <td>No data was returned.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>


                    <ItemTemplate>
                        <tr style="background-color:#DCDCDC;color: #000000;">
                           
                            <td>
                                <asp:Label ID="CustomerNameLabel" runat="server" Text='<%# Eval("CustomerName") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ReservationDateLabel" runat="server" Text='<%# Eval("ReservationDate", "{0:MMM dd, yyyy h:mm tt}") %>' />
                            </td>
                            <td align="right">
                                <asp:Label ID="NumberInPartyLabel" runat="server" Text='<%# Eval("NumberInParty") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ContactPhoneLabel" runat="server" Text='<%# Eval("ContactPhone") %>' />
                            </td>
                            <td align="center">
                                <asp:Label ID="ReservatonStatusLabel" runat="server" Text='<%# Eval("ReservationStatus") %>' />

                            </td>
                           
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                        <tr runat="server" style="background-color:#DCDCDC;color: #000000;">

                                           
                                            <th runat="server">Name</th>
                                            <th runat="server">Date</th>
                                            <th runat="server">Size</th>
                                            <th runat="server">Phone</th>
                                            <th runat="server">Status</th>

                                         
                                           
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">

                                    
                                          

                                   

                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                    <asp:DataPager ID="DataPager1" runat="server">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                            <asp:NumericPagerField />
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>

                </asp:ListView>
            </td>
        </tr>
    </table>

    <br />

    <asp:ObjectDataSource ID="ODSSpecialEvents" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SpecialEvents_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODSReservations" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationsByEventCode" TypeName="eRestaurantSystem.BLL.AdminController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SpecialEventList" Name="eventcode" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>

