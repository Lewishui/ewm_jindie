using clsBuiness;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class login : System.Web.UI.Page
    {
        public string alterinfo1;

        bool is_AdminIS = false;
        int logis = 0;
        public string user;
        public string pass;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            { 
            
            }
        }
    

        protected void HtmlBtn_Click(object sender, EventArgs e)
        {

            string username = Request.Form["username"];
            string txtSAPPassword = Request.Form["password"];
            user = username;
            pass = txtSAPPassword;

            NewMethoduserFind(username.Trim(), txtSAPPassword.Trim());


          //  Response.Redirect("~/frmUserManger.aspx");
        }
        private bool NewMethoduserFind(string user, string pass)
        {
      
            //string connectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            try
            {
                clsAllnew BusinessHelp = new clsAllnew();

                List<clsuserinfo> userlist_Server = new List<clsuserinfo>();
                string strSelect = "select * from emw_user where name='" + user + "'";

                userlist_Server = BusinessHelp.findUser(strSelect.Trim());



                if (userlist_Server.Count > 0 && userlist_Server[0].Btype == "lock")
                {
                    //MessageBox.Show("登录失败,账户已被锁定，请重试或联系系统管理员，谢谢", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (userlist_Server.Count > 0 && userlist_Server[0].password.ToString().Trim() == pass.Trim() && userlist_Server[0].name.ToString().Trim() == user.Trim())
                {
                    alterinfo1 = "登录成功";
                    if (userlist_Server[0].AdminIS == "true")
                    {                       
                        btcreate.Visible= true;
                      
                        //是否是管理员
                        is_AdminIS = true;
                    }
                    logis++;
                }
                if (logis == 0)
                {
                    pass = "";

                    alterinfo1 = "登录失败，请确认用户名和密码或联系系统管理员，谢谢";
                   // MessageBox.Show("登录失败，请确认用户名和密码或联系系统管理员，谢谢", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return false;


            }
            catch (Exception ex)
            {
                //ProcessLogger.Fatal("0793212:System Login Start " + DateTime.Now.ToString());
                //MessageBox.Show("登录失败，验证用户信息异常！" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; ;

                throw;
            }

        }

        protected void HtmlBtcreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmUserManger.aspx");
        }

        protected void Btchangepas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Myadmin/changepassword.aspx");
        }


    }
}