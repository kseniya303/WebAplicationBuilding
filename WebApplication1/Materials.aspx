<%@ Page Title="Materials" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materials.aspx.cs" Inherits="WebApplication1.Materials" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %>.
    </h2>
    <h3> Materials </h3>
    <asp:ListView ID="MaterialList" 
        runat="server" 
        DataKeyNames="Id"
        OnItemDataBound="MaterialList_ItemDataBound"
         
        OnItemEditing="MaterialList_ItemEditing"
        OnItemCanceling="MaterialList_ItemCanceling"
        OnItemDeleting="MaterialList_ItemDeleting"
        OnDataBound="MaterialList_DataBound"
        OnItemUpdating="MaterialList_ItemUpdating">

        <LayoutTemplate>
            <table cellpadding="2" runat="server" id="tblMaterials" width="640px" cellspacing="0" class="table table-striped">
            <tr runat="server" id="itemTitle">
                <th>Id</th>
                <th>Имя</th>
                <th>Дата</th>
                <th>UnitId</th>
                <th>Количество</th>
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
                    <asp:Calendar ID="Date" runat="server" />
                </td>
                  <td>
                    <asp:DropDownList ID="UnitIdDdl" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="NumMaterial" runat="server" />
                </td> 
                <td>
                    <asp:LinkButton ID="SaveBtn" runat="server" Text="Добавить" OnClick="SaveBtn_Click" CssClass="btn btn-primary" />
                </td>
                     
            </tr>
        </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr runat="server">
                <td>
                    <asp:Label ID="IDLbl" runat="server" Text='<%#Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="DateLabel" runat="server" Text='<%#Eval("Date") %>' />
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("UnitId") %>' />
                </td>
                <td>
                    <asp:Label ID="NumMaterial" runat="server" Text='<%#Eval("Num") %>' />
                </td>
                 <td>
                    <asp:LinkButton ID="EditBtn" runat="server" CommandName="Edit" Width="80" Height="40" Text="Редактировать" />
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
                    <asp:Calendar ID="EditDate" runat="server" ForeColor="green" BackColor="lightyellow"/>
                </td>
               <td>
                    <asp:DropDownList ID="UnitIdDdl" Width="80" Height="40" runat="server" AutoPostBack="true"/>
                </td>
                  <td>
                    <asp:TextBox ID="NumMaterial" runat="server" Text='<%#Eval("Num") %>' />
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

  <asp:Panel runat="server" ID="NewPnl"></asp:Panel>
</asp:Content>
