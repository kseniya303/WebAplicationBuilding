<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %>.
    </h2>
    <h3>ListView Users </h3>
    <asp:ListView ID="UserList"
        runat="server"
        DataKeyNames="Id"
        OnItemEditing="UserList_ItemEditing"
        OnItemCanceling="UserList_ItemCanceling"
        OnItemDeleting="UserList_ItemDeleting"
        OnItemDataBound="UserList_ItemDataBound"
        OnDataBound="UserList_DataBound"
        OnItemUpdating="UserList_ItemUpdating">

        <LayoutTemplate>
            <table cellpadding="2" runat="server" id="tblUsers" width="640px" cellspacing="0" class="table table-striped">
                <tr runat="server" id="itemTitle">
                    <th>Id</th>
                    <th>Имя</th>
                    <th>Роль</th>
                    <th>Уволен?</th>
                    <th></th>
                </tr>

                <tr runat="server" id="itemPlaceholder" />
                <tr runat="server">
                    <td>
                        <asp:Label Text="New:" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTxt" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="RoleIdDdl" runat="server" />
                    </td>
                    <td></td>
                    <td>
                        <asp:LinkButton ID="SaveBtn" runat="server" Text="Нанять" OnClick="SaveBtn_Click" CssClass="btn btn-success" />
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <EmptyDataTemplate>
            <table cellpadding="2" runat="server" id="tblUsers" width="640px" cellspacing="0" class="table table-striped">
                <tr runat="server" id="itemTitle">
                    <th>Id</th>
                    <th>Имя</th>
                    <th>Роль</th>
                    <th>Уволен?</th>
                    <th></th>
                </tr>
                <tr runat="server">
                    <td>
                        <asp:Label Text="New:" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTxt" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="RoleIdDdl" runat="server" />
                    </td>
                    <td></td>
                    <td>
                        <asp:LinkButton ID="SaveBtn" runat="server" Text="Нанять" OnClick="SaveBtn_Click" CssClass="btn btn-success" />
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr runat="server">
                <td>
                    <asp:Label ID="IDLbl" runat="server" Text='<%#Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="RoleLabel" runat="server" Text='<%#Eval("RoleId") %>' />
                </td>
                <td>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%#Eval("IsDeleted") %>' />
                </td>
                <td>
                    <asp:LinkButton ID="EditBtn" runat="server" CommandName="Edit" Width="80" Height="40" Text="Редактировать" />
                </td>
                <td>
                    <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="Delete" Text="Уволить" Width="80" Height="40" CssClass="btn btn-danger" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr runat="server">
                <td>
                    <asp:Label ID="IDLbl" runat="server" Text='<%#Eval("Id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="EditNameTxt" runat="server" Text='<%#Bind("Name") %>' />
                </td>
                <td>
                    <asp:DropDownList ID="RoleIdDdl" Width="80" Height="40" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RoleIdDdl_SelectedIndexChanged"/>
                </td>
                <td>
                    <asp:LinkButton ID="Cancel" runat="server" CommandName="Cancel" Text="Отмена" />

                </td>
                <td>
                    <asp:LinkButton ID="LinkButtonSave" runat="server" CommandName="Update" Text="Сохранить" />

                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
    <br>
    <h4>Repeater </h4>

    <p>
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <td><b>Id</b></td>
                        <td><b>Name</b></td>
                        <td><b>Role</b></td>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Id") %>' runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="RatingLabel" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "RoleId") %>' runat="server" />
                    </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        GridView
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
    <asp:Panel runat="server" ID="NewPnl"></asp:Panel>
</asp:Content>
