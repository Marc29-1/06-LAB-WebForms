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
    public partial class Login : System.Web.UI.Page
    {
        private readonly string cs =
            ConfigurationManager.ConnectionStrings["WebFormsLabosCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // nema logike ovdje
        }

        protected void btnPrijava_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Users WHERE UserName = @ki AND Password = @loz", conn);

                cmd.Parameters.AddWithValue("@ki", tbKorisnickoIme.Text.Trim());
                cmd.Parameters.AddWithValue("@loz", tbLozinka.Text.Trim());

                int ispravno = (int)cmd.ExecuteScalar();

                if (ispravno == 1)
                {
                    // (opcionalno) session
                    Session["korisnik"] = tbKorisnickoIme.Text.Trim();

                    Response.Redirect("Shop.aspx");
                }
                else
                {
                    lblPoruka.Text = "Pogrešno korisničko ime ili lozinka.";
                }
            }
        }
    }
}