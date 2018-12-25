<%@ Page Language="C#" EnableEventValidation = "false" AutoEventWireup="true" CodeBehind="frmReadIDCare.aspx.cs" Inherits="Web.frmReadIDCare" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <br />
  <a href="/Myadmin/login.aspx"><input type="text" size="26" style="font-size: 16pt ;border-style:none" value="      首页>数据录入"/></a>

    <script type="text/javascript">
        function MyConfirm() {
            if (confirm("证件号号已存在,确定要继续吗?") == true) {
                document.getElementById("hidden1").value = "1";
            }
            else {
                document.getElementById("hidden1").value = "0";
            }
            form1.submit();
        }
      
    </script>
    <style type="text/css">
   
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" id="hidden1" runat="server" />
        <div>
            <br />
            <br />
            <table>
                <tbody>
                    <tr>
                        <th width="30%">数据库*</th>
                        <td>
                            <asp:TextBox ID="comboBox1" runat="server"   class="select_w150"></asp:TextBox>
                        </td>
                        <th width="30%">登录密码*</th>
                        <td class="auto-style1">
                            <input name="password" type="password" class="select_w150" id="password" size="16" maxlength="100" value="<%=pass%>" readonly="true" /></td>

                    </tr>


                </tbody>


            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <br />
                <br />
                <tr>
                    <td align="center" colspan="5">
                        <div>
                            <asp:Button ID="button2" class="ui-btn ui-btn-search" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                                onmouseout="this.className='ui-btn ui-btn-search'" runat="server" Text="读取" OnClick="Button1_Click" Width="10%" Height="30px" />
                            &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="button3" class="ui-btn ui-btn-reset" onmouseover="this.className='ui-btn ui-btn-reset-hover'"
                                        onmouseout="this.className='ui-btn ui-btn-reset'" runat="server" Text="清空" OnClientClick="reSet();return false;" Width="10%" Height="30px" OnClick="button2_Click" />
                            &nbsp;&nbsp;&nbsp;
                             <asp:Button ID="button1" class="ui-btn ui-btn-search" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                                 onmouseout="this.className='ui-btn ui-btn-search'" runat="server" Text="入库" OnClick="btwrite_Click" Width="10%" Height="30px" />
                            &nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btReadcard_server" class="ui-btn ui-btn-search" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                                 onmouseout="this.className='ui-btn ui-btn-search'" runat="server" Text="查询本库所有" OnClick="btReadcard_server_Click" Width="10%" Height="30px" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnExport" class="ui-btn ui-btn-search" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                                onmouseout="this.className='ui-btn ui-btn-search'" runat="server" Text="导出Excel" OnClick="toExcel" Width="10%" Height="30px" />
                            &nbsp;&nbsp;&nbsp;
                        </div>
                    </td>

                </tr>
              
                <tr>

                    <td align="center" colspan="5">
                        <br />
                        <asp:Label ID="Label1" runat="server">
                             <%=alterinfo%>
                        </asp:Label>
                    </td>
                </tr>
            </table>

            <%--  CssClass="ui-datalist-view"--%>
            <asp:GridView ID="gvList" runat="server" Width="98%" AutoGenerateColumns="False"
                CssClass="mGrid"
                CellPadding="0" Style="margin-top: 5px;" GridLines="Vertical"
                EmptyDataText="&lt;span class='ui-icon ui-icon-remind' style='float: left; margin-right: .3em;'&gt;&lt;/span&gt;&lt;strong&gt;提醒：&lt;/strong&gt;对不起！您所查询的数据不存在。" OnRowCommand="GridView_OnRowCommand" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <Columns>
              
                    <asp:BoundField HeaderText="代码（即工号）" DataField="daima_gonghao">
                        <%--dengluzhanghao--%>
                        <%--<FooterStyle HorizontalAlign="Left" />--%>
                        <ControlStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="名称（即姓名）" DataField="mingcheng">
                        <%--denglumima--%>
                        <ControlStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="全名" DataField="quanming">
                        <%--suoshujigou--%>
                        <ControlStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="性别" DataField="xingbie">
                        <%--suoshujigou--%>
                        <ControlStyle Width="20px" />
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="民族" DataField="minzu">
                        <%--suoshujigou--%>
                        <ControlStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="出生日期" DataField="chushengriqi">
                        <%--suoshujigou--%>
                        <ControlStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="证件类型" DataField="zhengjianleixing">
                        <%--suoshujigou--%>
                        <ControlStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="证件号码" DataField="zhengjianhaoma">
                        <%--suoshujigou--%>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="家庭住址" DataField="jiatingzhuzhi">
                        <%--suoshujigou--%>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="证件有效期限" DataField="zhengjianyouxiao">
                        <%--suoshujigou--%>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="籍贯" DataField="jiguan">
                        <%--suoshujigou--%>
                        <ControlStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="审核人" DataField="shenheren">
                        <%--suoshujigou--%>
                        <ControlStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="附件" DataField="fujian">
                        <%--suoshujigou--%>
                        <ControlStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="图片" DataField="tupian">
                        <%--suoshujigou--%>
                        <ControlStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>

                    <asp:ButtonField ButtonType="Button" Text="删除" HeaderText="删除" CommandName="Btn_Operation">
                        <ControlStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>

                    </asp:ButtonField>
                    <%--      <asp:ButtonField ButtonType="Button" Text="操作" HeaderText="编辑" CommandName="Btn_Operation">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>

                    </asp:ButtonField>--%>

                    <%--  <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="editbtn" runat="server" CommandName="EDit" Text="编辑"></asp:LinkButton>
                            </ItemTemplate>
                            <ControlStyle Width="50px" />
                        </asp:TemplateField>--%>

                    <asp:CommandField HeaderText="编辑" ShowEditButton="True">


                        <ControlStyle Font-Bold="True" Width="50px" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>


                    <asp:ButtonField ButtonType="Button" Text="查看" HeaderText="查看图片" CommandName="Btn_View">
                        <ControlStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>

                    </asp:ButtonField>

                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
