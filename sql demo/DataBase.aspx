<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="DataBase.aspx.cs" Inherits="DataBase" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td style="height: 20px; width: 362px;"></td>
                <td style="height: 20px; width: 510px;"></td>
                <td style="height: 20px; width: 375px;"></td>
                <td style="height: 20px; width: 800px;"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 362px; height: 22px; background-color:#BFCADE; opacity: 0.8;">ID użytkownika</td>
                <td style="width: 510px; height: 22px;">
                    <asp:TextBox ID="TextBox1" runat="server" Width="161px" BackColor="#BFCADE"></asp:TextBox>
                </td>
                <td style="width: 375px; height: 22px;">Filtrowanie po ID</td>
                <td style="width: 800px; height: 22px;"></td>
                <td style="height: 22px"></td>
            </tr>
            <tr>
                <td style="height: 22px; width: 362px; background-color: #cdd5e5; opacity: 0.8;">Imie</td>
                <td style="width: 510px; height: 22px;">
                    <asp:TextBox ID="TextBox2" runat="server" Width="161px" BackColor="#BFCADE"></asp:TextBox>
                </td>
                <td style="width: 375px; height: 22px;">
                    <asp:TextBox ID="TextBox4" runat="server" Width="149px" BackColor="#BFCADE"></asp:TextBox>
                </td>
                <td style="width: 800px; height: 22px">
                </td>
                <td style="height: 22px"></td>
            </tr>
            <tr>
                <td style="width: 362px; background-color:#BFCADE; opacity: 0.8;">Wiek</td>
                <td style="width: 510px">
                    <asp:TextBox ID="TextBox3" runat="server" Width="161px" BackColor="#BFCADE"></asp:TextBox>
                </td>
                <td style="width: 375px">&nbsp;</td>
                <td style="width: 800px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 362px; background-color: #cdd5e5; opacity: 0.8;">E-mail</td>
                <td style="width: 510px">
                    <asp:TextBox ID="TextBox5" runat="server" Width="161px" BackColor="#BFCADE"></asp:TextBox>
                </td>
                <td style="width: 375px">
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Filtruj" Width="111px" style="background-color:#BFCADE" BorderStyle="Solid" BorderWidth="1px"/>
                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Usuń filtry" Width="107px" style="background-color:#BFCADE" BorderStyle="Solid" BorderWidth="1px"/>
                </td>
                <td style="width: 800px">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 362px; height: 20px;"></td>
                <td style="width: 510px; height: 20px;"></td>
                <td style="width: 375px; height: 20px;"></td>
                <td style="width: 800px; height: 20px;"></td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 362px">&nbsp;</td>
                <td style="width: 510px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Dodaj użytkownika" Width="154px" style="background-color:#BFCADE" BorderStyle="Solid" BorderWidth="1px"/>
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Aktualizuj" Width="112px" style="background-color:#BFCADE" BorderStyle="Solid" BorderWidth="1px" />
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Usuń użytkownika" Width="133px" style="background-color:#BFCADE" BorderStyle="Solid" BorderWidth="1px" />
                </td>
                <td style="width: 375px">&nbsp;</td>
                <td style="width: 800px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 20px; width: 362px;"></td>
                <td style="height: 20px; width: 510px;"></td>
                <td style="height: 20px; width: 375px;"></td>
                <td style="height: 20px; width: 800px;"></td>
                <td style="height: 20px"></td>

            </tr>
        </table>


        <br />
        <table class="nav-justified">
            <tr>
                <td style="height: 23px; width: 404px;">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TableOne]"></asp:SqlDataSource>
                </td>
                <td style="height: 23px"></td>
                <td style="height: 23px"></td>
                <td style="height: 23px"></td>
                <td style="height: 23px"></td>
            </tr>
            <tr>
                <td style="width: 404px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="404px">
                        <AlternatingRowStyle BackColor="#BFCADE" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"/>
                            <asp:BoundField DataField="Imie" HeaderText="Imie" SortExpression="Imie" />
                            <asp:BoundField DataField="Wiek" HeaderText="Wiek" SortExpression="Wiek" />
                            <asp:BoundField DataField="E-mail" HeaderText="E-mail" SortExpression="E-mail" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="#c2addb" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#ccffcc" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 404px; text-align: right">* baza nie zawiera prawdziwych informacji</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 404px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />

    </p>


    <br/><br/>
    <br/><br/>




    </asp:Content>