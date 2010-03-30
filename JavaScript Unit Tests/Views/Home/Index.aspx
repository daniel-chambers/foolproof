<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Foolproof.UnitTests.JavaScript.Models.Model>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        Sys.Application.add_load(function () {
            $("form").get(0)[Sys.Mvc.FormContext._formValidationTag].validate("submit");

            module("Is");

            test("EqualTo Strings", function () {
                ok($("#IsTests_EqualToStringsInvalid_Value2").hasClass("input-validation-error"), "Valid Test");
                ok(!$("#IsTests_EqualToStringsValid_Value2").hasClass("input-validation-error"), "Invalid Test");
            });

            test("NotEqualTo Strings", function () {
                ok($("#IsTests_NotEqualToStringsInvalid_Value2").hasClass("input-validation-error"), "Valid Test");
                ok(!$("#IsTests_NotEqualToStringsValid_Value2").hasClass("input-validation-error"), "Invalid Test");
            });
        });                    
    </script>
    <h1 id="qunit-header">
        QUnit example</h1>
    <h2 id="qunit-banner">
    </h2>
    <h2 id="qunit-userAgent">
    </h2>
    <ol id="qunit-tests">
    </ol>
    <div style="display: none;">
        <% Html.EnableClientValidation(); %>
        <% using (Html.BeginForm())
           { %>
        <div>
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsValid)%>
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsValid)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.EqualToStringsValid)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsInvalid)%>
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsInvalid)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.EqualToStringsInvalid)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.NotEqualToStringsValid)%>
            <%= Html.EditorFor(m => m.IsTests.NotEqualToStringsValid)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.NotEqualToStringsValid)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.NotEqualToStringsInvalid)%>
            <%= Html.EditorFor(m => m.IsTests.NotEqualToStringsInvalid)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.NotEqualToStringsInvalid)%>
        </div>
        <% } %>
    </div>
</asp:Content>
