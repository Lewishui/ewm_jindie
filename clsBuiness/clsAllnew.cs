using SDZdb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clsBuiness
{
    public enum ProcessStatus
    {
        初始化,
        登录界面,
        确认YES,
        第一页面,
        第二页面,
        Filter下拉,
        关闭页面,
        结束页面

    }
    public class clsAllnew
    {

        string newsth;
        public BackgroundWorker bgWorker1;
        private ProcessStatus isrun = ProcessStatus.初始化;
        public ToolStripProgressBar pbStatus { get; set; }
        public ToolStripStatusLabel tsStatusLabel1 { get; set; }
        public ToolStripStatusLabel tsStatusLabel2 { get; set; }
        private DateTime StopTime;
        List<clsuserinfo> userinfo_webResult;
        public string ConStr;
        public clsAllnew()
        {


            ConStr = System.Web.Configuration.WebConfigurationManager.AppSettings["connectionstring"];
        }
        public List<clsuserinfo> findUser(string findtext)
        {
            try
            {
              //  string strSelect = "select * from emw_user where name='" + findtext + "'";
                OleDbConnection aConnection = new OleDbConnection(ConStr);

                List<clsuserinfo> ClaimReport_Server = new List<clsuserinfo>();
                if (aConnection.State == ConnectionState.Closed)
                    aConnection.Open();

                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(findtext, aConnection);
                OleDbCommandBuilder mybuilder = new OleDbCommandBuilder(myDataAdapter);
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds, "emw_user");
                foreach (DataRow reader in ds.Tables["emw_user"].Rows)
                {
                    clsuserinfo item = new clsuserinfo();

                    if (reader["_id"].ToString() != "")
                        item.Order_id = reader["_id"].ToString();
                    if (reader["name"].ToString() != "")
                        item.name = reader["name"].ToString();
                    if (reader["password"].ToString() != "")
                        item.password = reader["password"].ToString();
                    if (reader["Createdate"].ToString() != "")
                        item.Createdate = reader["Createdate"].ToString();
                    if (reader["Btype"].ToString() != "")
                        item.Btype = reader["Btype"].ToString();

                    if (reader["denglushijian"].ToString() != "")
                        item.denglushijian = reader["denglushijian"].ToString();
                    if (reader["jigoudaima"].ToString() != "")
                        item.jigoudaima = reader["jigoudaima"].ToString();
                    if (reader["userTime"].ToString() != "")
                        item.userTime = reader["userTime"].ToString();

                    if (reader["AdminIS"].ToString() != "")
                        item.AdminIS = reader["AdminIS"].ToString();
                    if (reader["mibao"].ToString() != "")
                        item.mibao = reader["mibao"].ToString();


                    ClaimReport_Server.Add(item);

                    //这里做数据处理....
                }
                return ClaimReport_Server;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void createUser_Server(List<clsuserinfo> AddMAPResult)
        {




            //创建连接对象
            bool isok = false;
            OleDbConnection con = new OleDbConnection(ConStr);
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                //命令
                foreach (clsuserinfo item in AddMAPResult)
                {

                    string sql = "";
                    sql = "insert into emw_user(name,password,Createdate,Btype,denglushijian,jigoudaima,userTime,AdminIS,mibao) values ('" + item.name + "','" + item.password + "',N'" + item.Createdate + "','" + item.Btype + "','" + item.denglushijian + "','" + item.jigoudaima + "','" + item.userTime + "','" + item.AdminIS + "','" + item.mibao + "')";

                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    isok = true;

                }
                //con.Close();
                return;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open) con.Close();
                if (con != null)
                    con.Dispose();
                return;

                throw;
            }
            finally { if (con.State == ConnectionState.Open) con.Close(); con.Dispose(); }
        }
        public List<clsuserinfo> ReadUserlistfromServer()
        {
            string conditions = "select * from emw_user";//成功

            OleDbConnection aConnection = new OleDbConnection(ConStr);

            List<clsuserinfo> ClaimReport_Server = new List<clsuserinfo>();
            if (aConnection.State == ConnectionState.Closed)
                aConnection.Open();

            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(conditions, aConnection);
            OleDbCommandBuilder mybuilder = new OleDbCommandBuilder(myDataAdapter);
            DataSet ds = new DataSet();
            myDataAdapter.Fill(ds, "emw_user");
            foreach (DataRow reader in ds.Tables["emw_user"].Rows)
            {
                clsuserinfo item = new clsuserinfo();

                if (reader["_id"].ToString() != "")
                    item.Order_id = reader["_id"].ToString();
                if (reader["name"].ToString() != "")
                    item.name = reader["name"].ToString();
                if (reader["password"].ToString() != "")
                    item.password = reader["password"].ToString();
                if (reader["Createdate"].ToString() != "")
                    item.Createdate = reader["Createdate"].ToString();
                if (reader["Btype"].ToString() != "")
                    item.Btype = reader["Btype"].ToString();

                if (reader["denglushijian"].ToString() != "")
                    item.denglushijian = reader["denglushijian"].ToString();
                if (reader["jigoudaima"].ToString() != "")
                    item.jigoudaima = reader["jigoudaima"].ToString();
                if (reader["userTime"].ToString() != "")
                    item.userTime = reader["userTime"].ToString();

                if (reader["AdminIS"].ToString() != "")
                    item.AdminIS = reader["AdminIS"].ToString();

                if (reader["mibao"].ToString() != "")
                    item.mibao = reader["mibao"].ToString();

                ClaimReport_Server.Add(item);

                //这里做数据处理....
            }
            return ClaimReport_Server;

        }
        public bool deleteUSER(string name)
        {



            OleDbConnection con = new OleDbConnection(ConStr);
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql2 = "delete from emw_user where   name='" + name + "'";

                OleDbCommand cmd = new OleDbCommand(sql2, con);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open) con.Close();
                if (con != null)
                    con.Dispose();
                return false;

                throw;
            }
            finally { if (con.State == ConnectionState.Open) con.Close(); con.Dispose(); }

        }
        public bool changeUserpassword_Server(List<clsuserinfo> AddMAPResult)
        {
            //创建连接对象
            bool isok = false;
            OleDbConnection con = new OleDbConnection(ConStr);
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                //命令
                foreach (clsuserinfo item in AddMAPResult)
                {

                    string sql = "";
                    string conditions = "";
                    if (item.password != null)
                    {
                        conditions += " password ='" + item.password + "'";
                    }
                    if (item.name != null)
                    {
                        conditions += " ,name ='" + item.name + "'";
                    }
                    if (item.Btype != null)
                    {
                        conditions += " ,Btype ='" + item.Btype + "'";
                    }
                    if (item.denglushijian != null)
                    {
                        conditions += " ,denglushijian ='" + item.denglushijian + "'";
                    }
                    if (item.Createdate != null)
                    {
                        conditions += " ,Createdate ='" + item.Createdate + "'";
                    }
                    if (item.AdminIS != null)
                    {
                        conditions += " ,AdminIS ='" + item.AdminIS + "'";
                    }
                    if (item.jigoudaima != null)
                    {
                        conditions += " ,jigoudaima ='" + item.jigoudaima + "'";
                    }
                    if (item.userTime != null)
                    {
                        conditions += " ,userTime ='" + item.userTime + "'";
                    }
                    if (item.mibao != null)
                    {
                        conditions += " ,mibao ='" + item.mibao + "'";
                    }


                    conditions = "update emw_user set  " + conditions + " where _id = " + item.Order_id + " ";
                    sql = conditions;

                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    isok = true;

                }
                //con.Close();
                return isok;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open) con.Close();
                if (con != null)
                    con.Dispose();
                return false;

                throw;
            }
            finally { if (con.State == ConnectionState.Open) con.Close(); con.Dispose(); }

        }
    }
}
