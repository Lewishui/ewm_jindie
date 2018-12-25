using clsBuiness;
using SDZdb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class frmReadIDCare : System.Web.UI.Page
    {
        public string alterinfo;
        List<clCard_info> readCards;
        public string user;
        public string pass;
        private SortableBindingList<clCard_info> sortablePendingOrderList;

        bool ischeck_zhengjianhaoma = true;
        clsAllnew BusinessHelp;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!Page.IsPostBack)
                {
                    if (Cache["servename"] != null)
                    {
                        comboBox1.Text = Cache["servename"].ToString();
                        pass = "123456";
                        Response.Write(Cache["servename"] + "这里是从缓存中读取的时间");//这里读取的缓存中的时间，刷新页面时，这里的随着时间变化，不会变化。
                    }
                    string dengluleibie = Request.QueryString["dengluleibie"];
                    if (dengluleibie == "nologin")
                    {

                    }
                    BusinessHelp = new clsAllnew();
                    if (BusinessHelp.ConStr == null || BusinessHelp.ConStr == null)
                        Response.Redirect("~/Myadmin/login.aspx");

                }
                bind();
            }
            //  Button1.Attributes.Add("onclick", "chkData()");
            ischeck_zhengjianhaoma = true;
            if (this.hidden1.Value == "1")
            {
                ischeck_zhengjianhaoma = false;
                this.MyGo();
            }
        }
        public class SortableBindingList<T> : BindingList<T>
        {
            private bool isSortedCore = true;
            private ListSortDirection sortDirectionCore = ListSortDirection.Ascending;
            private PropertyDescriptor sortPropertyCore = null;
            private string defaultSortItem;

            public SortableBindingList() : base() { }

            public SortableBindingList(IList<T> list) : base(list) { }

            protected override bool SupportsSortingCore
            {
                get { return true; }
            }

            protected override bool SupportsSearchingCore
            {
                get { return true; }
            }

            protected override bool IsSortedCore
            {
                get { return isSortedCore; }
            }

            protected override ListSortDirection SortDirectionCore
            {
                get { return sortDirectionCore; }
            }

            protected override PropertyDescriptor SortPropertyCore
            {
                get { return sortPropertyCore; }
            }

            protected override int FindCore(PropertyDescriptor prop, object key)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (Equals(prop.GetValue(this[i]), key)) return i;
                }
                return -1;
            }

            protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
            {
                isSortedCore = true;
                sortPropertyCore = prop;
                sortDirectionCore = direction;
                Sort();
            }

            protected override void RemoveSortCore()
            {
                if (isSortedCore)
                {
                    isSortedCore = false;
                    sortPropertyCore = null;
                    sortDirectionCore = ListSortDirection.Ascending;
                    Sort();
                }
            }

            public string DefaultSortItem
            {
                get { return defaultSortItem; }
                set
                {
                    if (defaultSortItem != value)
                    {
                        defaultSortItem = value;
                        Sort();
                    }
                }
            }

            private void Sort()
            {
                List<T> list = (this.Items as List<T>);
                list.Sort(CompareCore);
                ResetBindings();
            }

            private int CompareCore(T o1, T o2)
            {
                int ret = 0;
                if (SortPropertyCore != null)
                {
                    ret = CompareValue(SortPropertyCore.GetValue(o1), SortPropertyCore.GetValue(o2), SortPropertyCore.PropertyType);
                }
                if (ret == 0 && DefaultSortItem != null)
                {
                    PropertyInfo property = typeof(T).GetProperty(DefaultSortItem, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.IgnoreCase, null, null, new Type[0], null);
                    if (property != null)
                    {
                        ret = CompareValue(property.GetValue(o1, null), property.GetValue(o2, null), property.PropertyType);
                    }
                }
                if (SortDirectionCore == ListSortDirection.Descending) ret = -ret;
                return ret;
            }

            private static int CompareValue(object o1, object o2, Type type)
            {
                if (o1 == null) return o2 == null ? 0 : -1;
                else if (o2 == null) return 1;
                else if (type.IsPrimitive || type.IsEnum) return Convert.ToDouble(o1).CompareTo(Convert.ToDouble(o2));
                else if (type == typeof(DateTime)) return Convert.ToDateTime(o1).CompareTo(o2);
                else return String.Compare(o1.ToString().Trim(), o2.ToString().Trim());
            }
        }


        public void bind()
        {

            //gvList.DataSource = readCards;

            //gvList.DataBind();
            btReadcard_server_Click(null, EventArgs.Empty);
            InitialSystemInfo();
        }
        protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Btn_Operation")
            {
                int RowRemark = Convert.ToInt32(e.CommandArgument);
                if (RowRemark >= 0)
                {
                    //string QiHao = gvList.Rows[RowRemark].Cells[1].Text.ToString();
                    BusinessHelp = new clsAllnew();
                    gohome();

                    string QiHao = gvList.DataKeys[RowRemark].Value.ToString();
                    string sql2 = "delete from t_Item_3002 where   FItemID='" + QiHao + "'";

                    BusinessHelp.Readt_PICServer(sql2);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功')</script>");
                    btReadcard_server_Click(null, EventArgs.Empty);

                    InitialSystemInfo();


                }
            }
            else if (e.CommandName == "Btn_View")
            {
                int RowRemark = Convert.ToInt32(e.CommandArgument);
                if (RowRemark >= 0)
                {
                    BusinessHelp = new clsAllnew();
                    gohome();
                    string QiHao = gvList.DataKeys[RowRemark].Value.ToString();
                    string sql2 = "select * from t_Accessory where   FItemID='" + QiHao + "'";

                    List<clCard_info> readCards = BusinessHelp.Readt_PICServer(sql2);

                    Response.Redirect("~/ViewImage.aspx?QiHao=" + QiHao);



                }

            }
        }

        private void gohome()
        {
            if (BusinessHelp.ConStr == null || BusinessHelp.ConStr == null)
                Response.Redirect("~/Myadmin/login.aspx");
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvList.EditIndex = e.NewEditIndex;
            //使编辑的行是当前操作的行   editIndex:编辑行的索引  newEditIndex:所编辑的行的索引
            bind();

        }
        //protected void GridView1_RowCancelUpdating(object sender, GridViewEditEventArgs e)
        //{
        //    this.gvList.EditIndex = -1;
        //    //使编辑的行是当前操作的行   editIndex:编辑行的索引  newEditIndex:所编辑的行的索引
        //    bind();

        //}
        //取消
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvList.EditIndex = -1;
            bind();
        }
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Attributes.Add("style", "height:43px Width:43px");
            if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == DataControlRowState.Alternate || e.Row.RowState == DataControlRowState.Edit)
            {
                TextBox curText;
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Controls.Count != 0)
                    {
                        curText = e.Row.Cells[i].Controls[0] as TextBox;
                        if (curText != null)
                        {
                            curText.Width = Unit.Pixel(10);
                        }
                    }
                }
            }
        }
        protected void GridView_Pue_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            BusinessHelp = new clsAllnew();
            gohome();

            List<clCard_info> AddreadCards = new List<clCard_info>();
            clCard_info item = new clCard_info();


            item.daima_gonghao = ((TextBox)(gvList.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
            item.mingcheng = ((TextBox)(gvList.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
            item.xingbie = ((TextBox)(gvList.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
            item.minzu = ((TextBox)(gvList.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim();
            item.chushengriqi = ((TextBox)(gvList.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim();
            item.zhengjianleixing = ((TextBox)(gvList.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim();
            item.zhengjianhaoma = ((TextBox)(gvList.Rows[e.RowIndex].Cells[8].Controls[0])).Text.ToString().Trim();
            item.jiatingzhuzhi = ((TextBox)(gvList.Rows[e.RowIndex].Cells[9].Controls[0])).Text.ToString().Trim();
            item.zhengjianyouxiao = ((TextBox)(gvList.Rows[e.RowIndex].Cells[10].Controls[0])).Text.ToString().Trim();
            item.jiguan = ((TextBox)(gvList.Rows[e.RowIndex].Cells[11].Controls[0])).Text.ToString().Trim();

            AddreadCards.Add(item);

            BusinessHelp.changeCardServer(AddreadCards);

            gvList.EditIndex = -1;
            bind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            btReadcard_server_Click(null, EventArgs.Empty);

            BusinessHelp = new clsAllnew();
            gohome();

            if (readCards == null)
                readCards = new List<clCard_info>();
            readCards.Sort(new China_System.Common.clsCommHelp.Comp());

            #region 新的员工号
            string qi = DateTime.Now.ToString("yyyyMMddss");

            if (readCards == null || readCards.Count == 0)
            {
                qi = DateTime.Now.ToString("yyyyMMddss");
            }
            else
            {
                //ClaimReport_Server.Sort(new Comp());
                qi = System.Text.RegularExpressions.Regex.Replace(readCards[0].daima_gonghao, @"[^0-9]+", "");

            }

            int a = Convert.ToInt32(qi) + 1;
            string newaddno = readCards[0].daima_gonghao.Replace(qi, "") + a.ToString();
            readCards.Sort(new China_System.Common.clsCommHelp.Comp1());

            int FItemID = Convert.ToInt32(readCards[0].Order_id) + 1;
            #endregion
            readCards = BusinessHelp.Read_card();

            //if (results != null && results.Count > 0)
            //    readCards = readCards.Concat(results).ToList();

            if (readCards != null)
            {
                readCards[0].daima_gonghao = newaddno;
                readCards[0].Order_id = FItemID.ToString();
                if (ischeck_zhengjianhaoma == true)
                {
                    bool isdouble = CHECK_zhengjianhaoma(BusinessHelp);
                    if (isdouble == false)
                    {
                        btwrite_Click(null, EventArgs.Empty);

                        bind();
                    }
                    else
                        return;
                }
                else
                {
                    btwrite_Click(null, EventArgs.Empty);
                    bind();
                }
            }
        }
        private void InitialSystemInfo()
        {
            if (readCards == null)
                readCards = new List<clCard_info>();

            this.gvList.AutoGenerateColumns = false;
            sortablePendingOrderList = new SortableBindingList<clCard_info>(readCards);
            //this.bindingSource1.DataSource = sortablePendingOrderList;
            this.gvList.DataSource = sortablePendingOrderList;
            gvList.DataKeyNames = new string[] { "Order_id" };//主键
            this.gvList.DataBind();
        }

        protected void btwrite_Click(object sender, EventArgs e)
        {
            BusinessHelp = new clsAllnew();
            gohome();
            if (readCards != null && readCards.Count > 0)
            {
                string sql2 = "delete from t_Item_3002 where   F_104='" + readCards[0].zhengjianhaoma + "'";

                BusinessHelp.deleteCard(sql2);
            }
            BusinessHelp.createICcard_info_Server(readCards);
            //更新图片
            if (readCards != null && readCards.Count > 0)
            {
                string sql2 = "delete from t_Accessory where   FItemID='" + readCards[0].Order_id + "'";

                BusinessHelp.deleteCard(sql2);
            }
            readCards[0].FTypeID = "3002";

            BusinessHelp.createPIC_info_Server(readCards);


            alterinfo = "添加用户成功！";
        }

        private bool CHECK_zhengjianhaoma(clsAllnew BusinessHelp)
        {
            bool isdouble = false;

            string conditions = "select * from t_Item_3002  where   F_104='" + readCards[0].zhengjianhaoma + "'";//成功

            List<clCard_info> FindreadCards = BusinessHelp.Readt_ItemServer(conditions);
            if (FindreadCards.Count > 0)
            {
                ///   Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('证件号号已存在')</script>");
                //Button1.Attributes.Add("onclick", "chkData()");
                //ShowConfirm("123", "", "");
                // Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>if(confirm('确认添加？'))alert('点击了确定');else alert('点击了取消')</script>");

                //Response.Write("<script>confirm('aaaaaaaaa')</script>");

                string msg = "检测第" + readCards[0].zhengjianhaoma.ToString() + " 数据已存在,是否覆盖?'";
                this.ClientScript.RegisterStartupScript(this.GetType(), msg, "<script>MyConfirm();</script>");
                isdouble = true;




            }
            return isdouble;
        }
        private void MyGo()
        {
            Button1_Click(null, EventArgs.Empty);
            this.hidden1.Value = "2";

        }
        private void CreateITEM_CARD_Server(clsAllnew BusinessHelp)
        {

        }
        public static void ShowConfirm(string strMsg, string strUrl_Yes, string strUrl_No)
        {
            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>if ( window.confirm('" + strMsg + "')) { window.location.href='" + strUrl_Yes +
            "' } else {window.location.href='" + strUrl_No + "' };</script>");
        }
        protected void btReadcard_server_Click(object sender, EventArgs e)
        {
            BusinessHelp = new clsAllnew();
            gohome();
            readCards = new List<clCard_info>();
            string conditions = "select * from t_Item_3002";//成功

            readCards = BusinessHelp.Readt_ItemServer(conditions);

            InitialSystemInfo();
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            bind();
        }

        void toExcel(GridView gv)
        {
            Response.Charset = "GB2312";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

            //string fileName = "export.xls";
            string fileName = "System  Info" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            string style = @"<style> .text { mso-number-format:\@; } </script> ";
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Write(style);
            Response.Write(sw.ToString());
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }


        protected void toExcel(object sender, EventArgs e)
        {
            //bind();
            //toExcel(gvList);
            Response.Clear();
            string fileName = "System  Info" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";

            Response.AddHeader("content-disposition",

            "attachment;filename=" + fileName);

            Response.Charset = "";

            // If you want the option to open the Excel file without saving than

            // comment out the line below

            // Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.ContentType = "application/vnd.xlsx";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlWrite =
            new HtmlTextWriter(stringWrite);

            // turn off paging 
            gvList.AllowPaging = false;
            bind();


            gvList.RenderControl(htmlWrite);

            Response.Write(stringWrite.ToString());

            Response.End();

            // turn the paging on again 
            gvList.AllowPaging = true;
            bind();

        }
    }
}