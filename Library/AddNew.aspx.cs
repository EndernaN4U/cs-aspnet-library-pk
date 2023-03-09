using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;

namespace Library
{
    public partial class AddNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["connstr"] == null) Response.Redirect("Connection.aspx");
            if (Session["logged"] == null || !(bool)(Session["logged"])) Response.Redirect("login.aspx");
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string author = Author.Text,
                title = Title.Text,
                date = Date.Text,
                isbn = ISBN.Text,
                format = Format.Text,
                pages = Pages.Text,
                description = Description.Text;

            if(author == "" || title == "" || date == "" || isbn == "" || format == "" || pages == "" || description == "")
            {
                Errors.Text = "You need to fill text fields to continue!";
                return;
            }
            if(!new Regex(@"^[0-9]{2}[-][0-9]{2}[-][0-9]{4}$").IsMatch(date))
            {
                Errors.Text = "Date should be in format dd-mm-yyyy";
                return;
            }
            if(format.Length > 3)
            {
                Errors.Text = "Format shouldn't be longer than 3 chars!";
                return;
            }
            if (!new Regex(@"^[0-9]*$").IsMatch(pages))
            {
                Errors.Text = "Pages should be a number!";
                return;
            }
            

            MySqlConnection conn = Global.MakeConnSingle(Session["connstr"].ToString());
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = $"INSERT INTO books VALUES(NULL, '{author}', '{title}','{date}','{isbn}','{format}',{pages},'{description}')";
            comm.ExecuteNonQuery();

            Author.Text = "";
            Title.Text = "";
            ISBN.Text = "";
            Date.Text = "";
            Format.Text = "";
            Pages.Text = "";
            Description.Text = "";
            Errors.Text = "Added new book!";
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");
        }
    }
}