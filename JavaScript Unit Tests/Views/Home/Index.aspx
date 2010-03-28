<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Foolproof.UnitTests.JavaScript.Models.Model>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <div style="display: block;">
        <% Html.EnableClientValidation(); %>
        <% using (Html.BeginForm())
           { %>
        <div>
            <%= Html.EditorFor(m => m.IsTests.EqualStringFail1)%>
            <%= Html.EditorFor(m => m.IsTests.EqualStringFail2) %>
            <%= Html.ValidationMessageFor(m => m.IsTests.EqualStringFail2) %>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.EqualStringPass1)%>
            <%= Html.EditorFor(m => m.IsTests.EqualStringPass2) %>
            <%= Html.ValidationMessageFor(m => m.IsTests.EqualStringPass2) %>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.NotEqualStringFail1)%>
            <%= Html.EditorFor(m => m.IsTests.NotEqualStringFail2) %>
            <%= Html.ValidationMessageFor(m => m.IsTests.NotEqualStringFail2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.NotEqualStringPass1)%>
            <%= Html.EditorFor(m => m.IsTests.NotEqualStringPass2) %>
            <%= Html.ValidationMessageFor(m => m.IsTests.NotEqualStringPass2)%>
        </div>
        <% } %>
    </div>
    <input id="testButton" type="button" value="Go" />
    <script type="text/javascript">
        function runTests() {
            fireunit.ok($("#IsTests_EqualStringFail2").hasClass("input-validation-error") == true, "EqualTo-Fail");
            fireunit.ok($("#IsTests_EqualStringPass2").hasClass("input-validation-error") == false, "EqualTo-Pass");
            fireunit.ok($("#IsTests_NotEqualStringFail2").hasClass("input-validation-error") == true, "NotEqualTo-Fail");
            fireunit.ok($("#IsTests_NotEqualStringPass2").hasClass("input-validation-error") == false, "NotEqualTo-Pass");
        }

        $(document).ready(function () {
            setTimeout(function () {
                $("form").get(0)[Sys.Mvc.FormContext._formValidationTag].validate("submit");
                runTests();
            }, 100);
        });                
    </script>
</asp:Content>
