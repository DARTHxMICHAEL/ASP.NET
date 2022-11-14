<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Sortowanie.aspx.cs" Inherits="Sortowanie" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br/> <br/> <br/> <br/> 
    <table class="nav-justified">
        <tr>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 396px" class="modal-sm">Porównanie wydajności sortowania</td>
            <td style="width: 25px">&nbsp;</td>
            <td class="modal-sm" style="width: 352px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 396px" class="modal-sm">
                <asp:TextBox ID="TextBox1" runat="server" Height="333px" Width="342px" BackColor="#BFCADE" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox></td>
            <td style="width: 25px">&nbsp;</td>
            <td class="modal-sm" style="width: 352px">Algorytm ma na celu porównanie wydajności sortowania bąbelkowego O(n^2) z dużo wydajniejszym sortowaniem przez scalanie O(n*logn).
                <br />
                <br />
                Na poczatku generujemy losowo 30000 liczb i zapisujemy w oddzielnych tablicach. Sortowanie przez scalanie działa na zasadzie podziału tablicy na mniejsze aż do dojścia do elementów atomowych (pojedyńczych liczb), porównaniu ich i scaleniu już w odpowiedzniej kolejności. Koszt porównania i scalenia to n, głebokość drzewa to logn. Stąd złożoność czasowa n*logn. Oszczędność polega na braku konieczności porównywania (przechodzenia) przez wszystkie elementy. Rekurencyjna wersja algorytmu.</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px; height: 20px;"></td>
            <td style="width: 396px; height: 20px;" class="modal-sm"></td>
            <td style="width: 25px; height: 20px;"></td>
            <td class="modal-sm" style="width: 352px; height: 20px;"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 100px">&nbsp; &nbsp;</td>
            <td style="width: 396px" class="modal-sm">
               &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="START" Width="114px" BackColor="#BFCADE" style="color:#4a83cf; padding: 0px; text-align:center; align-content: center; vertical-align:middle" BorderWidth="1px" OnClick="Button1_Click"/>
            </td>
            <td style="width: 25px">&nbsp;</td>
            <td class="modal-sm" style="width: 352px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 396px" class="modal-sm">&nbsp;</td>
            <td style="width: 25px">&nbsp;</td>
            <td class="modal-sm" style="width: 352px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 396px" class="modal-sm">&nbsp;</td>
            <td style="width: 25px">&nbsp;</td>
            <td class="modal-sm" style="width: 352px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 396px" class="modal-sm">&nbsp;</td>
            <td style="width: 25px">&nbsp;</td>
            <td class="modal-sm" style="width: 352px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 396px" class="modal-sm">&nbsp;</td>
            <td style="width: 25px">&nbsp;</td>
            <td class="modal-sm" style="width: 352px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 396px" class="modal-sm">&nbsp;</td>
            <td style="width: 25px">&nbsp;</td>
            <td class="modal-sm" style="width: 352px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 396px" class="modal-sm">&nbsp;</td>
            <td style="width: 25px">&nbsp;</td>
            <td class="modal-sm" style="width: 352px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 396px" class="modal-sm">&nbsp;</td>
            <td style="width: 25px">&nbsp;</td>
            <td class="modal-sm" style="width: 352px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 396px" class="modal-sm">&nbsp;</td>
            <td style="width: 25px">&nbsp;</td>
            <td class="modal-sm" style="width: 352px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">&nbsp;</td>
            <td style="width: 396px" class="modal-sm">&nbsp;</td>
            <td style="width: 25px">&nbsp;</td>
            <td class="modal-sm" style="width: 352px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br/> 







</asp:content>
