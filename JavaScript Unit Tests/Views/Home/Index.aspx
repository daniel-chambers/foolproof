<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Foolproof.UnitTests.JavaScript.Models.Model>" %>
<%@ Import Namespace="Foolproof.UnitTests.JavaScript" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        Sys.Application.add_load(function () {
            $("form").get(0)[Sys.Mvc.FormContext._formValidationTag].validate("submit");

            module("Is");

            test("EqualTo Strings", function () {
                ok($("#IsTests_EqualToStringsInvalid_Value2").hasClass("input-validation-error"), "Invalid Test");
                ok(!$("#IsTests_EqualToStringsValid_Value2").hasClass("input-validation-error"), "Valid Test");
            });

            test("NotEqualTo Strings", function () {
                ok($("#IsTests_NotEqualToStringsInvalid_Value2").hasClass("input-validation-error"), "Invalid Test");
                ok(!$("#IsTests_NotEqualToStringsValid_Value2").hasClass("input-validation-error"), "Valid Test");
            });

            test("GreaterThan Dates", function () {
                ok(!$("#IsTests_GreaterThanDates_Value2").hasClass("input-validation-error"), "Valid Test");
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
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsValid.Value1)%>
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsValid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.EqualToStringsValid.Value2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsInvalid.Value1)%>
            <%= Html.EditorFor(m => m.IsTests.EqualToStringsInvalid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.EqualToStringsInvalid.Value2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.NotEqualToStringsValid.Value1)%>
            <%= Html.EditorFor(m => m.IsTests.NotEqualToStringsValid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.NotEqualToStringsValid.Value2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.NotEqualToStringsInvalid.Value1)%>
            <%= Html.EditorFor(m => m.IsTests.NotEqualToStringsInvalid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.NotEqualToStringsInvalid.Value2)%>
        </div>
        <div>
            <%= Html.EditorFor(m => m.IsTests.GreaterThanDatesValid.Value1)%>
            <%= Html.EditorFor(m => m.IsTests.GreaterThanDatesValid.Value2)%>
            <%= Html.ValidationMessageFor(m => m.IsTests.GreaterThanDatesValid.Value2)%>
        </div>
        <% } %>
    </div>
</asp:Content>
