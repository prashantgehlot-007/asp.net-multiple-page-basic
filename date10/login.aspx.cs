using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace date10
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\Mywork\date10\date10\App_Data\Database1.mdf;Integrated Security=True");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Select * From Users Where UId = @Uid and UPass = @Upass", conn);
                cmd.Parameters.AddWithValue("@Uid", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Upass", TextBox2.Text);
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Response.Redirect("myhome.aspx");
                    //string fname = dr["FName"].ToString();
                    //Response.Redirect("myhome.aspx?name =+fname");

                }
                else
                {
                    Response.Write("Invalid user id/passoward");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}