<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Foolproof.UnitTests.JavaScript.Models.Model>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <div>
        <% Html.EnableClientValidation(); %>
        <% using (Html.BeginForm())
           { %>
           <%= Html.EditorFor(m => m.IsTests.EqualString1)%>
           <%= Html.EditorFor(m => m.IsTests.EqualString2) %>
           <%= Html.ValidationMessageFor(m => m.IsTests.EqualString2) %>
           <input type="submit" value="" />
        <% } %>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("form input[type=submit]").trigger("click");
        });
    </script>
</asp:Content>
