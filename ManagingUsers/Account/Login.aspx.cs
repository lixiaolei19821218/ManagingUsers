using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManagingUsers.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (IsPostBack)
            {
                string user = Request["user"];
                string pass = Request["pass"];
                string action = Request["action"];
                if (action == "login" && user == "Joe" && pass == "secret")
                {
                    FormsAuthentication.RedirectFromLoginPage(user, false);
                }
                else
                {                   
                    message.Style["visibility"] = "visible";                    
                }                
            }
            if (Request.IsAuthenticated)
            {
                Response.StatusCode = 403;
                Response.SuppressContent = true;
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected string GetUser()
        {
            return Context.User.Identity.Name;
        }
        protected bool GetRequestStatus()
        {           
            return Request.IsAuthenticated;
        }
    }
}