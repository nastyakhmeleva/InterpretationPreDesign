<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SampleWork.aspx.cs" Inherits="InterpretationPreDesign.SampleWork" %>
<%@ Import Namespace="InterpretationPreDesign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Пример работы</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br /><b>Тип источника данных: </b><asp:Label sourcetype="Sourcetype" runat="server"></asp:Label>
            <%--<%foreach  (Source s in )%>--%>
            <p class="lead">Имя источника данных: </p>
        </div>
    </form>
</body>
</html>
