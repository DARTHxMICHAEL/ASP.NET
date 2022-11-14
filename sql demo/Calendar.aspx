<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Calendar.aspx.cs" Inherits="Calendar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <%-- akapit ze spacją --%>
    <p> 
        <br /> <br /> <br />
    </p>
    
                <table class="nav-justified">
                    <tr>
                        <td style="height: 220px; width: 140px;"></td>
                        <td style="height: 220px; width: 201px">
    
                <asp:Calendar ID="Calendar1" runat="server" BackColor="#BFCADE" BorderColor="White" BorderWidth="0px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" Width="486px" CssClass="rounded-corners">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" CssClass="rounded-corners"/>
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" CssClass="rounded-corners"/>
                    <OtherMonthDayStyle ForeColor="#999999" CssClass="rounded-corners"/>
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" CssClass="rounded-corners"/>
                    <TitleStyle BackColor="#506C8C" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="12pt" ForeColor="#BFCADE" CssClass="rounded-corners"/>
                    <TodayDayStyle BackColor="#9198e5" CssClass="rounded-corners"/>
                </asp:Calendar>

                            </td>
                        <td style="height: 220px; width: 55px">
    
                            &nbsp;</td>
                        <td style="height: 220px; width: 130px;"> 
                            
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="220px" Width="489px" CssClass="rounded-corners" >
                                <AlternatingRowStyle BackColor="#BFCADE" ForeColor="#284775" CssClass="rounded-corners" />
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                                    <asp:BoundField DataField="EventDate" HeaderText="EventDate" SortExpression="EventDate" />
                                    <asp:BoundField DataField="EventDesc" HeaderText="EventDesc" SortExpression="EventDesc" />
                                    <asp:BoundField DataField="Organizer" HeaderText="Organizer" SortExpression="Organizer" />
                                </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="#BFCADE" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#9198e5" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                        <td style="height: 220px"> 
                            
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 140px">&nbsp;</td>
                        <td style="width: 201px">&nbsp;</td>
                        <td style="width: 55px">&nbsp;</td>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 20px; width: 140px;"></td>
                        <td style="height: 20px; width: 201px"> </td>
                        <td style="height: 20px; width: 55px">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [TableTwo]"></asp:SqlDataSource>
                        </td>
                        <td style="height: 20px" colspan="2"> </td> 
                    </tr>
                    <tr>
                        <td style="height: 20px; width: 140px;"></td>
                        <td style="width: 201px;"> <span style="font-weight: bold"> </span></td>
                        <td style="width: 55px; height: 20px;">
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Imie] FROM [TableOne]"></asp:SqlDataSource>
                        </td>
                        <td style="height: 20px" colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 22px; width: 140px; color: #4d4d4d;"> <strong> Data </strong></td>
                        <td style="height: 22px; width: 201px">
                            <asp:TextBox ID="TextBox1" runat="server" Width="135px" BackColor="#BFCADE" BorderStyle="Solid" BorderWidth="1px" style="border-radius: 4px;">MM/DD/YYYY</asp:TextBox>
                        </td>
                        <td style="height: 22px; width: 55px">&nbsp;</td>
                        <td colspan="2" rowspan="2">
                            </td>
                    </tr>
                    <tr>
                        <td style="height: 22px; width: 140px; color: #4d4d4d;"> <strong>Nazwa</strong></td>
                        <td style="width: 201px; height: 22px">
                            <asp:TextBox ID="TextBox2" runat="server" Width="135px" BackColor="#BFCADE" BorderStyle="Solid" BorderWidth="1px" style="border-radius: 4px;"></asp:TextBox>
                        </td>
                        <td style="width: 55px; height: 22px"></td>
                    </tr>
                    <tr>
                        <td style="height: 22px; width: 140px; color: #4d4d4d;"><strong>Organizator&nbsp;</strong> </td>
                        <td style="width: 201px; height: 20px;">
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Imie" DataValueField="Imie" Width="150px" BackColor="#BFCADE" style="border-radius: 4px;">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 55px; height: 20px;">&nbsp; &nbsp;</td>
                        <td style="height: 20px" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px">&nbsp;</td>
                        <td style="width: 201px">&nbsp;</td>
                        <td style="width: 55px">&nbsp;</td>
                        <td colspan="2">&nbsp;</td>
                    </tr>
    </table>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Dodaj wydarzenie" Width="126px" OnClick="Button1_Click" BackColor="#BFCADE" BorderStyle="Solid" BorderWidth="1px" style="border-radius: 4px;"/>
        
        
        <asp:Button ID="Button2" runat="server" Text="Usuń wydarzenie" OnClick="Button3_Click" BackColor="#BFCADE" BorderStyle="Solid" BorderWidth="1px" style="border-radius: 4px;"/>
    </p>
    <p>
        &nbsp;</p>



    <br/><br/>
    <br/><br/>
    <br/><br/>


    </asp:Content>
