<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WaiterBillingReport.aspx.cs" Inherits="Reports_WaiterBillingReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <rsweb:ReportViewer ID="WaiterBillingViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="700px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="Reports\WaiterBilling.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ODSWaiterBilling" Name="WaiterBillingDS" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ODSWaiterBilling" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWaiterBillingReport" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
</asp:Content>

