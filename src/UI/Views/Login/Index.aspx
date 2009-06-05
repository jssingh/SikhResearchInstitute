<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
 AutoEventWireup="true" Inherits="SikhResearchInstitute.UI.Helpers.ViewPage.BaseViewPage<LoginForm>"%>
<%@ Import Namespace="System.Security.Policy"%>
<%@ Import Namespace="SikhResearchInstitute.UI.Controllers"%>
<%@ Import Namespace="SikhResearchInstitute.UI.Models.Forms"%>
<%@ Import Namespace="SikhResearchInstitute.UI.Helpers.Extensions" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Log On</h2>
    <p>
        Please enter your username and password. <%= Html.ActionLink("Register", "Register") %> if you don't have an account.
    </p>
    <%=Errors.Display()%>

    <form action="<%= Url.Action<LoginController>(x => x.Login(null)) %>" method="post">
        <div>
            <fieldset>
                <legend>Account Information</legend>
                <p>
                    <label for="username">Username:</label>
                    <%= Html.TextBox("username") %>
                </p>
                <p>
                    <label for="password">Password:</label>
                    <%= Html.Password("password") %>
                </p>
                <p>
                    <%=Html.SubmitButton("login", "Log in") %>
                </p>
            </fieldset>
        </div>
    </form>
</asp:Content>