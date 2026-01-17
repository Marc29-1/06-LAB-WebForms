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
    public partial class Registracija : System.Web.UI.Page
    {
        private readonly string cs =
            ConfigurationManager.ConnectionStrings["WebFormsLabosCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegistriraj_Click(object sender, EventArgs e)
        {
            
            if (tbLozinka.Text != tbLozinkaPotvrda.Text)
            {
                lblPoruka.Text = "Lozinke se ne podudaraju.";
                return;
            }

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                
                SqlCommand provjeraCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Users WHERE UserName = @korisnickoIme", conn);

                provjeraCmd.Parameters.AddWithValue("@korisnickoIme",
                    tbKorisnickoIme.Text.Trim());

                int postoji = (int)provjeraCmd.ExecuteScalar();

                if (postoji > 0)
                {
                    lblPoruka.Text = "Korisničko ime već postoji.";
                    return;
                }

                
                SqlCommand insertCmd = new SqlCommand(
                    "INSERT INTO Users (UserName, Password, FullName) VALUES (@ki, @loz, @pi)", conn);

                insertCmd.Parameters.AddWithValue("@ki", tbKorisnickoIme.Text.Trim());
                insertCmd.Parameters.AddWithValue("@loz", tbLozinka.Text.Trim());
                insertCmd.Parameters.AddWithValue("@pi", tbPunoIme.Text.Trim());

                insertCmd.ExecuteNonQuery();
            }

           
            Response.Redirect("Login.aspx");
        }
    }
}