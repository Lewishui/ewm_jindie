<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUserManger.aspx.cs" Inherits="Web.frmUserManger" %>


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
                <table>
                    <tbody>
                        <tr>
                            <th width="30%">所属机构*</th>
                            <td>
                                <asp:TextBox ID="comboBox1" runat="server" Height="30px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="30%">登录帐号*</th>
                            <td>
                                <asp:TextBox ID="textBox1" runat="server" Height="30px"></asp:TextBox>
                            </td>
                            <th width="30%">登录密码*</th>
                            <td>
                                <asp:TextBox ID="textBox2" runat="server" Height="30px"></asp:TextBox>
                            </td>
                            <th width="30%">确认密码*</th>
                            <td>
                                <asp:TextBox ID="textBox3" runat="server" Height="30px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="30%">帐号设置*</th>
                            <td>
                                <ul>
                                    <asp:RadioButton ID="radioButton1" runat="server" Height="30px" GroupName="Sports" Text="正常"></asp:RadioButton>
                                    <asp:RadioButton ID="radioButton2" runat="server" Height="30px" GroupName="Sports" Text="锁定"></asp:RadioButton>
                                </ul>
                            </td>
                            <th width="30%">密保*</th>
                            <td>
                                <asp:TextBox ID="textBox4" runat="server" Height="30px" Width="100%"></asp:TextBox>
                            </td>


                        </tr>
                        <tr>
                            <th width="30%">系统管理员*</th>
                            <td>
                                <ul>
                                    <asp:CheckBox ID="checkBox1" runat="server" Height="30px" Text=""></asp:CheckBox>
                                </ul>
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
                                    onmouseout="this.className='ui-btn ui-btn-search'" runat="server" Text="创建" OnClick="Button1_Click" Width="20%" Height="30px" />
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="button2" class="ui-btn ui-btn-reset" onmouseover="this.className='ui-btn ui-btn-reset-hover'"
                                        onmouseout="this.className='ui-btn ui-btn-reset'" runat="server" Text="清空" OnClientClick="reSet();return false;" Width="20%" Height="30px" OnClick="button2_Click" />
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
                <asp:GridView ID="gvList" runat="server" Width="100%" AutoGenerateColumns="False"
                    CssClass="ui-datalist-view"
                    CellPadding="0" Style="margin-top: 5px;" GridLines="None"
                    EmptyDataText="&lt;span class='ui-icon ui-icon-remind' style='float: left; margin-right: .3em;'&gt;&lt;/span&gt;&lt;strong&gt;提醒：&lt;/strong&gt;对不起！您所查询的数据不存在。"
                    EnableModelValidation="True" OnRowCommand="GridView_OnRowCommand">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <%--   <ItemTemplate>
                            <input type="hidden" id="hdfDetailID" runat="server" value='<%#Eval("EXAM_DETAIL_ID") %>' />
                        </ItemTemplate>--%>
                            <ItemStyle HorizontalAlign="Center" Width="0%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="登录帐号" DataField="name">
                            <%--dengluzhanghao--%>
                            <%--<FooterStyle HorizontalAlign="Left" />--%>
                            <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="登录密码" DataField="password">
                            <%--denglumima--%>
                            <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="所属机构" DataField="jigoudaima">
                            <%--suoshujigou--%>
                            <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                        </asp:BoundField>

                        <asp:ButtonField ButtonType="Button" Text="删除" HeaderText="删除" CommandName="Btn_Operation">
                            <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>

                        </asp:ButtonField>


                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </form>
</body>
</html>
