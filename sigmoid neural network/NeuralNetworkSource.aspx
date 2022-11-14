<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NeuralNetworkSource.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NeuralNetworkSource" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <table class="nav-justified">
        <tr>
            <td style="width: 59px">&nbsp;</td>
            <td style="width: 436px">Podgląd postępów nauki:</td>
            <td class="modal-sm" style="width: 518px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 59px; height: 20px"></td>
            <td style="height: 20px; width: 436px">
                <asp:TextBox ID="TextBox1" runat="server" Height="295px" Width="389px" BackColor="#BFCADE" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td style="height: 20px; width: 518px">Sieć neuronowa oparta na neuronach sigmoidalnych. Neurony ukryte wykorzystują funkcję unipolarną (jedna wartwa sieci ukrytej). Dwa wejściowe (+bias), trzy neurony warstwy ukrytej (+bias) i jedno wyjście. Taka struktura dobrze stymuluje naukę i znacząco ułatwia interpretacje wyników.<br />
                <br />
                Uczenie odbywa się w trybie z nauczycielem poprzez minimalizację funkcji celu. Ciągłość funkcji (różniczkowalność) umożliwia zastosowanie metody gradientowej. W celu ograniczenia ryzyka &#39;utknięcia w minimum lokalnym aktualizacja wag odbywa się z momentum (aktualizacja dyskretna). Maksymalny dopuszczalny błąd na poziomie 5%. Użytkownik ustala liczbę epok- powtórzeń treningowych w ramach których zostaną wykorzystane wszystkie przypadki uczące (8).</td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 59px; height: 20px"></td>
            <td style="height: 20px; width: 436px">Liczba powtórzeń (epok):</td>
            <td style="height: 20px; width: 518px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 59px">&nbsp;</td>
            <td style="width: 436px">
                <asp:TextBox ID="TextBox2" runat="server" Width="183px" BackColor="#BFCADE" BorderWidth="1px">3000</asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Nauka i test XOR" Width="137px" BackColor="#BFCADE" style="color:#4a83cf; padding: 0px; text-align:center; vertical-align:middle" BorderWidth="1px" OnClick="Button1_Click"/>
            </td>
            <td class="modal-sm" style="width: 518px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 59px; height: 20px"></td>
            <td style="height: 20px; width: 436px">Liczba neuronów warstwy ukrytej:</td>
            <td class="modal-sm" style="height: 20px; width: 518px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 59px; height: 20px;"></td>
            <td style="width: 436px; height: 20px;">
                <asp:TextBox ID="TextBox3" runat="server" Width="183px" BackColor="#BFCADE" BorderWidth="1px">3</asp:TextBox>
                </td>
            <td class="modal-sm" style="width: 518px; height: 20px;"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 59px">&nbsp;</td>
            <td style="width: 436px">&nbsp;</td>
            <td class="modal-sm" style="width: 518px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 59px">&nbsp;</td>
            <td style="width: 436px">&nbsp;</td>
            <td class="modal-sm" style="width: 518px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 59px">&nbsp;</td>
            <td style="width: 436px">&nbsp;</td>
            <td class="modal-sm" style="width: 518px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 59px">&nbsp;</td>
            <td style="width: 436px">&nbsp;</td>
            <td class="modal-sm" style="width: 518px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>


     <br /> <br /> <br />




    </asp:Content>
