<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="Web.Myadmin.changepassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <span style="float: left">当前位置： 用户管理>新建</span>
            </div>
            <br />
            <br />
            <div>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tbody>
                        <%--style="padding-left: 150px;"--%>
                        <tr>
                            <th width="30%">登录帐号*</th>
                            <td>
                                <asp:TextBox ID="textBox6" runat="server" Height="30px" Width="60%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="30%">登录密码*</th>
                            <td>
                                <asp:TextBox ID="textBox5" runat="server" Height="30px" Width="60%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="30%">确认密码*</th>
                            <td>
                                <asp:TextBox ID="textBox4" runat="server" Height="30px" Width="60%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="30%">密保*</th>
                            <td>
                                <asp:TextBox ID="textBox1" runat="server" Height="30px" Width="60%"></asp:TextBox>
                            </td>
                        </tr>


                    </tbody>
                </table>
                <br />
                <br />
                <table cellpadding="0" cellspacing="0" border="0" width="100%">

                    <tr>
                        <td align="center" colspan="5">
                            <div>
                                <asp:Button ID="button1" class="ui-btn ui-btn-search" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                                    onmouseout="this.className='ui-btn ui-btn-search'" runat="server" Text="更新" OnClick="Button1_Click" Width="10%" Height="30px" />
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="button2" class="ui-btn ui-btn-reset" onmouseover="this.className='ui-btn ui-btn-reset-hover'"
                                        onmouseout="this.className='ui-btn ui-btn-reset'" runat="server" Text="清空" OnClientClick="reSet();return false;" Width="10%" Height="30px" OnClick="button2_Click" />
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td align="center" colspan="5">
                            <br />
                            <asp:Label ID="Label1" runat="server">
                             <%=alterinfo1%>
                            </asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

        </div>


    </form>
</body>
</html>
