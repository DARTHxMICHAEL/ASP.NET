using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class DataBase : System.Web.UI.Page
{
    //połącznie z bazą
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    /// <summary>
    /// ładowanie strony
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        //otwórz połącznie
        conn.Open();

        ////usun stare rekordy na starcie
        //SqlCommand command = new SqlCommand("delete from TableOne", conn);
        //command.ExecuteNonQuery();
        //GridView1.DataBind();
    }

    /// <summary>
    /// dodaj użytkownika
    /// </summary>
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //sprawdź czy użytkownik się zalogował
            bool isUserLogged = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (isUserLogged)
            {
                Response.Redirect("~/Account/Login");
            }
            else
            {
                //komenda
                SqlCommand cmd = new SqlCommand("SELECT COUNT(Id) FROM TableOne",conn);
                Int32 count = (Int32)cmd.ExecuteScalar();

                //preinkrementacja id użytkownika
                //TextBox4.Text = count.ToString();
                ++count;

                //komenda
                SqlCommand command = new SqlCommand("insert into TableOne values('" + count + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox5.Text + "')", conn);
                //execute
                command.ExecuteNonQuery();
                //zamknij 
                conn.Close();

                //UI
                GridView1.DataBind();
                TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox5.Text = "";
            }
        }
        catch(Exception ex)
        {
            //informacja o błędzie
            TextBox1.Text = ">> błąd: " + ex.ToString();
        }
           
    }

    /// <summary>
    /// aktualizuj dane
    /// </summary>
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            //sprawdź czy użytkownik się zalogował
            bool isUserLogged = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (isUserLogged)
            {
                Response.Redirect("~/Account/Login");
            }
            else
            {
                //komenda
                SqlCommand command = new SqlCommand("update TableOne set Imie = '" + TextBox2.Text + "', Wiek = '" + TextBox3.Text + "', E-mail = '" + TextBox5.Text + "' where Id = '" + TextBox1.Text + "'", conn);
                //execute
                command.ExecuteNonQuery();
                //zamknij 
                conn.Close();

                //UI
                GridView1.DataBind();
                TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox5.Text = "";
            }
        }
        catch(Exception ex)
        {
            //informacja o błędzie
            TextBox1.Text = ">> błąd: " + ex.ToString();
        }
        
    }

    /// <summary>
    /// usuń użytkownika
    /// </summary>
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            //sprawdź czy użytkownik się zalogował
            bool isUserLogged = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (isUserLogged)
            {
                Response.Redirect("~/Account/Login");
            }
            else
            {
                //komenda
                SqlCommand command = new SqlCommand("delete from TableOne where Id = '" + TextBox1.Text + "'", conn);
                //execute
                command.ExecuteNonQuery();
                //zamknij 
                conn.Close();

                //UI
                GridView1.DataBind();
                TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox5.Text = "";
            }
        }
        catch(Exception ex)
        {
            //informacja o błędzie
            TextBox1.Text = ">> błąd: " + ex.ToString();
        }

    }

    /// <summary>
    /// filtruj wyniki
    /// </summary>
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            //komenda
            String find = "select * from TableOne where (Id like '%' +@Id+ '%')";
            SqlCommand command = new SqlCommand(find, conn);
            command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = TextBox4.Text;
            command.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Id");

            GridView1.DataSourceID = null;
            GridView1.DataSource = dataSet;

            //zamknij 
            conn.Close();

            //UI
            GridView1.DataBind();
            TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox5.Text = "";
        }
        catch(Exception ex)
        {
            //informacja o błędzie
            TextBox1.Text = ">> błąd: " + ex.ToString();
        }
        
    }

    /// <summary>
    /// usuń filtry
    /// </summary>
    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
            //komenda pokazjąca wszystkie elementy
            String find = "select * from TableOne";
            SqlCommand command = new SqlCommand(find, conn);
            command.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Id");

            GridView1.DataSourceID = null;
            GridView1.DataSource = dataSet;

            //zamknij 
            conn.Close();

            //UI
            GridView1.DataBind();
            TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox5.Text = "";
        }
        catch(Exception ex)
        {
            //informacja o błędzie
            TextBox1.Text = ">> błąd: " + ex.ToString();
        }

    }

}
