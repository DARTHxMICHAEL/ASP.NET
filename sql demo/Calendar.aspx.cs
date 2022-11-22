using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;

public partial class Calendar : System.Web.UI.Page
{
    //zdefiniuj nowe 'wydarzenia
    private DataTable socialEvents;

    //połączenie z bazą
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    /// <summary>
    /// ładowanie strony
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        //zbuduj nową tabele 'wydarzeń
        BuildSocialEventTable();

        //zamknięcie i otworzenie połaczenia
        conn.Close();
        conn.Open();
    }

    /// <summary>
    /// tworzenie tabeli wydarzeń społecznych
    /// </summary>
    private void BuildSocialEventTable()
    {
        //SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Practice;User ID=sa;Password=************");

        //konwersja danych z bazy do 'socialEvents
        SqlDataAdapter sda = new SqlDataAdapter("select EventDate,EventDesc FROM TableTwo", conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        socialEvents = ds.Tables[0];
    }


    /// <summary>
    /// obsługa kalendarza CALENDAR1(DayRender)
    /// </summary>
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        try
        {
            DataRow[] rows = socialEvents.Select(
            String.Format(
            "Date >= #{0}# AND Date < #{1}#",
            e.Day.Date.ToShortDateString(),
            e.Day.Date.AddDays(1).ToShortDateString()
        ));

            foreach (DataRow row in rows)
            {
                System.Web.UI.WebControls.Image image;
                image = new System.Web.UI.WebControls.Image();
                image.ImageUrl = this.ResolveUrl("Images/hex_logo.png");
                image.ToolTip = row["EventDesc"].ToString();
                // e.Cell.Controls.Add(image);  
                e.Cell.BackColor = Color.Wheat;
            }


        }
        catch (Exception) { }
    }

    /// <summary>
    /// obsługa kalendarza CALENDAR1(SelectionChanged)
    /// </summary>
    protected void Calendar1_SelChanged(object sender, EventArgs e)
    {
        //wypisz zaznaczoną datę w 'TextBox1
        TextBox1.Text = Calendar1.SelectedDate.ToString();

        System.Data.DataView view = socialEvents.DefaultView;
        try
        {
            view.RowFilter = String.Format(
                          "Date >= #{0}# AND Date < #{1}#",
                          Calendar1.SelectedDate.ToShortDateString(),
                          Calendar1.SelectedDate.AddDays(1).ToShortDateString());
        }
        catch (Exception) { }


        if (view.Count > 0)
        {
            GridView1.Visible = true;
            //aktualizacja widoku
            GridView1.DataBind();
        }
        else
        {
            GridView1.Visible = false;
        }
    }

    /// <summary>
    /// inicjalizacja kalendarza CALENDAR1(OnInit)
    /// </summary>
    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// inicjalizacja i uzupełnienie informacji kalendarza CALENDAR1(InitialisationInfo)
    /// </summary>
    private void InitializeComponent()
    {
        this.Calendar1.DayRender += new System.Web.UI.WebControls.DayRenderEventHandler(this.Calendar1_DayRender);
        this.Calendar1.SelectionChanged += new System.EventHandler(this.Calendar1_SelChanged);
        this.Load += new System.EventHandler(this.Page_Load);

    }

    /// <summary>
    /// dodanie danych do bazy 
    /// </summary>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //sprawdź czy użytkownik się zalogował
        bool isUserLogged = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

        if (isUserLogged)
        {
            Response.Redirect("~/Account/Login");
        }
        else
        {
            //SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Practice;User ID=sa;Password=***********");

            //generuj losowe ID dla wydarzenia
            Random rnd = new Random();
            int index = rnd.Next(1, 1000);

            //dodaj do bazy
            SqlCommand command = new SqlCommand("insert into TableTwo values('" + index + "','" + TextBox1.Text.ToString()/*Calendar1.SelectedDate*/ + "','" + TextBox2.Text + "','" + DropDownList1.Text.ToString() + "')", conn);

            //execute
            command.ExecuteNonQuery();
            //zamknij połaczenie
            conn.Close();
            //aktualizacja widoku
            GridView1.DataBind();
        }     
    }

    /// <summary>
    /// usuń wszystkie rekordy z bazy (wydarzenia)
    /// </summary>
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            //komenda usuwająca wszystkie dane z tabeli
            SqlCommand command = new SqlCommand("delete from TableTwo", conn);

            //execute
            command.ExecuteNonQuery();
            //zamknij połaczenie
            conn.Close();
            //aktualizacja widoku
            GridView1.DataBind();
        }
        catch(Exception ex) { }
        
    }

    /// <summary>
    /// usuń wybrane wydarzenia z bazy
    /// </summary>
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            //komenda usuwająca z bazy na podstawie daty wydarzenia
            SqlCommand command = new SqlCommand("delete from TableTwo where EventDate = '" + TextBox1.Text.ToString() + "'", conn);

            //execute
            command.ExecuteNonQuery();
            //zamknij połaczenie
            conn.Close();
            //aktualizacja widoku
            GridView1.DataBind();
        }
        catch (Exception ex) { }
    }

}
