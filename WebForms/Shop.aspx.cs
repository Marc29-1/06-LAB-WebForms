using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
    public partial class Shop : System.Web.UI.Page
    {
        private readonly string cs =
            ConfigurationManager.ConnectionStrings["WebFormsLabosCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // (opcionalno) zaštita stranice
            if (Session["korisnik"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                UcitajProizvode();
            }
        }

        private void UcitajProizvode()
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Products", conn);

                SqlDataReader dr = cmd.ExecuteReader();

                gvProizvodi.DataSource = dr;
                gvProizvodi.DataBind();

                dr.Close();
            }
        }

        protected void btnSpremi_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Products (Name, Description) VALUES (@n, @o)", conn);

                cmd.Parameters.AddWithValue("@n", tbNaziv.Text.Trim());
                cmd.Parameters.AddWithValue("@o", tbOpis.Text.Trim());

                cmd.ExecuteNonQuery();
            }

            tbNaziv.Text = "";
            tbOpis.Text = "";

            UcitajProizvode();
        }
    }
}