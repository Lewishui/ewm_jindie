<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Web.login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="inc/logincss.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript">
        function CheckLogin() {
            if (document.MyForm.username.value == "") {
                alert("请输入用户名再提交！");
                document.MyForm.username.focus();
                return false
            }
            if (document.MyForm.password.value == "") {
                alert("请输入密码再提交！");
                document.MyForm.password.focus()
                return false

            }

        }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 227px;
        }
    </style>
</head>

<body>
    <div class="mains">
        <div class="inners">
            <div class="lefts"></div>

            <div class="login">
                <form name="MyForm" id="MyForm" runat="server">
                    <%--<form action="admin_login.asp" method="post" name="MyForm" id="Form1" runat="server" >--%>
                    <input type="hidden" value="chklogin" name="reaction">
                    <div class="center">
                        <div class="inner">
                            &nbsp;<p>&nbsp;</p>
                            <p>&nbsp;</p>
                            <p>&nbsp;</p>
                            <p>&nbsp;</p>
                            <p>&nbsp;</p>
                            <p>&nbsp;</p>
                            <p>&nbsp;</p>
                            <table cellpadding="0" cellspacing="0" id="innnertalbe">
                                <tr>
                                    <td height="60">
                                        <p align="right" style="width: 81px">
                                            <b><span style="font-size: 13pt">用 户 名：</span></b>
                                        </p>
                                    </td>
                                    <td class="auto-style1">
                                        <input name="username" type="text" class="login_textfield" id="username" size="16" maxlength="100" value="<%=user%>" /></td>
                                </tr>
                                <tr>
                                    <td height="60">
                                        <p align="right">
                                            <b><span style="font-size: 13pt">密&nbsp; 码：</span></b>
                                        </p>
                                    </td>
                                    <td class="auto-style1">
                                        <input name="password" type="password" class="login_textfield" id="password" size="16" maxlength="100" value="<%=pass%>" /></td>
                                </tr>

                                <tr>
                                    <td height="49"></td>
                                    <td class="auto-style1">

                                        <%--<asp:Button  name="image" runat="server" type="submit" class="LoginSub" OnClientClick="CheckLogin()" onclick="CheckLogin()" value=" 登 录 " />--%>
                                        <asp:Button ID="image" runat="server" Text=" 登 录 " class="LoginSub" OnClick="HtmlBtn_Click" OnClientClick="CheckLogin()" />

                                        <asp:Button ID="btcreate" runat="server" Text=" 注册 " class="LoginSub" OnClick="HtmlBtcreate_Click" Visible="False" />
                                        <br>
                                        <span style="color: #FF0000;"></span>

                                        <br>
                                        <span style="color: #4cff00;"></span>

                                    </td>

                                </tr>
                                <tr>
                                    <td height="49"></td>
                                    <td class="auto-style1">
                                        <asp:Button ID="Btchangepas" runat="server" Text=" 改密 " class="LoginSub" OnClick="Btchangepas_Click" Visible="True" />
                                        <br>
                                        <span style="color: #FF0000;"></span>

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
                        <div class="clearfix"></div>
                    </div>
                </form>
            </div>


        </div>
    </div>

</body>
</html>
