using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Helpdesk
{
    public partial class Capture : System.Web.UI.Page
    {
        string location = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string firstName = Request.Form["firstName"];
            string lastName = Request.Form["lastName"];
            string email = Request.Form["email"];
            string phone = Request.Form["phone"];
            string address1 = Request.Form["address1"];
            string state = Request.Form["state"];
            string gender = Request.Form["gender"];
            string loca = Request.Form["loca"];

            casesList now = new casesList
            {
               username = firstName + " " + lastName,
               email = email,
               phone = phone,
               address = address1,
               qry =state,
               priority = gender,
               location = loca
            };

            DbQueries query = new DbQueries();
            string result = query.addCase(now);
        }

        protected void userDetailsForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}