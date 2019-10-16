<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="PhoneBookApp.MainPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="BootStrap/CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="BootStrap/js/bootstrap.min.js"></script>
    <script src="jquery-3.4.1.min.js"></script>
    <title>Phone Book App</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <h3 style="text-align: center;">Phone Book</h3>
        <div runat="server" class="container-fluid">
            <div class="alert alert-success" runat="server" id="successMsg">
                <strong>Success!</strong> Record is Added / Updated Successfully.
            </div>
            <div class="alert alert-danger" runat="server" id="failureMsg">
                Please Add the Mandatory Fields.
            </div>
            <h4>Fill Phone Book Details</h4>
            <table class="table" runat="server" style="width: 70%;">
                <tr>
                    <td>
                        <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        <span id="Span1" runat="server" style="color: red;">*</span>
                    </td>

                    <td>
                        <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        <span id="Span2" runat="server" style="color: red;">*</span>
                    </td>

                    <td>
                        <asp:Label ID="lblPhoneNo" runat="server" Text="Phone Number"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtPhoneNo" ValidationGroup="grp" TextMode="Phone" runat="server"></asp:TextBox>
                        <span id="Span3" runat="server" style="color: red;">*</span>
                        <asp:RegularExpressionValidator ID="phoneNoRegEx" runat="server"
                            ErrorMessage="Enter a valid Phone Number" ForeColor="Red" ValidationGroup="grp"
                            ValidationExpression="^\d{3}[-]?\d{3}[-]?\d{4}$"
                            ControlToValidate="txtPhoneNo" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtEmail" ValidationGroup="grp" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="emailRegEx" runat="server"
                            ErrorMessage="Enter a valid email address" ForeColor="Red" ValidationGroup="grp"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtEmail" />
                    </td>
                    <td>
                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                    <td>
                        <asp:Button class="btn btn-primary btn-sm" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button class="btn btn-danger btn-sm" ValidationGroup="ungrp" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
                </tr>
            </table>
        </div>

        <div class="container-fluid">
            <table style="width:80%">
                <tr>
                    <td>
                        <h4>List of Phone Book Details</h4>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearch" AutoPostBack="true" OnTextChanged="btnSearch_Click" CssClass="form-control my-0 py-1 amber-border" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-sm" Text="Search" OnClick="btnSearch_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnRefresh" runat="server" CssClass="btn btn-primary btn-sm" Text="Refresh" OnClick="btnRefresh_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView CssClass="container-fluid" Width="98%" ID="phoneBookGrid" runat="server" AutoGenerateColumns="False" CellPadding="6" OnRowCancelingEdit="phoneBookGrid_RowCancelingEdit"
                OnRowEditing="phoneBookGrid_RowEditing" PagerSettings-Mode="NextPrevious" AllowSorting="true" OnRowDeleting="phoneBookGrid_RowDeleting" OnRowUpdating="phoneBookGrid_RowUpdating" PageSize="5" AllowPaging="true" OnPageIndexChanging="phoneBookGrid_PageIndexChanging">
                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btn_Edit" class="btn btn-primary btn-sm" runat="server" Text="Edit" CommandName="Edit" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btn_Update" class="btn btn-primary btn-sm" runat="server" Text="Update" CommandName="Update" />
                            <asp:Button ID="btn_Cancel" class="btn btn-primary btn-sm" runat="server" Text="Cancel" CommandName="Cancel" />
                            <asp:Button ID="btn_Delete" class="btn btn-danger btn-sm" runat="server" Text="Delete" CommandName="Delete" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("PhoneBookId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MiddleName">
                        <ItemTemplate>
                            <asp:Label ID="lblMiddleName" runat="server" Text='<%#Eval("MiddleName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMiddleName" runat="server" Text='<%#Eval("MiddleName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LastName">
                        <ItemTemplate>
                            <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%#Eval("Email") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone Number">
                        <ItemTemplate>
                            <asp:Label ID="lblPhoneNo" runat="server" Text='<%#Eval("PhoneNo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPhoneNo" runat="server" Text='<%#Eval("PhoneNo") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAddress" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#99ccff" ForeColor="Black" />
                <RowStyle BackColor="White" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
